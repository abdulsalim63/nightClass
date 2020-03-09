using System;
using System.Text.Json.Serialization;

namespace Mediator.Domain.Entities
{
    public class Parent
    {
        [JsonIgnore]
        public int id { get; set; }
        [JsonIgnore]
        public long created_at { get; set; } = (long)((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds);
        [JsonIgnore]
        public long updated_at { get; set; } = (long)((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds);
    }
}
