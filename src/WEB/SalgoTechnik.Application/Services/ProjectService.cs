using Microsoft.EntityFrameworkCore;
using SalgoTechnik.Application.Interfaces;
using SalgoTechnik.Domain.Entities;
using SalgoTechnik.Infastructure;
using SalgoTechnik.Infastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalgoTechnik.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ApplicationDbContext _context;
        //private readonly IProjectRepository _projectRepository;

        public ProjectService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Project>> GetAllAsync()
        {
            var result = await _context.Projects.ToListAsync();
            foreach(var x in result)
            {
                x.DateConverted = EditDate(x.Date);
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

        public async Task<List<Project>> SortHelper(string Type, string LegalRelationship, string ProjectLocation, string ProjectLanguage)
        {
            var projects = await _context.Projects.Where(x => x.ProjectType == Type
                && x.LegalRelationship == LegalRelationship
                && x.ProjectLocation == ProjectLocation
                && x.ProjectLanguage == ProjectLanguage).ToListAsync();

            return projects;
        }
    }
}
