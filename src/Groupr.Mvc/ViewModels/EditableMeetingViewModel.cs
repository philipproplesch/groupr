using System.Collections.Generic;
using System.Web.Mvc;

namespace Groupr.Mvc.ViewModels
{
    public class EditableMeetingViewModel
    {
        public MeetingViewModel Event { get; set; }
        public List<SelectListItem> Locations { get; set; }
    }
}