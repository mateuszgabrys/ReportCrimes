using CrimeEventAPI.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrimeEventAPI.DbContexts
{
    public class ApplicationDbContext
    {
        public ApplicationDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);

            Crimes = database.GetCollection<CrimeEvent>(configuration["DatabaseSettings:CollectionName"]);
            SeedData(Crimes);
        }

        public IMongoCollection<CrimeEvent> Crimes { get; }
        private static void SeedData(IMongoCollection<CrimeEvent> crimeCollection)
        {
            bool existCrimes = crimeCollection.Find(p => true).Any();
            if (!existCrimes)
            {
                crimeCollection.InsertManyAsync(GetPreconfiguredCrimes());
            }
        }

        private static IEnumerable<CrimeEvent> GetPreconfiguredCrimes()
        {
            return new List<CrimeEvent>()
            {
                new CrimeEvent
            {
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus nec egestas dui. In hac habitasse platea dictumst. Cras vestibulum sodales est a dictum.",
                PlaceOfEvent = "Kraków, ul. Rynek 5",
                ReportingPersonEmail = "zgloszenie@gmail.com",
                Status = "Waiting",
                TypeOfEvent = "Assault",
                DateOfEvent = DateTime.Now,
                
            },
            new CrimeEvent
            {
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus nec egestas dui. In hac habitasse platea dictumst. Cras vestibulum sodales est a dictum.",
                PlaceOfEvent = "Kraków, ul. Rynek 10",
                ReportingPersonEmail = "zgloszenie1@gmail.com",
                Status = "Finished",
                TypeOfEvent = "Burglary",
                DateOfEvent = DateTime.Now,
            },
            new CrimeEvent
            {
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus nec egestas dui. In hac habitasse platea dictumst. Cras vestibulum sodales est a dictum.",
                PlaceOfEvent = "Kraków, ul. Rynek 25",
                ReportingPersonEmail = "zgloszenie2@gmail.com",
                Status = "Canceled",
                TypeOfEvent = "Fraud",
                DateOfEvent = DateTime.Now,
            },
            };

        }
    }
}
