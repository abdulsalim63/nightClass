using System;
using FluentValidation;

namespace JWTAuth.Models.PlayerDetail
{
    public class PlayerValidator : AbstractValidator<Player>
    {
        public PlayerValidator()
        {
            RuleFor(x => x.name).NotEmpty().WithMessage("name can't be empty")
                    .MinimumLength(10).WithMessage("minimum name lenght is 10 character")
                    .MaximumLength(50).WithMessage("maximum name lenght is 50 character");
        }
    }
}
