using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TravelMonkey.Models
{
    public class FacesResult
    {
        public List<FaceDetection> FacesItems { get; set; }
        public ImageSource ImageSource { get; set; }
        public string ErrorMessage { get; set; }
    }
}
