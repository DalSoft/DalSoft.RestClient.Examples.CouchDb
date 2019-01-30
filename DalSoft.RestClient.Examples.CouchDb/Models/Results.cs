using System.Collections.Generic;
using Newtonsoft.Json;

namespace DalSoft.RestClient.Examples.CouchDb.Models
{
    public class Results
    {
        [JsonProperty("total_rows")]
        public int TotalRows { get; set; }
        
        public int Offset { get; set; }
        
        public List<Row> Rows { get; set; }
    }
}