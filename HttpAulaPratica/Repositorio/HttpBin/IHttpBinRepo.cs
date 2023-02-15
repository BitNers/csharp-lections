using HttpAulaPratica.Models.Bible;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpAulaPratica.Repositorio.HttpBin
{
    interface IHttpBinRepo
    {
        string SendData(BibleReferenceModel data);
    }
}
