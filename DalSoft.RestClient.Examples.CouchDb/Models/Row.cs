namespace DalSoft.RestClient.Examples.CouchDb.Models
{
    public class Row
    {
        public string Id { get; set; }
        public string Key { get; set; }
        public object Value { get; set; }
        public Doc Doc { get; set; }
    }
}