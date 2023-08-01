using SiteManagement.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Data.Entity
{
    public class Vehicle: BaseEntity
    {
        public int UserId { get; set; }
        public string Model { get; set; }
        public string Plate { get; set; }
        public virtual User User { get; set; }
    }
}
