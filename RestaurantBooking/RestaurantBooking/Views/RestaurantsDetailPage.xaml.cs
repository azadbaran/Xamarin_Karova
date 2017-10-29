using System;

using RestaurantBooking.ViewModels;

using Xamarin.Forms;

namespace RestaurantBooking.Views
{
	public partial class RestaurantsDetailPage : ContentPage
	{
		RestaurantDetailViewModel viewModel;
        
        public RestaurantsDetailPage()
        {
            InitializeComponent();
        }

        public RestaurantsDetailPage(RestaurantDetailViewModel viewModel)
		{
			InitializeComponent();

			BindingContext = this.viewModel = viewModel;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Item.Reservations.Count == 0)
                viewModel.LoadRestaurantReservationsCommand.Execute(null);
        }

        async void AddReservation_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewReservationPage());
        }
    }
}
