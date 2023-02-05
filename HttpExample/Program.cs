
using System.Net.Mime;

/*
    Link => https://httpbin.org/
    Site com mútliplos Endpoints para testar e praticar HTTP em código.
 */


async Task MakeRequest(string Uri, HttpMethod method, string body = "") {

    try
    {
        HttpClient httpCli = new HttpClient();
        string requestUriGet = Uri;

        using (var requestHTTP = new HttpRequestMessage(method, requestUriGet))
        {
            if(body != string.Empty)
                requestHTTP.Content = new StringContent(body);

            requestHTTP.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "tokenBom");
            

            using HttpResponseMessage httpResponse = await httpCli.SendAsync(requestHTTP);
            httpResponse.EnsureSuccessStatusCode();

            /*
                Podemos verificar manualmente
                if (httpResponse.StatusCode != System.Net.HttpStatusCode.OK) return;
            */

            string responseBody = await httpResponse.Content.ReadAsStringAsync() ?? string.Empty;
            if (responseBody == string.Empty) responseBody = "Null Body";
            Console.WriteLine(responseBody);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro: {ex.Message} ");
    }
}


await MakeRequest("https://httpbin.org/status/500", HttpMethod.Get);
await MakeRequest("https://httpbin.org/status/200", HttpMethod.Get);
await MakeRequest("https://httpbin.org/get", HttpMethod.Get);


await MakeRequest("https://httpbin.org/post", HttpMethod.Post, "Dados enviado, possivelmente serializado!");