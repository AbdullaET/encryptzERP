

namespace encrypzERP.BL.Models
{
    public class mCompanyConnectivity
    {
        public string companyCode{get;set;}	
        public int fkModuleId{get;set;}	
        public string moduleName{get;set;}	
        public string serverType{get;set;}	
        public string serverName{get;set;}	
        public string userId{get;set;}		
        public string serverPassword{get;set;}
        public string dbName{get;set;}		
        public string status { get; set; }		
    }
}
