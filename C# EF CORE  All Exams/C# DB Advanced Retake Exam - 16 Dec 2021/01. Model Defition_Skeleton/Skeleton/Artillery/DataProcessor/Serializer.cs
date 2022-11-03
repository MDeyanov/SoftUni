
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shells = context.Shells
               .ToList()
               .Where(x => x.ShellWeight > shellWeight)
               .Select(s => new
               {
                   ShellWeight = s.ShellWeight,
                   Caliber = s.Caliber,
                   Guns = s.Guns
                   .ToList()
                   .Where(g => g.GunType.ToString() == "AntiAircraftGun")
                   .Select(g => new
                   {
                       GunType = g.GunType.ToString(),
                       GunWeight = g.GunWeight,
                       BarrelLength = g.BarrelLength,
                       Range = g.Range > 3000 ? "Long-range" : "Regular range"
                   })
                   .OrderByDescending(x => x.GunWeight)
                   .ToList()
               })
               .OrderBy(s=>s.ShellWeight)
               .ToList();

            string result = JsonConvert.SerializeObject(shells, Formatting.Indented);

            return result;
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute root = new XmlRootAttribute("Guns");
            XmlSerializer serializer = new XmlSerializer(typeof(ExportGunsDto[]), root);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            using StringWriter sw = new StringWriter(sb);

            var gunsDto = context.Guns
                .ToArray()
                .Where(e => e.Manufacturer.ManufacturerName == manufacturer)
                .Select(g => new ExportGunsDto()
                {
                    Manufacturer = g.Manufacturer.ManufacturerName,
                    GunType = g.GunType.ToString(),
                    GunWeight = g.GunWeight,
                    BarrelLength = g.BarrelLength,
                    Range = g.Range,
                    Countries = g.CountriesGuns
                                 .ToArray()
                                 .Where(c => c.Country.ArmySize > 4500000)
                                 .Select(c => new CountryDto()
                                 {
                                     Country = c.Country.CountryName,
                                     ArmySize = c.Country.ArmySize                      
                                 })
                                 .OrderBy(x=>x.ArmySize)
                                 .ToArray()
                }).OrderBy(x=>x.BarrelLength)
                .ToArray();

            serializer.Serialize(sw, gunsDto, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
