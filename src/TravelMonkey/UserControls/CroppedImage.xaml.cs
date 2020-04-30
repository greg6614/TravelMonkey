using ImageCircle.Forms.Plugin.Abstractions;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using TravelMonkey.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelMonkey.UserControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CroppedImage : CircleImage
    {
        HttpClient httpClient = new HttpClient();

        public CroppedImage()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty DataProperty = BindableProperty.Create("Data", typeof(FaceDetection), typeof(CroppedImage), propertyChanged: DataChanged);

        public FaceDetection Data {
            get => GetValue(DataProperty) as FaceDetection;
            set => SetValue(DataProperty, value);
        }

        private async static void DataChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as CroppedImage;
            SKBitmap bitmap = null;
            var newData = newValue as FaceDetection;
            if (newData.Source != null)
            {
                bitmap = await control.GetImage();
                control.OnDataChanged(bitmap);
            }
        }


        private void OnDataChanged(SKBitmap bitmap)
        {

            if (Data.faceRectangle != null && bitmap != null)
            {
                int left, top, right, bottom;
                left = Data.faceRectangle.left;
                top = Data.faceRectangle.top;

                right = Data.faceRectangle.left + Data.faceRectangle.width;
                bottom = Data.faceRectangle.top + Data.faceRectangle.height;

                SKRectI cropRect = new SKRectI(left, top, right, bottom);
                cropRect.Inflate(30, 30);
                SKBitmap cropped = new SKBitmap();
                SKBitmap scaled = new SKBitmap(100, 100);
                bitmap.ExtractSubset(cropped, cropRect);
                cropped.ScalePixels(scaled, SKFilterQuality.High);
                circle.Source = new SKBitmapImageSource { Bitmap = scaled };
            }
        }

        private async Task<SKBitmap> GetImage()
        {
            string url = (Data.Source as UriImageSource).Uri.OriginalString;

            try
            {
                using (Stream stream = await httpClient.GetStreamAsync(url))
                using (MemoryStream memStream = new MemoryStream())
                {
                    await stream.CopyToAsync(memStream);
                    memStream.Seek(0, SeekOrigin.Begin);

                    return SKBitmap.Decode(memStream);
                };
            }
            catch
            {
                return null;
            }
        }
    }
}