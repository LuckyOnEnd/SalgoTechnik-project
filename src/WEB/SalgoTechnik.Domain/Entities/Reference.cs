﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalgoTechnik.Domain.Entities
{
    public class Reference
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date {  get; set; }
        public string ConvertedDate { get; set; }
        public string Details { get; set; }
        public string ImageUrl { get; set; }
    }
}
