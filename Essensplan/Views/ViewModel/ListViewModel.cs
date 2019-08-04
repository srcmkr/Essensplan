using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Essensplan.Models.Models;

namespace Essensplan.Views.ViewModel
{
    public class ListViewModel
    {
        public List<Gericht> CompleteList { get; internal set; }
    }
}
