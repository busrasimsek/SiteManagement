using MediatR;
using SiteManagement.Core.Response;

namespace SiteManagement.Business.Services.Commands.Vehicle.Insert
{
    public class InsertVehicleCommandRequestModel : IRequest<ResponseItem>
    {
        public int UserId { get; set; }
        public string Model { get; set; }
        public string Plate { get; set; }
    }
}
