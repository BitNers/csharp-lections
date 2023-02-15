using HttpAulaPratica.Models.Bible;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;

namespace HttpAulaPratica.HttpFactory
{
    class HttpFabrica
    {
        private readonly HttpClient _httpClient;
        private string _uri;
        private readonly HttpMethod _method;
        public HttpFabrica(string uri, HttpMethod method)
        {
            _uri = uri;
            _method = method;
            _httpClient= new HttpClient();
        }

        public async Task<string> CreateRequestPostAsync(string parameters = "", BibleReferenceModel data = null) {

            if (parameters != string.Empty)
            {
                _uri += parameters;
            }

            using (HttpRequestMessage httpRequest = new HttpRequestMessage(_method, _uri))
            {

                httpRequest.Method = _method;
                httpRequest.Headers.Add("Accept", "application/json");
                httpRequest.Version = HttpVersion.Version11;
                string ObjToTxt = "{}";
                if (data != null)
                    ObjToTxt = JsonSerializer.Serialize(data);

                if(ObjToTxt != null) { httpRequest.Content = new StringContent(ObjToTxt); }
                

                HttpResponseMessage result = _httpClient.Send(httpRequest);
                if (!result.IsSuccessStatusCode) { return "Not found"; }
                if (result.Content != null)
                {
                    string ResultDataString = await result.Content.ReadAsStringAsync();
                    return ResultDataString;

                }
                return string.Empty;

            }
        }

        public async Task<BibleReferenceModel?> CreateRequestAsync(string parameters = "")
        {

            if(parameters != string.Empty)
            {
                _uri += parameters;   
            }
            

            using (HttpRequestMessage httpRequest = new HttpRequestMessage(_method, _uri))
            {
                
                httpRequest.Method = _method;
                httpRequest.Version = HttpVersion.Version11;

                HttpResponseMessage result = _httpClient.Send(httpRequest);
                if (!result.IsSuccessStatusCode) { BibleReferenceModel bible = new BibleReferenceModel{ error = "not found"}; }
                if (result.Content != null)
                {
                    string ResultDataString = await result.Content.ReadAsStringAsync();
                    BibleReferenceModel bible = JsonSerializer.Deserialize<BibleReferenceModel>(ResultDataString);
                    return bible;
                    
                    
                }
                return null;

            }

        }

    }
}
