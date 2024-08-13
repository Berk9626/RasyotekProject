using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            List<SelectListItem> selectedListItems = (from c in _universityService.GetUniversitiesAsync().ToString()
                                                      select new SelectListItem
                                                      {
                                                          
                                                        Text = c.ToString(),

                                                      }).ToList();
          
            ViewBag.dgr1 = selectedListItems;
            return View(selectedListItems);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePersonelDto model)
        {
            if (ModelState.IsValid)
            {
                _personelService.Add(model);
                return RedirectToAction("Index");
            }
            //model.Mezuniyets = await _universityService.GetUniversitiesAsync();
            return View(model);
        }




        public async Task<IActionResult> Edit(int id)
        {
            var personel = _personelService.GetById(id);
            if (personel == null)
            {
                return NotFound();
            }

            // Get the list of universities
            var universities = await _universityService.GetUniversitiesAsync();

            var model = new UpdatePersonelDto
            {
                Id = personel.Id,
                Ad = personel.Ad,
                Soyad = personel.Soyad,
                Cinsiyet = personel.Cinsiyet,
                Zimmet = personel.Zimmet,
                Mezuniyet = personel.Mezuniyet,
                
                
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdatePersonelDto model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _personelService.Update(model);
                return RedirectToAction(nameof(Index));
            }

            // Re-populate the universities list if the model state is invalid
            
            return View(model);
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
