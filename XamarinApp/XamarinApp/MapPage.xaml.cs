﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace XamarinApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
		public MapPage ()
		{
			InitializeComponent ();

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                case Device.Android:
                    mapImage.Source = (ImageSource)ImageSource.FromFile("map.png");
                    break;
                case Device.UWP:
                    mapImage.Source = (ImageSource)ImageSource.FromFile("Images/map.png");
                    break;
                default:
                    break;
            }
        }

        private async void OpenLocation_Clicked(object sender, EventArgs e)
        {
            if (!double.TryParse(latText.Text, out double lat))
            {
                latError.Text = "Latitude must be Numeric value";
                latError.TextColor = Color.Red;
                latError.FontAttributes = FontAttributes.Bold;
                return;
            }
            else
            {
                latError.Text = "";
            }

            if (!double.TryParse(lngText.Text, out double lng))
            {
                lngError.Text = "Longitude must be Numeric value";
                lngError.TextColor = Color.Red;
                lngError.FontAttributes = FontAttributes.Bold;
                return;
            }
            else
            {
                lngError.Text = "";
            }

            await Xamarin.Essentials.Map.OpenAsync(lat, lng, new MapLaunchOptions
            {

                NavigationMode = NavigationMode.None
            });
        }

        private async void GetLocation_Clicked(object sender, EventArgs e)
        {
            try
            {

                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    latError.Text = "";
                    latText.Text = location.Latitude.ToString();
                    lngText.Text = location.Longitude.ToString();
                }
            }
            catch (Exception ex)
            {
                // Handle not supported on device exception
                //Console.WriteLine(ex.ToString());
                latError.FontAttributes = FontAttributes.Bold;
                latError.Text = "Try turning on your location";
            }

        }

        private async void CancelClicked_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}