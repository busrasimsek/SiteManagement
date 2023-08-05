using AutoMapper;
using Castle.Core.Configuration;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Core.Identity;
using SiteManagement.Core.Response;
using SiteManagement.Core.Response.TokenResponse;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Business.Services.Commands.Identity.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequestModel, ResponseItem<Token>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        public LoginCommandHandler(IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }
        public async Task<ResponseItem<Token>> Handle(LoginCommandRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();
            var user = await _unitOfWork.Repository<IUserRepository>().Query().Where(x=> x.Username == request.Username).FirstOrDefaultAsync();
            if(user is null)
            {
                return response.Error<Token>(MessageCodesEnum.UserNotFoundError);
            }
            if(user.Password != request.Password)
            {
                return response.Error<Token>(MessageCodesEnum.WrongPasswordError);
            }

            //string secretKey = "a-secret-key-with-at-least-32-characters123";
            //var tokenService = new TokenService(secretKey);
            var role = await _unitOfWork.Repository<IUserRoleRepository>().Query().FirstOrDefaultAsync(x => x.Id == user.UserRoleId);
            var token = _tokenService.GenerateToken(900,user.Username, role.Type);

            return response.Ok(token);
        }
    }
}
