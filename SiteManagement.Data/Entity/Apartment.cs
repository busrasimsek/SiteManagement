using SiteManagement.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Data.Entity
{
    public class Apartment : BaseEntity
    {
        public string Name { get; set; }
        public string? Block { get; set; }
        public string? Address { get; set; }
        public string? No { get; set; }
        public int? FloorCount { get; set; }

        // kaç daire li
        public int? ManagerId { get; set; }
        public User Manager { get; set; }
    }
}
