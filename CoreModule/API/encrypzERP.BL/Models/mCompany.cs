namespace encrypzERP.BL.Models
{
    internal class mCompany
    {
        public int pkCompanyId { get; set; }
        public int fkuserId { get; set; }
        public string companyCode { get; set; }
        public string companyName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNo1 { get; set; }
        public string emailId { get; set; }
        public string panCardNo { get; set; }
        public string tanCardNo { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public int fkNationId { get; set; }
        public int fkStateId { get; set; }
        public string postalCode { get; set; }
        public int fkSubscriptionPlanId { get; set; }
        public string status { get; set; }
    }
}
