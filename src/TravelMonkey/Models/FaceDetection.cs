using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TravelMonkey.Models
{
    public class FaceDetection
    {
        public FaceRectangle faceRectangle { get; set; }
        public FaceAttributes faceAttributes { get; set; }
        public ImageSource Source { get; set; }
    }
}
