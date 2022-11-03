namespace Artillery.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor;

    public class Deserializer
    {
        private const string ErrorMessage =
                "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            var sb = new StringBuilder();

            //var countriesXml = XmlConverter.Deserializer<CountryModelView>(xmlString, "Countries");

            HashSet<Country> countries = new HashSet<Country>();

            XmlSerializer serializer = new XmlSerializer(typeof(CountryModelView[]), new XmlRootAttribute("Countries"));
            using StringReader reader = new StringReader(xmlString);
            var countriesXml = (CountryModelView[])serializer.Deserialize(reader);

            foreach (var countryXml in countriesXml)
            {
                if (!IsValid(countryXml))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var country = new Country
                {
                    CountryName = countryXml.CountryName,
                    ArmySize = countryXml.ArmySize
                };

                countries.Add(country);
                sb.AppendLine(string.Format(SuccessfulImportCountry, country.CountryName, country.ArmySize));
            }

            context.Countries.AddRange(countries);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var manufacturersXml = XmlConverter.Deserializer<ManufacturerModelView>(xmlString, "Manufacturers");

            HashSet<Manufacturer> manufacturers = new HashSet<Manufacturer>();

            foreach (var manuXml in manufacturersXml)
            {
                if (!IsValid(manuXml))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (manufacturers.Any(x=>x.ManufacturerName == manuXml.ManufacturerName))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var manufacturer = new Manufacturer
                {
                    ManufacturerName = manuXml.ManufacturerName,
                    Founded = manuXml.Founded
                };

                string[] founded = manufacturer.Founded.Split(", ");

                string townName = founded[founded.Length - 2];
                string countryName = founded[founded.Length - 1];

                string result = townName + ", " + countryName;

                manufacturers.Add(manufacturer);
                sb.AppendLine(string.Format(SuccessfulImportManufacturer, manufacturer.ManufacturerName, result));
            }
            context.Manufacturers.AddRange(manufacturers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var shellsXml = XmlConverter.Deserializer<ShellModelView>(xmlString, "Shells");

            HashSet<Shell> shells = new HashSet<Shell>();
            foreach (var shellXml in shellsXml)
            {
                if (!IsValid(shellXml))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var shell = new Shell
                {
                    ShellWeight = shellXml.ShellWeight,
                    Caliber = shellXml.Caliber
                };

                shells.Add(shell);
                sb.AppendLine(string.Format(SuccessfulImportShell, shell.Caliber,shell.ShellWeight));
            }
            context.Shells.AddRange(shells);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var gunsJson = JsonConvert.DeserializeObject<IEnumerable<GunsModelView>>(jsonString);

            var guns = new List<Gun>();

            foreach (var gunJson in gunsJson)
            {
                if (!IsValid(gunJson))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var gun = new Gun
                {
                    ManufacturerId = gunJson.ManufacturerId,
                    GunWeight = gunJson.GunWeight,
                    BarrelLength = gunJson.BarrelLength,
                    NumberBuild = gunJson.NumberBuild,
                    Range = gunJson.Range,
                    GunType = Enum.Parse<GunType>(gunJson.GunType),
                    ShellId = gunJson.ShellId,
                    CountriesGuns = gunJson.Countries.Select(x => new CountryGun
                    {
                        CountryId = x.Id
                    }).ToList()
                };
                guns.Add(gun);
                sb.AppendLine(string.Format(SuccessfulImportGun,gun.GunType.ToString(), gun.GunWeight, gun.BarrelLength));
            }
            context.Guns.AddRange(guns);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
