using encrypzERP.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encrypzERP.BL.Services.users
{
    public interface Iusers
    {
        Task<List<mUsers>> GetUsersAsync();
    }
}
