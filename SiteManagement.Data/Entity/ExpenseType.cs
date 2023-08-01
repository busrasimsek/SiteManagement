using SiteManagement.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Data.Entity
{
    public class ExpenseType : BaseEntity
    {
        public string TypeName { get; set; }
        public string? Description { get; set; }
    }
}
