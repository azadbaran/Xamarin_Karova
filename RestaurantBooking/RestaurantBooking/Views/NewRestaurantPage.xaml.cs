using System;

using RestaurantBooking.Models;

using Xamarin.Forms;

namespace RestaurantBooking.Views
{
	public partial class NewRestaurantPage : ContentPage
	{
		public Restaurant Item { get; set; }

		public NewRestaurantPage()
		{
			InitializeComponent();

			Item = new Restaurant();

			BindingContext = this;
		}

		async void Save_Clicked(object sender, EventArgs e)
		{
			MessagingCenter.Send(this, "AddRestaurant", Item);
			await Navigation.PopToRootAsync();
		}
    }
}