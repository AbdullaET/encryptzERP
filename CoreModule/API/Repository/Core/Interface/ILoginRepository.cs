using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Admin;



namespace Repository.Core.Interface
{
    public interface ILoginRepository
    {
        Task<User> LoginAsync(string userName,string password);
    }
}
