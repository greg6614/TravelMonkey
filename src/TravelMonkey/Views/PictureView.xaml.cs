using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelMonkey.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelMonkey.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PictureView : ContentPage
    {
        public PictureView()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<PictureDetailsViewModel>(this,Constants.CannotDetectFaces, async (vm) => await DisplayAlert("Uh-oh!", "Can't detect faces. Please enable Azure Blob Storage first.", "OK"));
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }
    }
}