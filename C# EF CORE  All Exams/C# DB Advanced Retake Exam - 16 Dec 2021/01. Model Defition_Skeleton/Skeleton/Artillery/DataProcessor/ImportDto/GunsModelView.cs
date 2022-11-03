using Artillery.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    public class GunsModelView
    {
        
        public int ManufacturerId { get; set; }

        [Range(100,1350000)]
        public int GunWeight { get; set; }

        [Range(2.00,35.00)]
        public double BarrelLength { get; set; }
        public int? NumberBuild { get; set; }

        [Range(1,100000)]
        public int Range { get; set; }

        [Required]
        [EnumDataType(typeof(GunType))]
        public string GunType { get; set; }

        public int ShellId { get; set; }

        
        public ICollection<CountryIdModel> Countries { get; set; }
    }

    public class CountryIdModel
    {
        public int Id { get; set; }
    }
}
//•	Id – integer, Primary Key
//•	ManufacturerId – integer, foreign key (required)
//•	GunWeight– integer in range[100…1_350_000](required)
//•	BarrelLength – double in range[2.00….35.00](required)
//•	NumberBuild – integer
//•	Range – integer in range[1….100_000](required)
//•	GunType – enumeration of GunType, with possible values (Howitzer, Mortar, FieldGun, AntiAircraftGun, MountainGun, AntiTankGun) (required)
//•	ShellId – integer, foreign key(required)
//•	CountriesGuns – a collection of CountryGun