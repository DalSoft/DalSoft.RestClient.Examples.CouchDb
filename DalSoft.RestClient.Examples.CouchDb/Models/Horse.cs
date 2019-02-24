using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace DalSoft.RestClient.Examples.CouchDb.Models
{
    public class Horse
    {
        private readonly HttpMethod _httpMethod;

        public Horse(HttpMethod httpMethod)
        {
            _httpMethod = httpMethod;
        }
        
        [JsonProperty("_id")]
        public string Id { get; set; }
        
        [JsonProperty("_rev")]
        public string Rev { get; set; }
        
        public string DocType { get; set; }
        
        public List<object> Notes { get; set; }
        
        public List<Membership> Memberships { get; set; }
        
        public string Name { get; set; }
        
        public double Height { get; set; }
        
        public string Color { get; set; }
        
        public string Sex { get; set; }
        
        public DateTime Dob { get; set; }

        public bool ShouldSerializeId()
        {
            return _httpMethod == HttpMethod.Put;
        }

        public bool ShouldSerializeRev()
        {
            return ShouldSerializeId();
        }
    }
}