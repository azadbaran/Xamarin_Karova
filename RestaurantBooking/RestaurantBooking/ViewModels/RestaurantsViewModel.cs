using System;
using System.Diagnostics;
using System.Threading.Tasks;

using RestaurantBooking.Helpers;
using RestaurantBooking.Models;
using RestaurantBooking.Views;

using Xamarin.Forms;

namespace RestaurantBooking.ViewModels
{
	public class RestaurantsViewModel : RestaurantBaseViewModel
	{
		public ObservableRangeCollection<Restaurant> Items { get; set; }
		public Command LoadItemsCommand { get; set; }

		public RestaurantsViewModel()
		{
			Title = "Browse";
			Items = new ObservableRangeCollection<Restaurant>();
			LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

			MessagingCenter.Subscribe<NewRestaurantPage, Restaurant>(this, "AddRestaurant", async (obj, item) =>
			{
				var _item = item as Restaurant;
				Items.Add(_item);
				await DataStore.AddItemAsync(_item);
			});
		}

		async Task ExecuteLoadItemsCommand()
		{
			if (IsBusy)
				return;

			IsBusy = true;

			try
			{
				Items.Clear();
				var items = await DataStore.GetItemsAsync(true);
				Items.ReplaceRange(items);
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