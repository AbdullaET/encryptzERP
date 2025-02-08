using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Admin.DTOs
{
    public class UserDto
    {        
        public string userId { get; set; }
        public string userName { get; set; }
        public string? userPassword { get; set; }
        public string? panNo { get; set; }
        public string? adharCardNo { get; set; }
        public string? phoneNo { get; set; }
        public string? address { get; set; }
        public int? stateId { get; set; }
        public int? nationId { get; set; }
        public bool isActive { get; set; }

    }
}
