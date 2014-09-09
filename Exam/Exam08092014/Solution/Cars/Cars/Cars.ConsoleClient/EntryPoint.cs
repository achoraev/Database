namespace Cars.ConsoleClient
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Cars.Data;
    using Cars.Data.Migrations;
    using Cars.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;

    public class TemplateClient
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsDbContext, Configuration>());
            
            var db = new CarsDbContext();
            // ParseJson();
            var car = new Car
            {
                //Year = 2014,
                //TransmisionType = 0,
                //Manufacturer = "Mazda",
                //Model = "6 Skyactiv",
                //Price = 60000.0,
                //Dealer = new Dealer
                //{
                //    Name = "Star Motors",
                //    City = "Sofia"
                //}
            };

            // db.Cars.Add(car); 

            db.SaveChanges();
        }

        public static void ParseJson()
        {
            for (int i = 0; i < 4; i++)
            {
                string JsonFilePath = @"../../data." + i + ".json";
                
                List<string> input = new List<string>();

                string json = JsonConvert.SerializeObject(JsonFilePath, Newtonsoft.Json.Formatting.Indented);
                input.Add(json);                
                var items = JsonConvert.DeserializeObject<Car[]>(input[i]); 
            }
        }
    }
}