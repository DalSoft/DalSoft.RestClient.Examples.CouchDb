namespace DalSoft.RestClient.Examples.CouchDb.Models
{
    public class Membership
    {
        public string DocType { get; set; }
        public Association Association { get; set; }
        public string MembershipNum { get; set; }
        public string SkillStatus { get; set; }
        public bool IsVerified { get; set; }
        public bool HasAppled { get; set; }
        public bool HasWaver { get; set; }
        public bool IsJudge { get; set; }
        public bool IsPurebred { get; set; }
    }
}