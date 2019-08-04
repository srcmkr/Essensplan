using Essensplan.Models.Models;
using Essensplan.Services;
using Essensplan.Views.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Essensplan.Controllers
{
    public class GerichteController : Controller
    {
        public GerichtService GerichtService { get; set; }
        public TagService TagService { get; set; }

        public GerichteController()
        {
            GerichtService = new GerichtService();
            TagService = new TagService();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var liste = GerichtService.All();

            var vm = new GerichtServiceIndexViewModel
            {
                Alle = liste
            };

            return View(vm);
        }

        [HttpGet]
        public IActionResult Delete(Guid guid)
        {
            GerichtService.Delete(guid);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            var vm = new CreateEditViewModel
            {
                Gericht = new Gericht(),
                AvailableTags = TagService.All()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(CreateEditViewModel vm)
        {
            var tags = TagService.All();
            var newGericht = vm.Gericht;
            newGericht.Tags = new List<Tag>();

            if (vm.SelectedTagGuids != null)
            {
                foreach (var tagGuid in vm.SelectedTagGuids)
                {
                    if (tags.Single(c => c.Guid == tagGuid) != null)
                        newGericht.Tags.Add(tags.Single(c => c.Guid == tagGuid));
                }
            }
            
            GerichtService.Create(newGericht);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid guid)
        {
            var dbEntry = GerichtService.Single(guid);
            if (dbEntry == null)
                return RedirectToAction("Index");

            var vm = new CreateEditViewModel
            {
                Gericht = dbEntry,
                AvailableTags = TagService.All()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(CreateEditViewModel vm)
        {
            var tags = TagService.All();
            var newGericht = vm.Gericht;
            newGericht.Tags = new List<Tag>();

            if (vm.SelectedTagGuids != null)
            {
                foreach (var tagGuid in vm.SelectedTagGuids)
                {
                    if (tags.Single(c => c.Guid == tagGuid) != null)
                        newGericht.Tags.Add(tags.Single(c => c.Guid == tagGuid));
                }
            }

            GerichtService.Update(newGericht);
            return RedirectToAction("Index");
        }
    }
}