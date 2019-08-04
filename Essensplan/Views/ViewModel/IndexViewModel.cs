using System.Collections.Generic;
using Essensplan.Models.Dtos;
using Essensplan.Models.Models;

namespace Essensplan.Views.ViewModel
{
    public class IndexViewModel
    {
        public Gericht Random { get; internal set; }
        public List<Gericht> Alle { get; internal set; }
        public List<Tag> Tags { get; set; }
        public FilterSettings Filter { get; internal set; }
    }
}
