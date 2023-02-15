using HttpAulaPratica.HttpFactory;
using HttpAulaPratica.Models.Bible;

namespace HttpAulaPratica.Repositorio.Bible
{
    class BibleRepo : IBibleRepo
    {
        private readonly HttpFabrica _httpFabrica;
        public BibleRepo(string uri, HttpMethod method)
        {
            _httpFabrica = new HttpFabrica(uri, method);
        }

        public BibleReferenceModel GetVerses(string param = "")
        {
            var resultHTTP = _httpFabrica.CreateRequestAsync(param + "?translation=almeida");
            resultHTTP.Wait();

            return resultHTTP.Result ?? new BibleReferenceModel();
        }
    }
}
