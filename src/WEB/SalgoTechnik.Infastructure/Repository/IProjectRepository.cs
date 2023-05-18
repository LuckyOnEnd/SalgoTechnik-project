using SalgoTechnik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalgoTechnik.Infastructure.Repository
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
    }
}
