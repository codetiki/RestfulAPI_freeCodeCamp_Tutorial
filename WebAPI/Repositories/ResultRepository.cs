using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Contexts;
using WebAPI.Interfaces;
using WebAPI.Models;
using WebAPI.Persistence;

namespace WebAPI.Repositories
{
        public class ResultRepository : BaseRepository, IResultRepository
        {
            public ResultRepository(AppDbContext context) : base(context)
            {
            }

            public async Task<IEnumerable<Result>> ListAsync()
            {
                return await _context.Results.Include(p => p.ForceType).ToListAsync();
            }

           
        }
    
}
