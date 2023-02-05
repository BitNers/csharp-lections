
using System.Net.Mime;

/*
    Link => https://httpbin.org/
    Site com mútliplos Endpoints para testar e praticar HTTP em código.
 */

async Task MakeGetRequestAsync(string Uri, HttpMethod method) {

    try
    {
        HttpClient httpCli = new HttpClient();
        string requestUriGet = Uri;

        using (var requestHTTP = new HttpRequestMessage(method, requestUriGet))
        {

            requestHTTP.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "tokenBom");
            requestHTTP.Method = HttpMethod.Get;

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
        Console.WriteLine($"Erro: {ex.Message.ToString()} ");
    }
}


await MakeGetRequestAsync("https://httpbin.org/status/500", HttpMethod.Get);
await MakeGetRequestAsync("https://httpbin.org/status/200", HttpMethod.Get);
await MakeGetRequestAsync("https://httpbin.org/get", HttpMethod.Get);