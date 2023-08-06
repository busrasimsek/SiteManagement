﻿using FluentValidation;

namespace SiteManagement.Business.Services.Commands.Resident.Update
{
    public class UpdateResidentValidation : AbstractValidator<UpdateResidentCommandRequestModel>
    {
        public UpdateResidentValidation()
        {
            RuleFor(r => r.Phone).NotEmpty().NotNull();
            RuleFor(r => r.Firstname).NotEmpty().NotNull();
            RuleFor(r => r.HomeId).NotEmpty().NotNull();
        }
    }
}
