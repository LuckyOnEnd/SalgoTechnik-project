using Microsoft.EntityFrameworkCore;
using SalgoTechnik.Application.Interfaces;
using SalgoTechnik.Domain.Entities;
using SalgoTechnik.Infastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalgoTechnik.Application.Services
{
    public class ReferenceService : IReferenceService
    {
        private readonly ApplicationDbContext _context;
        //private readonly IProjectRepository _projectRepository;

        public ReferenceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Reference>> GetAllAsync()
        {
            var result = await _context.References.ToListAsync();
            foreach (var x in result)
            {
                x.ConvertedDate = EditDate(x.Date);
            }
            return result;
        }

        private string EditDate(DateTime date)
        {
            var dayOfWeak = date.DayOfWeek;
            var day = date.Day;
            var month = date.ToString("MMMM");
            var year = date.Year;

            return $"{dayOfWeak} {day}, {month} {year}";
        }
    }
}
