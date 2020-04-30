using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelMonkey.Data;
using TravelMonkey.Models;
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
            MessagingCenter.Subscribe<PictureDetailsViewModel>(this,Constants.DetectFacesFailed, async (vm) => await DisplayAlert("Uh-oh!", "Oops, we put a blind monkey on this. He can't detect faces.", "OK"));
            MessagingCenter.Subscribe<PictureDetailsViewModel,FacesResult>(this,Constants.DetectFacesSuccess, (vm,res) => OnFaceDetected(res));
        }

        private void OnFaceDetected(FacesResult data)
        {
            var page = new DetectFacesPages();
            var vm = new DetectFacesViewModel(data);
            page.BindingContext = vm;
            Navigation.PushModalAsync(page);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }
    }
}