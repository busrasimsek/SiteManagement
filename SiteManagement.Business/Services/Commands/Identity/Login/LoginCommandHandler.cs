using MediatR;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Core.Helper;
using SiteManagement.Core.Identity;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Business.Services.Commands.Identity.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequestModel, ResponseItem<LoginCommandResponseModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        public LoginCommandHandler(IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }
        public async Task<ResponseItem<LoginCommandResponseModel>> Handle(LoginCommandRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();
            var user = await _unitOfWork.Repository<IUserRepository>().Query().Where(x=> x.Username == request.Username).FirstOrDefaultAsync();
            if(user is null)
            {
                return response.Error<LoginCommandResponseModel>(MessageCodesEnum.UserNotFoundError);
            }
            var salt = user.PasswordSalt;
            var hash = HashingHelper.CreatePasswordHash(request.Password, salt);
            if(user.PasswordHash != hash)
            {
                return response.Error<LoginCommandResponseModel>(MessageCodesEnum.WrongPasswordError);

            }

            var role = await _unitOfWork.Repository<IUserRoleRepository>().Query().FirstOrDefaultAsync(x => x.Id == user.UserRoleId);
            var token = _tokenService.GenerateToken(user.Username, role.Type);

            return response.Ok(new LoginCommandResponseModel { Token = token});
        }
    }
}
