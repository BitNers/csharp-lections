using HttpExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace HttpExample
{
    class BibliaController
    {
        private HttpClient _httpCli;
        private readonly string _uri;
        private readonly HttpMethod _method;

        public BibliaController(string Uri, HttpMethod method)
        {
            _uri = Uri;
            _method = method;
            _httpCli = new HttpClient();
        }
 

        public async Task<VersiculoModel> GetVersiculos() {
            
            using (var requisicaoHTTP = new HttpRequestMessage(_method, _uri))
            {
                VersiculoModel result = new VersiculoModel();

                requisicaoHTTP.Version = HttpVersion.Version11;

                string responseBody = "";
                using HttpResponseMessage httpResponse = _httpCli.Send(requisicaoHTTP);
                if(httpResponse.StatusCode != HttpStatusCode.OK)
                {
                    responseBody = await httpResponse.Content.ReadAsStringAsync() ?? string.Empty;
                    result = JsonConvert.DeserializeObject<VersiculoModel>(responseBody);
                    result.reference = result.error;
                    return result;
                }

                responseBody = await httpResponse.Content.ReadAsStringAsync() ?? string.Empty;
                result = JsonConvert.DeserializeObject<VersiculoModel>(responseBody);
                return result;
            }
        }
    }
}
