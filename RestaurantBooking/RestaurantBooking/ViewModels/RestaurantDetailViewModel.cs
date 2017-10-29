using System;
using System.Diagnostics;
using System.Threading.Tasks;

using RestaurantBooking.Helpers;
using RestaurantBooking.Models;
using RestaurantBooking.Views;

using Xamarin.Forms;

namespace RestaurantBooking.ViewModels
{
	public class RestaurantDetailViewModel : RestaurantBaseViewModel
	{
		public Restaurant Item { get; set; }
        public Command LoadRestaurantReservationsCommand { get; set; }

        public RestaurantDetailViewModel(Restaurant item = null)
		{
			Title = item.Text;
			Item = item;
            LoadRestaurantReservationsCommand = new Command(async () => await ExecuteReservationsCommand());

            MessagingCenter.Subscribe<NewReservationPage, Reservation>(this, "AddReservation", async (obj, reservation) =>
            {
                var _reservation = reservation as Reservation;
                Item.Reservations.Add(_reservation);
                //await DataStore.AddItemAsync(_reservation);
            });
        }

		int quantity = 1;
		public int Quantity
		{
			get { return quantity; }
			set { SetProperty(ref quantity, value); }
		}

        async Task ExecuteReservationsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
               // Items.Clear();
               // var items = await DataStore.GetItemsAsync(true);
               // Items.ReplaceRange(items);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load items.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}