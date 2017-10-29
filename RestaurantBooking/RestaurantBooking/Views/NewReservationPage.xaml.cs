using System;

using RestaurantBooking.Models;

using Xamarin.Forms;

namespace RestaurantBooking.Views
{
    public partial class NewReservationPage : ContentPage
    {
        public Reservation Item { get; set; }

        public NewReservationPage()
        {
            InitializeComponent();

            Item = new Reservation();

            BindingContext = this;
        }
        
        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddReservation", Item);
            await Navigation.PopAsync();
        }
    }
}
