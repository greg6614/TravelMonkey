using System;
using TravelMonkey.ViewModels;
using Xamarin.Forms;

namespace TravelMonkey.Views
{
    public partial class AddPicturePage : ContentPage
    {
        public AddPicturePage()
        {
            InitializeComponent();

            BindingContext = new AddPicturePageViewModel();

            MessagingCenter.Subscribe<AddPicturePageViewModel>(this, Constants.PictureAddedMessage, async (vm) => await Navigation.PopModalAsync(true));

            MessagingCenter.Subscribe<AddPicturePageViewModel>(this, Constants.PictureFailedMessage, async (vm) => await DisplayAlert("Uh-oh!", "Can you hand me my glasses? Something went wrong while analyzing this image", "OK"));
            MessagingCenter.Subscribe<AddPicturePageViewModel>(this, Constants.NoPictureSelected, async (vm) => await DisplayAlert("Uh-oh!", "Please select a picture before", "OK"));
            MessagingCenter.Subscribe<AddPicturePageViewModel>(this, Constants.AzureBlobFail, async (vm) => await DisplayAlert("Uh-oh! A monkey unplug the cable!", "Unable to connect to Azure Blob. Your images will not persist accross app's reboots.", "OK"));
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}