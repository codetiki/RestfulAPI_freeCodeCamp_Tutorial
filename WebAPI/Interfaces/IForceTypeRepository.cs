using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface IForceTypeRepository
    {
        Task<IEnumerable<ForceType>> ListAsync();
        Task AddAsync(ForceType forceType);
        Task<ForceType> FindByIdAsync(int id);
        void Update(ForceType forceType);
        void Remove(ForceType forceType);
    }
}
