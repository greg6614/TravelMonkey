using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelMonkey.Data;
using TravelMonkey.Models;
using TravelMonkey.Services;
using Xamarin.Forms;

namespace TravelMonkey.ViewModels
{
    public class PictureDetailsViewModel
    {
        private readonly FaceService _faceService = new FaceService();

        public PictureEntry Picture { get; set; }

        public PictureDetailsViewModel(string id)
        {
            Picture = MockDataStore.Pictures.FirstOrDefault((p) => p.Id.Equals(id));
            DetectFacesCommand = new Command(DetectFaces);
        }

        private async void DetectFaces(object obj)
        {
            if (!(Picture.Image is UriImageSource))
            {
                MessagingCenter.Send(this, Constants.CannotDetectFaces);
                return;
            }
            await _faceService.AnalyseFaces(((UriImageSource)Picture.Image).Uri);
        }

        public Command DetectFacesCommand { get; }
    }
}
