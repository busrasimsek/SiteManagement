using FluentValidation;

namespace SiteManagement.Business.Services.Commands.UserRole.Insert
{
    public class InsertUserRoleValidation : AbstractValidator<InsertUserRoleCommandRequestModel>
    {
        public InsertUserRoleValidation()
        {
            RuleFor(u => u.Type).NotEmpty().NotNull();
        }
    }
}
