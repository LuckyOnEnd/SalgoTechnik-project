using Microsoft.EntityFrameworkCore;
using SalgoTechnik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalgoTechnik.Infastructure.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;
        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await _context.Projects.ToListAsync();
        }
    }
}
