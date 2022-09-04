using FluentValidation;
using FluentValidationApp.Web.Models.Entities;

namespace FluentValidationApp.Web.FluentValidatiors
{
    public class AddressValidator:AbstractValidator<Address>
    {
        public string NotEmptyMessage { get; } = "{PropertyName} alanı boş olamaz";
        public AddressValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.Province).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.PostCode).NotEmpty().WithMessage(NotEmptyMessage).MaximumLength(5).WithMessage("{PropertyName} en fazla {MaxLength} karakterden oluşabilir");
        }
    }
}
