using HttpAulaPratica.Models.Base;
using HttpAulaPratica.Models.Bible.ValueObjects;

namespace HttpAulaPratica.Models.Bible
{
    class BibleReferenceModel : BaseEntity
    {
        public string reference { get; set; }
        public string text { get; set; }
        public IEnumerable<VersesModel> verses { get; set; }
        public string translation_id { get; set; }
        public string translation_name { get; set; }
        public string translation_note { get; set; }
        public string error { get; set; }

        public override string ToString()
        {
            string rt = string.Empty;
            if (error != null) { rt = error; return rt; }

            foreach (var verse in verses)
            {
                rt += $"[{verse.book_name} {verse.chapter}:{verse.verse}]: '{verse.text.Trim()}'\n".Trim();
                rt += "\n";
            }
            return rt;
        }
    }
}
