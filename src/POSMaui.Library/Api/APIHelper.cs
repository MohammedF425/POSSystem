using System;
namespace POSMaui.Library.Api
{
	public class APIHelper : IAPIHelper
	{
		private HttpClient _apiClient;
		public HttpClient ApiClient => _apiClient;

		public APIHelper()
		{
			InitializeClient();
		}

		public void InitializeClient()
		{
			string api = "http://localhost:5206";

            _apiClient = new HttpClient();
			_apiClient.BaseAddress = new Uri(api);
			_apiClient.DefaultRequestHeaders.Accept.Clear();
			_apiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
		}
	}
}

