using SalgoTechnik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalgoTechnik.Application.Interfaces
{
    public interface IProjectService
    {
        Task<List<Project>> GetAllAsync();
        Task<List<Project>> SortHelper(string Type, string LegalRelationship, string ProjectLocation, string ProjectLanguage);
    }
}
