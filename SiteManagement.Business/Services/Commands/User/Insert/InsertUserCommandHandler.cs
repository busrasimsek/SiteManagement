using AutoMapper;
using MediatR;
using SiteManagement.Core.Helper;
using SiteManagement.Core.Notification.Email.Abstract;
using SiteManagement.Core.Notification.Email.Model;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Business.Services.Commands.User.Insert
{
    public class InsertUserCommandHandler : IRequestHandler<InsertUserCommandRequestModel, ResponseItem>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISmtpHelper _smtpHelper;
        public InsertUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ISmtpHelper smtpHelper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _smtpHelper = smtpHelper;
        }
        public async Task<ResponseItem> Handle(InsertUserCommandRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();
            var pass = PasswordGenerator.GeneratePassword(6, true, true, true, true);
            var salt = HashingHelper.CreateSalt(6);
            var hash = HashingHelper.CreatePasswordHash(pass, salt);

            var user = new Data.Entity.User
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = hash,
                PasswordSalt = salt,
                UserRoleId = request.UserRoleId
            };
            _unitOfWork.OpenTransaction();
            _unitOfWork.Repository<IUserRepository>().Add(user);

            if (await _unitOfWork.SaveChangesAsync() < 1)
            {
                _unitOfWork.Rollback();
                return response.Error(MessageCodesEnum.Error);
            }
            _smtpHelper.SendMail(new MailParameters
            {
                MailTo = new List<string> { user.Email },
                MailHeader = "Kullanıcı oluşturulmuştur.",
                MailSubject = @$"Kullanıcı oluşturuldu",
                MailBody = @$"Merhaba <b>{request.Username}</b>. Sisteme giriş yapmak için  <b>'{pass}'</b> şifresini kullanabilirsiniz."
            });
            _unitOfWork.Commit();
            return response.Ok();
        }
    }
}
