using MediatR;
using SiteManagement.Core.Response;
using System.Text.Json.Serialization;

namespace SiteManagement.Business.Services.Commands.Vehicle.Update
{
    public class UpdateVehicleCommandRequestModel : IRequest<ResponseItem>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Model { get; set; }
        public string Plate { get; set; }
    }
}
