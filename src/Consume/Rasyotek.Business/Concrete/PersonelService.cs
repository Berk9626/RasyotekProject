using AutoMapper;
using Rasyotek.Business.Abstract;
using Rasyotek.Business.DTOs;
using Rasyotek.DataAccess.Repository;
using Rasyotek.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rasyotek.Business.Concrete
{
    public class PersonelService : IPersonelService
    {
        private readonly IRepository<Personel> _personelRepository;
        private readonly IMapper _mapper;

        public PersonelService(IRepository<Personel> personelRepository, IMapper mapper)
        {
            _personelRepository = personelRepository;
            _mapper = mapper;
        }

        public void Add(CreatePersonelDto personeldtp)
        {
            var personelent = _mapper.Map<Personel>(personeldtp);
            _personelRepository.Insert(personelent);

        }

        public void Delete(int id)
        {
            var personelent = _personelRepository.GetById(id);

           
            _personelRepository.Delete(personelent);
        }

        public List<ResultPersonelDto> GetAll()
        {
            var aboutEntities = _personelRepository.GetList();

           
            var resultpersoneldtos = _mapper.Map<List<ResultPersonelDto>>(aboutEntities);

            return resultpersoneldtos;
        }

        public GetByIdPersonelDto GetById(int id)
        {
            var persent = _personelRepository.GetById(id);

            // Varlığı DTO'ya dönüştürün
            var getidbypers = _mapper.Map<GetByIdPersonelDto>(persent);

            return getidbypers;
        }

        public void Update(UpdatePersonelDto personelDto)
        {
            var personent = _mapper.Map<Personel>(personelDto);

            // Veritabanında güncelleme işlemi
            _personelRepository.Update(personent);
        }
    }
}
