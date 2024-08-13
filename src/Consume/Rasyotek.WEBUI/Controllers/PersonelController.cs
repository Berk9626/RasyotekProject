using Microsoft.AspNetCore.Mvc;
using Rasyotek.Business.Abstract;
using Rasyotek.Business.DTOs;
using Rasyotek.Entity;
using Rasyotek.WEBUI.ApiCallsServices.Abstract;

namespace Rasyotek.WEBUI.Controllers
{
    public class PersonelController : Controller
    {
        private readonly IPersonelService _personelService;
        private readonly IUniversityService _universityService;
        public PersonelController(IPersonelService personelService, IUniversityService universityService)
        {
            _personelService = personelService;
            _universityService = universityService;
                
        }
        public IActionResult Index()
        {
            var personels = _personelService.GetAll();
            return View(personels);
        }
        public async Task<IActionResult> Create()
        {
            //apiden çekilen üniler 
            var model = new CreatePersonelDto
            {
                Mezuniyet = await _universityService.GetUniversitiesAsync()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePersonelDto model)
        {
            if (ModelState.IsValid)
            {
                var personelDto = new CreatePersonelDto
                {
                    Ad = model.Ad,
                    Soyad = model.Soyad,
                    Cinsiyet = model.Cinsiyet,
                    Zimmet = model.Zimmet,
                    Mezuniyet = model.Mezuniyet
                };

                _personelService.Add(personelDto);
                return RedirectToAction("Index");
            }

            model.Mezuniyet = await _universityService.GetUniversitiesAsync(); // List<string> döndürmeli
            return View(model);

        }




        public IActionResult Edit(int id)
        {
            var personel =  _personelService.GetById(id);
            if (personel == null)
            {
                return NotFound();
            }
            return View(personel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, UpdatePersonelDto personeldto)
        {
            if (id != personeldto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                 _personelService.Update(personeldto);
                return RedirectToAction(nameof(Index));
            }
            return View(personeldto);
        }

        public IActionResult Delete(int id)
        {
            var personel =  _personelService.GetById(id);
            if (personel == null)
            {
                return NotFound();
            }
            return View(personel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
             _personelService.Delete(id);
            return RedirectToAction(nameof(Index));
        }




    }
}
