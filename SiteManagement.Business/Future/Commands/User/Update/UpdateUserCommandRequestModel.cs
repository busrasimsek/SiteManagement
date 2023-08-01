using MediatR;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SiteManagement.Business.Future.Commands.User.Update
{
    public class UpdateUserCommandRequestModel : IRequest<ResponseItem>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
