
using HttpAulaPratica.Models.Bible;


namespace HttpAulaPratica.Repositorio.Bible
{
    interface IBibleRepo
    {
        BibleReferenceModel GetVerses(string param = "");
    }
}
