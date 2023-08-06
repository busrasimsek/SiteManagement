using MediatR;
using SiteManagement.Core.Response;
using System.Text.Json.Serialization;

namespace SiteManagement.Business.Services.Commands.User.Delete
{
    public class DeleteUserCommandRequestModel : IRequest<ResponseItem>
    {
        [JsonIgnore]
        public int Id { get; set; }
    }
}
