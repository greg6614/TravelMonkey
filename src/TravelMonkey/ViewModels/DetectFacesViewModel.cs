using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TravelMonkey.Models;
using Xamarin.Forms;

namespace TravelMonkey.ViewModels
{
    public class DetectFacesViewModel : BaseViewModel
    {

        public DetectFacesViewModel(FacesResult data)
        {
            Faces = new ObservableCollection<FaceDetection>(data.FacesItems);
        }
        public ObservableCollection<FaceDetection> Faces { get; set; }
    }
}
