using System.Collections.Generic;

namespace RestaurantBooking.Models
{
    public class Restaurant : BaseDataObject
    {
        string text = string.Empty;
        public string Text
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }

        string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        List<Reservation> reservations = new List<Reservation>();
        public List<Reservation> Reservations
        {
            get { return reservations; }
            set { reservations = value; }
        }
    }
}
