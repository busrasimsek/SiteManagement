using MediatR;
using SiteManagement.Core.Response;
using System.Text.Json.Serialization;

namespace SiteManagement.Business.Services.Commands.Apartment.Update
{
    public class UpdateApartmentCommandRequestModel : IRequest<ResponseItem>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Block { get; set; }
        public string? Address { get; set; }
        public string? No { get; set; }
        public int? FloorCount { get; set; }
        public int? ManagerId { get; set; }
    }
}
