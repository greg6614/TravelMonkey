using Azure.Storage.Blobs;
using Plugin.Media.Abstractions;
using System;
using System.Threading.Tasks;
using TravelMonkey.Data;
using TravelMonkey.Models;
using Xamarin.Forms;

namespace TravelMonkey.Services
{
    public class AzureStorageService
    {

        public async Task<AzureBlobResult> PerformBlobOperation(MediaFile content)
        {
            try
            {
                var client = InitConnection();

                var blobClient = client.GetBlobClient(content.Path.Substring(content.Path.LastIndexOf("/") + 1));
                await blobClient.UploadAsync(content.GetStream());
                return new AzureBlobResult(blobClient.Uri);
            }
            catch
            {
                return new AzureBlobResult();
            }
            
        }

        public void GetAllBlobs()
        {
            try
            {
                var client = InitConnection();
                foreach (var blobItem in client.GetBlobs())
                {
                    var uri = client.GetBlobClient(blobItem.Name).Uri;
                    MockDataStore.Pictures.Add(new PictureEntry { Id = Guid.NewGuid().ToString(), Description = string.Empty, Image = ImageSource.FromUri(uri) });
                }
            } catch
            {

            }
            
        }

        private BlobContainerClient InitConnection()
        {
            var BlobServiceClient = new BlobServiceClient(ApiKeys.AzureBlobStorageConnectionString);
            return BlobServiceClient.GetBlobContainerClient("pictures");
        }
    }
}
