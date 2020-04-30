namespace TravelMonkey
{
	public static class ApiKeys
	{
        #warning You need to set up your API keys.
		public static string ComputerVisionApiKey = "";
		public static string TranslationsApiKey = "";
		public static string BingImageSearch = "";

		// Change this to the Azure Region you are using
		public static string ComputerVisionEndpoint = "https://westeurope.api.cognitive.microsoft.com/";
		public static string TranslationsEndpoint = "https://api.cognitive.microsofttranslator.com/";
		public static string AzureFunctionFacesEndpoint = "https://visageapi.azurewebsites.net/api/VisageDetectionTrigger?code=TAa/wbg57Wu5vnQG/rrRfaMIzmSlC/CJn0MK7z1lNK11G5BrK3PwSg==";
		#warning Set your Azure Blob Storage connection string to use Face API through Azure function.
		public static string AzureBlobStorageConnectionString = "";
	}
}