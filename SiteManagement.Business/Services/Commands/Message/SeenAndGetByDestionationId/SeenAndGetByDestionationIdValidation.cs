using FluentValidation;

namespace SiteManagement.Business.Services.Commands.Message.SeenAndGetByDestionationId
{
    public class SeenAndGetByDestionationIdValidation : AbstractValidator<SeenAndGetByDestionationIdCommandRequestModel>
    {
        public SeenAndGetByDestionationIdValidation()
        {
            RuleFor(m => m.SourceUserId).NotEmpty().NotNull();
            RuleFor(m => m.DestinationUserId).NotEmpty().NotNull();
        }
    }
}
