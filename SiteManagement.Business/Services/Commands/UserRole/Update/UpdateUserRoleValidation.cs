using FluentValidation;

namespace SiteManagement.Business.Services.Commands.UserRole.Update
{
    public class UpdateUserRoleValidation : AbstractValidator<UpdateUserRoleCommandRequestModel>
    {
        public UpdateUserRoleValidation()
        {
            RuleFor(u => u.Type).NotEmpty().NotNull();
        }
    }
}