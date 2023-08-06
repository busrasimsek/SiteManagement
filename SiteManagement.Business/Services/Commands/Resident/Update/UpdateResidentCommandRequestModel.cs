using MediatR;
using SiteManagement.Core.Response;
using System.Text.Json.Serialization;

namespace SiteManagement.Business.Services.Commands.Resident.Update
{
    public class UpdateResidentCommandRequestModel :IRequest<ResponseItem>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int? Age { get; set; }
        public bool? Sex { get; set; }
        public int HomeId { get; set; }
    }
}
