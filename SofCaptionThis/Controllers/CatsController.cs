using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SofCaptionThis.Models;
using SofCaptionThis.Services.Implementation;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace SofCaptionThis.Controllers
{
    public class CatsController : Controller
    {
        private readonly ICatsService _catsService;
        private readonly IMapper _mapper;
        public CatsController(ICatsService catsService, IMapper mapper)
        {
            _catsService = catsService;
            _mapper = mapper;
        }
        public async Task<ActionResult> Index()
        {
            var catData = await _catsService.GetCat();

            var cat = _mapper.Map<CatViewModel>(catData);

            return View(cat);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Caption(string id)
        {
            var catData = await _catsService.GetCatById(id);
            var cat = _mapper.Map<CatViewModel>(catData);

            return View(cat);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Caption(CatViewModel cat)
        {
            try
            {
                var path = "D:\\json.txt";
                string json = JsonConvert.SerializeObject(cat);
                System.IO.File.WriteAllText($@"{path}", json);

                return Json(new { success = true, responseText = $"The json file has been downloaded to {path}." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = "There has been an error." });
            }
        }
    }
}
