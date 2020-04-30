using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelMonkey.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetectFacesPages : ContentPage
    {
        public DetectFacesPages()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }

    }
}