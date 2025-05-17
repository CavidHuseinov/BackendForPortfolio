
using FluentValidation;
using Portfolio.Business.Helpers.DTOs.Review;

namespace Portfolio.Business.Helpers.Validatos.Review
{
    public class CreateDtoValidator : AbstractValidator<CreateReviewDto>
    {
        public CreateDtoValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("Rəyinizi boş buraxmayın.");
        }
    }
}
