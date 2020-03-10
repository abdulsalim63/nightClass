using System;
using System.Text.Json.Serialization;

namespace Hangfires.Domain.Entities
{
    public class Customer
    {
        public int id { get; set; }
        public string username { get; set; }
        [JsonIgnore]
        public string password { get; set; }
    }
}
