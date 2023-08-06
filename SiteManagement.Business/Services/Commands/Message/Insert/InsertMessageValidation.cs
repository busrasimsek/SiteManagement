using FluentValidation;

namespace SiteManagement.Business.Services.Commands.Message.Insert
{
    public class InsertMessageValidation : AbstractValidator<InsertMessageCommandRequestModel>
    {
        public InsertMessageValidation()
        {
            RuleFor(m => m.SourceUserId).NotEmpty().NotNull();
            RuleFor(m => m.DestinationUserId).NotEmpty().NotNull();
            RuleFor(m => m.Messages).NotEmpty().NotNull();
        }
    }
}
