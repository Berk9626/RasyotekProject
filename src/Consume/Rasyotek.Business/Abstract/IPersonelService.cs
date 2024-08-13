using Rasyotek.Business.DTOs;
using Rasyotek.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rasyotek.Business.Abstract
{
    public interface IPersonelService
    {
        List<ResultPersonelDto> GetAll();
        void Add(CreatePersonelDto personeldtp);
        void Update(UpdatePersonelDto personelDto);
        void Delete(int id);
        GetByIdPersonelDto GetById(int id);
    }
}
