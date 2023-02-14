using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HttpExample.Models.ValueObjects;

namespace HttpExample.Models
{
    class VersiculoModel
    {
        public string reference { get; set; }
        public ICollection<VerseModel> verses { get; set; }
        public string text { get; set; }
        public string translation_id { get; set; }
        public string translation_name { get; set; }
        public string translation_note { get; set; }

        public string error { get; set; }


        
        public override string ToString() {
            string rt = string.Empty;
            foreach (var verse in verses) {
                rt += $"\t [{verse.book_name} {verse.chapter}:{verse.verse}]: '{verse.text.Trim()}'\n".Trim();
                rt += "\n";
            }
            return rt.Trim();
        }

    }
}
