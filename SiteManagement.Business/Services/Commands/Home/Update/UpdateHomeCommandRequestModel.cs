using MediatR;
using SiteManagement.Core.Response;
using System.Text.Json.Serialization;

namespace SiteManagement.Business.Services.Commands.Home.Update
{
    public class UpdateHomeCommandRequestModel : IRequest<ResponseItem>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Floor { get; set; }
        public string No { get; set; }
        public string HomeType { get; set; }
        public bool? Status { get; set; }
        public int ApartmentId { get; set; }
        public bool? IsTenant { get; set; }
    }
}
