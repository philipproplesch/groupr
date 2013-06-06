using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Groupr.Core.Models;
using Groupr.Core.Repositories.Common;
using Groupr.Mvc.ViewModels;

namespace Groupr.Mvc.Areas.Admin.Controllers
{
    [Authorize(Roles = "Leader")]
    public class LocationController : Controller
    {
        private readonly ILocationRepository _repository;

        public LocationController(ILocationRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var locations = _repository.GetLocations();
            var model = Mapper.Map<List<Location>, List<LocationViewModel>>(locations);

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(LocationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var location = Mapper.Map<LocationViewModel, Location>(model);
            if (_repository.CreateLocation(location))
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}