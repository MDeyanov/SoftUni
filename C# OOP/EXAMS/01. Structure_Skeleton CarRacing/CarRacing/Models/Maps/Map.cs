using System;
using System.Collections.Generic;
using System.Text;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            if (!racerOne.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            if (!racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }

            double behaviorOne = 0;
            double behaviorTwo = 0;
            if (racerOne.RacingBehavior=="strict")
            {
                behaviorOne = 1.2;
            }
            else if (racerOne.RacingBehavior == "aggressive")
            {
                behaviorOne = 1.1;
            }

            if (racerTwo.RacingBehavior == "strict")
            {
                behaviorTwo = 1.2;
            }
            else if (racerTwo.RacingBehavior == "aggressive")
            {
                behaviorTwo = 1.1;
            }
            var chanceOfWinningOne = racerOne.Car.HorsePower * racerOne.DrivingExperience * behaviorOne;
            var chanceOfWinningTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * behaviorTwo;
            var winner = "";
            if (chanceOfWinningOne > chanceOfWinningTwo)
            {
                winner = racerOne.Username;

            }
            else
            {
                winner = racerTwo.Username;
            }
            racerOne.Race();
            racerTwo.Race();

            return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winner);
        }
    }
}
