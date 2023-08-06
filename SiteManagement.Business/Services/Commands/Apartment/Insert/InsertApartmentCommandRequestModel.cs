using MediatR;
using SiteManagement.Core.Response;

namespace SiteManagement.Business.Services.Commands.Apartment.Insert
{
    public class InsertApartmentCommandRequestModel : IRequest<ResponseItem>
    {
        public string Name { get; set; }
        public string? Block { get; set; }
        public string? Address { get; set; }
        public string? No { get; set; }
        public int? FloorCount { get; set; }

        public int? ManagerId { get; set; }
    }
}
