using MediatR;
using SiteManagement.Core.Response;

namespace SiteManagement.Business.Services.Commands.Home.Insert
{
    public class InsertHomeCommandRequestModel : IRequest<ResponseItem>
    {
        public int UserId { get; set; }
        public int Floor { get; set; }
        public string No { get; set; }
        public string HomeType { get; set; }
        public bool? Status { get; set; }
        public int ApartmentId { get; set; }
        public bool? IsTenant { get; set; }
    }
}
