using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace JWTAuth.Models.Shop
{
    public class Customer
    {
        public int id { get; set; }
        public string name { get; set; }

        [JsonIgnore]
        public List<Order>? Order { get; set; }

        [JsonIgnore]
        public Address? Address { get; set; }
    }

    public class Order
    {
        public int id { get; set; }
        public string name { get; set; }
        public long price { get; set; }

        public int customer_id { get; set; }

        [JsonIgnore]
        public Customer? Customer { get; set; }
    }

    public class Address
    {
        public int id { get; set; }
        public string street { get; set; }
        public int number { get; set; }

        public int customer_id { get; set; }

        [JsonIgnore]
        public Customer? Customer { get; set; }
    }
}
