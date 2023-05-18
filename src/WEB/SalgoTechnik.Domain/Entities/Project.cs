using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalgoTechnik.Domain.Entities
{
    public class Project
    {
        [Required]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime Date { get; set; }
        public string? DateConverted { get; set; }
        public string? ImageUrl { get; set; }

        public string ProjectType { get; set; }
        public string LegalRelationship { get; set; }
        public string ProjectLocation { get; set; }
        public string ProjectLanguage { get; set; }
    }
}
