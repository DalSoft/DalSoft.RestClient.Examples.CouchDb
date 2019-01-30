using System.Collections.Generic;

namespace DalSoft.RestClient.Examples.CouchDb.Models
{
    public class Association
    {
        public string Id { get; set; }
        public string DocType { get; set; }
        public string ShortName { get; set; }
        public string AssocName { get; set; }
        public string Address1 { get; set; }
        public string PostalCode { get; set; }
        public bool RegistryFlag { get; set; }
        public int NonMemberHumanFee { get; set; }
        public int NonMemberHorseFee { get; set; }
        public int WaverFee { get; set; }
        public List<Phone> Phones { get; set; }
    }
}