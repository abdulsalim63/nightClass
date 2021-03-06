﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Mediator.Domain.Entities
{
    public class Customer : Parent
    {
        public string username { get; set; }
        public string address { get; set; }

        [JsonIgnore]
        public List<Order> Order { get; set; }
    }
}
