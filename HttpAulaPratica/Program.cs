using HttpAulaPratica.Repositorio.Bible;
using HttpAulaPratica.Repositorio.HttpBin;

while (true) {

    string capitulo = Console.ReadLine().Trim() ?? "";
    if (capitulo == string.Empty) { continue; }

    /*
        1. Aplicação Recebe Parametros para Ler os Versiculos da Biblia (https://bible-api.com/BOOK+CHAPTER:VERSE)
        2. Nosso BibleRepo irá chamar a Fábrica de HTTP para puxar os dados do capítulo requisitado.
        3. Depois, nosso HttpBinRepo irá Serializar o Objeto retornado da API da Biblia
        4. Enviará um POST para ver os dados ecoados na resposta HTTP.
     */

    var bibleControllerGet = new BibleRepo("https://bible-api.com/",HttpMethod.Get);
    var bibleResult = bibleControllerGet.GetVerses(capitulo);

    bibleResult.text += "**";

    Console.WriteLine(bibleResult.ToString());
    // var dataToSend = bibleResult.ToString();

    var httpBinControllerPost = new HttpBinRepo("https://httpbin.org/post", HttpMethod.Post);

    var HttpBinResponse = httpBinControllerPost.SendData(bibleResult);
    
    
    Console.WriteLine(HttpBinResponse);
    
}