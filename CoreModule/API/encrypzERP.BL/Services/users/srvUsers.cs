using encrypzERP.BL.dbContexts;
using encrypzERP.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encrypzERP.BL.Services.users
{
    public class srvUsers
    {
        private coreDBContext _dbContext;
        public srvUsers(coreDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<mUsers>> GetAllAccountsAsync()
        {
            return await _dbContext.GetUsersAsync();
        }
    }
}
