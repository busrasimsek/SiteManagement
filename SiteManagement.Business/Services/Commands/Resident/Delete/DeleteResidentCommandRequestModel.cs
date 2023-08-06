using MediatR;
using SiteManagement.Core.Response;
using System.Text.Json.Serialization;

namespace SiteManagement.Business.Services.Commands.Resident.Delete
{
    public class DeleteResidentCommandRequestModel : IRequest<ResponseItem>
    {
        [JsonIgnore]
        public int Id { get; set; }
    }
}