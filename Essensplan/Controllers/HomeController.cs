using Essensplan.Models.Dtos;
using Essensplan.Services;
using Essensplan.Views.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Essensplan.Controllers
{
    public class HomeController : Controller
    {
        public GerichtService GerichtService { get; set; }
        public TagService TagService { get; set; }

        public HomeController()
        {
            GerichtService = new GerichtService();
            TagService = new TagService();
        }

        public IActionResult Index()
        {
            var liste = GerichtService.All();

            var vm = new IndexViewModel
            {
                Random = GerichtService.Random(),
                Alle = liste,
                Tags = TagService.All(),
                Filter = new FilterSettings()
            };

            return View(vm);
        }
    }
}
