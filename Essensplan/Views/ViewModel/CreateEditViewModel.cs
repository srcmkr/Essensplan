using Essensplan.Models.Models;
using System;
using System.Collections.Generic;

namespace Essensplan.Views.ViewModel
{
    public class CreateEditViewModel
    {
        public Gericht Gericht { get; set; }
        public List<Guid> SelectedTagGuids { get; set; }
        public List<Tag> AvailableTags { get; set; }
    }
}
