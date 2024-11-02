namespace encrypzERP.BL.Models
{
    public class mUsers
    {
        public int pkUserId { get; set; }
        public string userId { get; set; }
        public string password { get; set; }
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNo1 { get; set; }
        public string emailId { get; set; }
        public string panCardNo { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public int fkNationId { get; set; }
        public int fkStateId { get; set; }
        public string postalCode { get; set; }
        public int fkSubscriptionPlanId { get; set; }        
        public string Description { get; set; }
        public string Status { get; set; }
    }

}
