using FluentValidation;
using FluentValidationApp.Web.Models.Entities;
using System;

namespace FluentValidationApp.Web.FluentValidatiors
{
    public class CustomerValidator:AbstractValidator<Customer>
    {

        public string NotEmptyMessage { get; } = "{PropertyName} alanı boş olamaz";//properyName alanı öncesinde yazılmış entitinin adıdır.
        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.Email).NotEmpty().WithMessage(NotEmptyMessage).EmailAddress().WithMessage("Email alanı doğru formatta olmalıdır");
            RuleFor(x => x.Age).NotEmpty().WithMessage(NotEmptyMessage).InclusiveBetween(18, 60).WithMessage("Age aralığı 18 ile 60 yaş arası olmalıdır.");
            //Custom bir kod yazabilmek için Must isminde bir method kullanıyoruz bu method içerisinde 
            RuleFor(x => x.BirthDay).NotEmpty().WithMessage(NotEmptyMessage).Must(x =>
            {
                return DateTime.Now.AddYears(-18) >= x;//şuan ki olduğumuz yıldan 18 çıkarıp adamın yaşıyla bir sorgu döndürüyor
                                                       //(18 yasşından büyük olup olmadığına bakıyor
                                                       //ona göre true ya da false dönüyor
                                                       //eğer false dönerse methodun sonunda ki with message bir hata fırlatacaktır.)
            }).WithMessage("Yaşınız 18'den büyük olmalıdır.") ;


            RuleForEach(x =>x.Addresses).SetValidator(new AddressValidator());

            RuleFor(x => x.gender).IsInEnum().WithMessage("{PropertyName} alanı Erkek=1, Bayan=2 olmalıdır.");
        }
    }
}



//bizim projemizin customerValidation'dan haberi yok haberi olması gerekiyor bunun için