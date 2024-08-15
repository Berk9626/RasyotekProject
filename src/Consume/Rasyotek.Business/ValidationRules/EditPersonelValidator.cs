using FluentValidation;
using Rasyotek.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rasyotek.Business.ValidationRules
{
    public class EditPersonelValidator
    {
        public class PersonelValidator : AbstractValidator<UpdatePersonelDto>
        {
            public PersonelValidator()
            {
                RuleFor(x => x.Ad).NotEmpty().WithMessage("Ad boş geçilemez");
                RuleFor(x => x.Soyad).NotEmpty().WithMessage("Soyad boş geçilemez");
                RuleFor(x => x.Cinsiyet).NotEmpty().WithMessage("Cinsiyet boş geçilemez");


            }

        }
    }
}
