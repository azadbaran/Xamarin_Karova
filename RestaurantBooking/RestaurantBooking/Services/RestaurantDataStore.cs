using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using RestaurantBooking.Models;

using Xamarin.Forms;

[assembly: Dependency(typeof(RestaurantBooking.Services.RestaurantDataStore))]
namespace RestaurantBooking.Services
{
	public class RestaurantDataStore : IDataStore<Restaurant>
	{
		bool isInitialized;
		List<Restaurant> items;

		public async Task<bool> AddItemAsync(Restaurant item)
		{
			await InitializeAsync();

			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> UpdateItemAsync(Restaurant item)
		{
			await InitializeAsync();

			var _item = items.Where((Restaurant arg) => arg.Id == item.Id).FirstOrDefault();
			items.Remove(_item);
			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> DeleteItemAsync(Restaurant item)
		{
			await InitializeAsync();

			var _item = items.Where((Restaurant arg) => arg.Id == item.Id).FirstOrDefault();
			items.Remove(_item);

			return await Task.FromResult(true);
		}

		public async Task<Restaurant> GetItemAsync(string id)
		{
			await InitializeAsync();

			return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
		}

		public async Task<IEnumerable<Restaurant>> GetItemsAsync(bool forceRefresh = false)
		{
			await InitializeAsync();

			return await Task.FromResult(items);
		}

		public Task<bool> PullLatestAsync()
		{
			return Task.FromResult(true);
		}


		public Task<bool> SyncAsync()
		{
			return Task.FromResult(true);
		}

		public async Task InitializeAsync()
		{
			if (isInitialized)
				return;

            items = new List<Restaurant>();

            // TODO Load Elements Here

            //var _items = new List<Restaurant>
            //{
            //	new Restaurant { Id = Guid.NewGuid().ToString(), Text = "Buy some cat food", Description="The cats are hungry"},
            //	new Restaurant { Id = Guid.NewGuid().ToString(), Text = "Learn F#", Description="Seems like a functional idea"},
            //	new Restaurant { Id = Guid.NewGuid().ToString(), Text = "Learn to play guitar", Description="Noted"},
            //	new Restaurant { Id = Guid.NewGuid().ToString(), Text = "Buy some new candles", Description="Pine and cranberry for that winter feel"},
            //	new Restaurant { Id = Guid.NewGuid().ToString(), Text = "Complete holiday shopping", Description="Keep it a secret!"},
            //	new Restaurant { Id = Guid.NewGuid().ToString(), Text = "Finish a todo list", Description="Done"},
            //};

            //foreach (Restaurant item in _items)
            //{
            //	items.Add(item);
            //}

            isInitialized = true;
		}
	}
}
