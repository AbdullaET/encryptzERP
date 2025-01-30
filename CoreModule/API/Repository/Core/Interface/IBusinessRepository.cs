using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.Core;

namespace Repository.Core.Interface
{
    public interface IBusinessRepository
    {
        Task<IEnumerable<Business>> GetAllAsync();
        Task<Business> GetByIdAsync(long id);
        Task AddAsync(Business business);
        Task UpdateAsync(Business business);
        Task DeleteAsync(long id);
    }
}
