using System;
using System.Text.Json.Serialization;

namespace Mediator.Domain.Entities
{
    public class Order : Parent
    {
        public int customer_id { get; set; }
        public string text { get; set; }
        public long price { get; set; }

        [JsonIgnore]
        public Customer Customer { get; set; }
    }
}
