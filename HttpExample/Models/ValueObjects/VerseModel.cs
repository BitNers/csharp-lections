using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpExample.Models.ValueObjects
{
    class VerseModel
    {
        public string book_id{ get; set; }
        public string book_name { get; set; }
        public int chapter { get; set; }
        public int verse { get; set; }
        public string text { get; set; }
    }
}
