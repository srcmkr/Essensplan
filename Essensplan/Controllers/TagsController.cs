using Essensplan.Models.Models;
using Essensplan.Services;
using Essensplan.Views.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Essensplan.Controllers
{
    public class TagsController : Controller
    {
        public TagService TagService { get; set; }

        public TagsController()
        {
            TagService = new TagService();
        }

        public IActionResult Index()
        {
            var vm = new TagIndexViewModel
            {
                AllTags = TagService.All()
            };

            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var vm = new TagCreateEditViewModel
            {
                Tag = new Tag()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(Tag tag)
        {
            TagService.Create(tag);
            return RedirectToAction("Index");
        }
    }
}
