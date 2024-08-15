using FluentValidation;
using Rasyotek.Business.DTOs;
using Rasyotek.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rasyotek.Business.ValidationRules
{
    public class PersonelValidator: AbstractValidator<CreatePersonelDto>
    {
        public PersonelValidator()
        {
            RuleFor(x => x.Ad).NotEmpty().WithMessage("Ad boş geçilemez");
            RuleFor(x => x.Soyad).NotEmpty().WithMessage("Soyad boş geçilemez");
            RuleFor(x => x.Cinsiyet).NotEmpty().WithMessage("Cinsiyet boş geçilemez");
            

        }

    }
}
