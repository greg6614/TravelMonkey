
using System;
using TravelMonkey.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelMonkey.UserControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmotionsView : Grid
    {
        public EmotionsView()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty FaceAttributesProperty = BindableProperty.Create("FaceAttributes", typeof(FaceAttributes), typeof(EmotionsView), propertyChanged: OnFaceAttributesChanged);
        public static readonly BindableProperty AgeProperty = BindableProperty.Create("Age", typeof(int), typeof(EmotionsView));
        public static readonly BindableProperty GenderProperty = BindableProperty.Create("Gender", typeof(string), typeof(EmotionsView));


        public FaceAttributes FaceAttributes
        {
            get => GetValue(FaceAttributesProperty) as FaceAttributes;
            set => SetValue(FaceAttributesProperty, value);
        }

        private static void OnFaceAttributesChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var newAttributes = newValue as FaceAttributes;
            
            foreach (var prop in newAttributes.emotion.GetType().GetProperties())
            {
                var val = (float)prop.GetValue(newAttributes.emotion);
                if (val >= 0.3F)
                {
                    var img = new Image();
                    img.WidthRequest = 40;
                    img.Margin = new Thickness(5, 0, 5, 0);
                    switch (prop.Name)
                    {
                        case "anger":
                            {
                                img.Source = "angry.png";
                                break;
                            }
                        case "happiness":
                            {
                                if (val <= 0.5F)
                                {
                                    img.Source = "happy.png";
                                }
                                else
                                {
                                    img.Source = "happy.png";
                                }

                                break;
                            }
                        case "neutral":
                            {
                                img.Source = "neutral.png";
                                break;
                            }
                        case "sadness":
                            {
                                img.Source = "sad.png";
                                break;
                            }
                        case "surprise":
                            {
                                img.Source = "surprised.png";
                                break;
                            }
                    }
                    var control = bindable as EmotionsView;
                    control.AgeTxt.Text = "Age : " + newAttributes.age.ToString();
                    control.GenderImg.Source = newAttributes.gender.ToLower().Equals("female") ? "female.png" : "male.png";
                    control.EmotionsLayout.Children.Add(img);
                }
            }
        }
    }
}