using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantBooking.Models
{
    public class Reservation : BaseDataObject
    {
        DateTime time;
        public DateTime Time
        {
            get { return time; }
            set { SetProperty(ref time, value); }
        }

        string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }
    }
}
