using System;
using System.Collections.Generic;

namespace DalSoft.RestClient.Examples.CouchDb.Models
{
    public class Doc
    {
        public string Id { get; set; }
        public string Rev { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string PostalCode { get; set; }
        public string DocType { get; set; }
        public List<object> Phones { get; set; }
        public List<object> Notes { get; set; }
        public List<Horse> Horses { get; set; }
        public List<string> MasterHorseKeys { get; set; }
        public List<object> Memberships { get; set; }
        public bool? CashOnly { get; set; }
        public bool? IsJudge { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Hphone { get; set; }
        public string Cphone { get; set; }
        public DateTime? Dob { get; set; }
        public string Email { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool? Amateur { get; set; }
        public string Address { get; set; }
        public string Sex { get; set; }
    }
}