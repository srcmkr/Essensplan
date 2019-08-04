using System;
using System.Collections.Generic;

namespace Essensplan.Models.Dtos
{
    public class FilterSettings
    {
        public List<Guid> SelectedTags { get; set; }
        public int DayStart { get; set; }
        public int DayEnd { get; set; }
    }
}
