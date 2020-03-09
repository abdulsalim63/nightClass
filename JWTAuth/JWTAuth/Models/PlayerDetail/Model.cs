using System;
using Newtonsoft.Json;

namespace JWTAuth.Models.PlayerDetail
{
    public class Player
    {
        public int id { get; set; }
        public string name { get; set; }

        [JsonIgnore]
        public string team { get; set; }
    }
}
