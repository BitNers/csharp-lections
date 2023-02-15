using HttpAulaPratica.HttpFactory;
using HttpAulaPratica.Models.Bible;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpAulaPratica.Repositorio.HttpBin
{
    class HttpBinRepo : IHttpBinRepo
    {
        private readonly HttpFabrica _httpFabrica;
        public HttpBinRepo(string uri, HttpMethod method)
        {
            _httpFabrica = new HttpFabrica(uri, method);
        }

        public string SendData(BibleReferenceModel data)
        {
            var httpResponse = _httpFabrica.CreateRequestPostAsync("", data);
            httpResponse.Wait();


            return httpResponse.Result ?? "";
        }
    }
}
