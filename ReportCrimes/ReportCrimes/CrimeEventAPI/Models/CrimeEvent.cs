using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CrimeEventAPI.Models
{
    public class CrimeEvent
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CrimeId { get; set; }
        public DateTime DateOfEvent { get; set; }
        public string TypeOfEvent { get; set; }
        public string Description { get; set; }
        public string PlaceOfEvent { get; set; }
        public string ReportingPersonEmail { get; set; }
        public string Status { get; set; }
        public int LawEnforcementId { get; set; }
    }
}
