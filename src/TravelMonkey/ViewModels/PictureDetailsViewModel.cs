using System.Collections.Generic;
using System.Linq;
using TravelMonkey.Data;
using TravelMonkey.Models;
using TravelMonkey.Services;
using Xamarin.Forms;

namespace TravelMonkey.ViewModels
{
    public class PictureDetailsViewModel : BaseViewModel
    {
        private readonly FaceService _faceService = new FaceService();

        private bool _isDetecting;
        public bool IsDetecting
        {
            get => _isDetecting;
            set => Set(ref _isDetecting, value);
        }

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
            IsDetecting = true;
            try
            {
                var res = await _faceService.AnalyseFaces(((UriImageSource)Picture.Image).Uri);
                if (res.ErrorMessage != null)
                {
                    MessagingCenter.Send(this, Constants.DetectFacesFailed);
                } else
                {
                    res.FacesItems.ForEach((d) => d.Source = Picture.Image);
                    MessagingCenter.Send<PictureDetailsViewModel,FacesResult>(this, Constants.DetectFacesSuccess,res);

                }

            }
            finally
            {
                IsDetecting = false;
            }
        }

        public Command DetectFacesCommand { get; }
    }
}
