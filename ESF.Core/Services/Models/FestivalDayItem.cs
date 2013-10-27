using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESF.Commons.Utilities;

namespace ESF.Core.Services.Models
{
    public class FestivalDayItem
    {
        public FestivalDayItem(Guid festivalDayId, DateTime date)
        {
            FestivalDayId = festivalDayId;
            DisplayDate = date.GetUserFriendlyDate();
        }

        public Guid FestivalDayId { get; private set; }
        public string DisplayDate { get; private set; }
    }
}
