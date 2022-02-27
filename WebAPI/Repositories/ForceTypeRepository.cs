using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Contexts;
using WebAPI.Persistence;

namespace WebAPI.Repositories
{
    public class ForceTypeRepository : BaseRepository, IForceTypeRepository
    {
        public ForceTypeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ForceType>> ListAsync()
        {
            return await _context.ForceTypes.ToListAsync();
        }

        public async Task AddAsync(ForceType forceType)
        {
            await _context.ForceTypes.AddAsync(forceType);
        }

        public async Task<ForceType> FindByIdAsync(int id)
        {
            return await _context.ForceTypes.FindAsync(id);
        }

        public void Update(ForceType forceType)
        {
            _context.ForceTypes.Update(forceType);
        }

        public void Remove(ForceType forceType)
        {
            _context.ForceTypes.Remove(forceType);
        }


    }
}
