using MediatR;
using SiteManagement.Core.Response;

namespace SiteManagement.Business.Services.Commands.Resident.Insert
{
    public class InsertResidentCommandRequestModel : IRequest<ResponseItem>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? Age { get; set; }
        public bool? Sex { get; set; }
        public int HomeId { get; set; }
    }
}
