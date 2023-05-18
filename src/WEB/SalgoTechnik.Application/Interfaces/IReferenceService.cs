using SalgoTechnik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalgoTechnik.Application.Interfaces
{
    public interface IReferenceService
    {
        Task<List<Reference>> GetAllAsync();
    }
}
