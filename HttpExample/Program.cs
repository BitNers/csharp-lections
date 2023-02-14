using HttpExample;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mime;

/*
    Link => https://httpbin.org/
    Site com mútliplos Endpoints para testar e praticar HTTP em código.
 */

while (true) {

    
    string versiculo = Console.ReadLine().Trim() ?? "";
    if(versiculo == string.Empty) continue;

    if (versiculo.ToLower() == "exit")
        Environment.Exit(0);

    string uri = @$"https://bible-api.com/{versiculo}?translation=almeida";
    Console.WriteLine(uri);
    BibliaController bibleController = new BibliaController(uri, HttpMethod.Get);

    var versiculos = bibleController.GetVersiculos();
    versiculos.Wait();

    Console.WriteLine(versiculos.Result.ToString());


}




HttpClient httpSync = new HttpClient();
using (var requestHTTPSync = new HttpRequestMessage(HttpMethod.Get, "https://httpbin.org/get"))
{
    requestHTTPSync.Headers.Authorization = new AuthenticationHeaderValue("bearer", "bearertoken");
    requestHTTPSync.Content = new StringContent("Fluminense e Vasco no Domingo.");

    var responseHTTP = httpSync.Send(requestHTTPSync);
    
    responseHTTP.EnsureSuccessStatusCode();

    if (responseHTTP.StatusCode != HttpStatusCode.OK)
        return;

    Console.WriteLine(responseHTTP.ToString());
    Console.WriteLine(responseHTTP.Content);
}


System.Environment.Exit(0);

async Task MakeRequest(string Uri, HttpMethod method, string body = "") {

    try
    {
        // Mais liberdade em usar Requisições (HTTP, FTP, SMTP, et cetera)
         // WebRequest request = new WebRequest();
        
        // Tenho mais liberdade em criar Requisições HTTP
        // HttpWebRequest webReq = new HttpWebRequest(Uri);
            
        HttpClient httpCli = new HttpClient();
        string requestUriGet = Uri;

        using (var requestHTTP = new HttpRequestMessage(method, requestUriGet))
        {
            if(body != string.Empty)
                requestHTTP.Content = new StringContent(body);

            // requestHTTP.Properties.Add("Content-Type", "application/json");
            requestHTTP.Version = HttpVersion.Version11;
            requestHTTP.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "tokenBom");
            

            using HttpResponseMessage httpResponse = httpCli.Send(requestHTTP);
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