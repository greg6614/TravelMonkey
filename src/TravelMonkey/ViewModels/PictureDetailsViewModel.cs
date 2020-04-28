using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelMonkey.Data;
using TravelMonkey.Models;

namespace TravelMonkey.ViewModels
{
    public class PictureDetailsViewModel
    {

        public PictureEntry Picture { get; set; }

        public PictureDetailsViewModel(string id)
        {
            Picture = MockDataStore.Pictures.FirstOrDefault((p) => p.Id.Equals(id));
        }
    }
}
