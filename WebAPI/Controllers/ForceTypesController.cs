using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Services;
using AutoMapper;
using WebAPI.Resources;
using WebAPI.Extensions;

namespace WebAPI.Controllers
{
    [Route("/api/[controller]")]
    // perii tämän luokan Controller-luokasta, joka on määritetty nimiavaruudessa Microsoft.AspNetCore.Mvc
    // Nimiavaruus koostuu joukosta toisiinsa liittyviä luokkia, rajapintoja, enumeita ja rakenteita. 
    public class ForceTypesController : Controller
    {
        private readonly IForceTypeService _forceTypeService;
        private readonly IMapper _mapper;

        public ForceTypesController(IForceTypeService forceTypeService, IMapper mapper)
        {
            _forceTypeService = forceTypeService;
            // voidaan merkitä kahdella tapaa: this.forceTypeService = _forceTypeService
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ForceTypeResource>> GetAllAsync()
        {
            var forceTypes = await _forceTypeService.ListAsync();
            var resources = _mapper.Map<IEnumerable<ForceType>, IEnumerable<ForceTypeResource>>(forceTypes);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveForceTypeResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var forceTypes = _mapper.Map<SaveForceTypeResource, ForceType>(resource);
            var result = await _forceTypeService.SaveAsync(forceTypes);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<ForceType, ForceTypeResource>(result.ForceType);
            return Ok(categoryResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveForceTypeResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var forceTypes = _mapper.Map<SaveForceTypeResource, ForceType>(resource);
            var result = await _forceTypeService.UpdateAsync(id, forceTypes);

            if (!result.Success)
                return BadRequest(result.Message);

            var forceTypesResource = _mapper.Map<ForceType, ForceTypeResource>(result.ForceType);
            return Ok(forceTypesResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _forceTypeService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<ForceType, ForceTypeResource>(result.ForceType);
            return Ok(categoryResource);
        }
        /*
        // GET: ForceTypesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ForceTypesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ForceTypesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ForceTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ForceTypesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ForceTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ForceTypesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ForceTypesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        */
    }
}
