
using FluentValidation;
using Portfolio.Business.Helpers.DTOs.Blog;

namespace Portfolio.Business.Helpers.Validatos.Review
{
    public class CreateDtoValidator : AbstractValidator<CreateBlogDto>
    {
        public CreateDtoValidator()
        {
            RuleFor(x=>x.)
        }
    }
}
