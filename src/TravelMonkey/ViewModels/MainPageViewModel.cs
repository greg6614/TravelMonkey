using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Timers;
using TravelMonkey.Data;
using TravelMonkey.Models;
using TravelMonkey.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TravelMonkey.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly Timer _slideShowTimer = new Timer(5000);
        private readonly AzureStorageService _storageService = new AzureStorageService();

        public List<Destination> Destinations => MockDataStore.Destinations;
        public ObservableCollection<PictureEntry> Pictures => MockDataStore.Pictures;

        private Destination _currentDestination;
        public Destination CurrentDestination
        {
            get => _currentDestination;
            set => Set(ref _currentDestination, value);
        }

        public Command<string> PictureCommand { get; }

        public Command<string> OpenUrlCommand { get; } = new Command<string>(async (url) =>
        {
            if (!string.IsNullOrWhiteSpace(url))
                await Browser.OpenAsync(url, options: new BrowserLaunchOptions
                {
                    Flags = BrowserLaunchFlags.PresentAsFormSheet,
                    PreferredToolbarColor = Color.SteelBlue,
                    PreferredControlColor = Color.White
                });
        });

        public MainPageViewModel()
        {
            _storageService.GetAllBlobs();
            if (Destinations.Count > 0)
            {
                CurrentDestination = Destinations[0];

                _slideShowTimer.Elapsed += (o, a) =>
                {
                    var currentIdx = Destinations.IndexOf(CurrentDestination);

                    if (currentIdx == Destinations.Count - 1)
                        CurrentDestination = Destinations[0];
                    else
                        CurrentDestination = Destinations[currentIdx + 1];
                };
            }

            PictureCommand = new Command<string>((desc) => 
            { 
                MessagingCenter.Send<MainPageViewModel, string>(this, Constants.PictureDetail, desc); 
            });
        }

        public void StartSlideShow()
        {
            _slideShowTimer.Start();
            
        }
        public void StopSlideShow()
        {
            _slideShowTimer.Stop();
        }
    }
}