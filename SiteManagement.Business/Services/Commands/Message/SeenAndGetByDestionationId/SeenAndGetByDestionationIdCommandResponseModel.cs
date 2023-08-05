using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Business.Services.Commands.Message.SeenAndGetByDestionationId
{
    public class SeenAndGetByDestionationIdCommandResponseModel
    {
        public string Username { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
