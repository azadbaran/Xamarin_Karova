using System;

using RestaurantBooking.Models;
using RestaurantBooking.ViewModels;

using Xamarin.Forms;

namespace RestaurantBooking.Views
{
	public partial class RestaurantsPage : ContentPage
	{
		RestaurantsViewModel viewModel;

		public RestaurantsPage()
		{
			InitializeComponent();

			BindingContext = viewModel = new RestaurantsViewModel();
		}

		async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			var item = args.SelectedItem as Restaurant;
			if (item == null)
				return;

			await Navigation.PushAsync(new RestaurantsDetailPage(new RestaurantDetailViewModel(item)));

			// Manually deselect item
			ItemsListView.SelectedItem = null;
		}

		async void AddItem_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NewRestaurantPage());
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (viewModel.Items.Count == 0)
				viewModel.LoadItemsCommand.Execute(null);
		}
	}
}
