using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        public const int experience = 10;
        public const string behavior = "aggressive";
        public StreetRacer(string username, ICar car) 
            : base(username, behavior, experience, car)
        {
        }

        public override void Race()
        {
            base.Race();
            DrivingExperience += 5;
        }
    }
}
