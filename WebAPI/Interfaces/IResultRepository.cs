using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IResultRepository
    {
        Task<IEnumerable<Result>> ListAsync();
    }
}
