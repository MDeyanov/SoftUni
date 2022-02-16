﻿namespace PersonInfo
{
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        public Citizen(string name,int age,string birthdate,string id)
        {
            this.Name = name;
            this.Age = age;
            this.Birthdate = birthdate;
            this.ID = id;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Birthdate { get; private set; }

        public string ID { get; private set; }

        public int Food { get; private set; }


        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
