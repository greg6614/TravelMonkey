using System;
using System.Collections.Generic;
using System.Text;

namespace TravelMonkey.Models
{
    public class AzureBlobResult
    {
        public Uri Uri { get; set; }
        public bool Success => Uri != null;

        public AzureBlobResult() { }

        public AzureBlobResult(Uri uri)
        {
            Uri = uri;
        }
    }
}
