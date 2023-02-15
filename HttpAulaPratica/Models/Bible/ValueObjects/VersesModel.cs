namespace HttpAulaPratica.Models.Bible.ValueObjects
{
    class VersesModel
    {
        public string book_id { get; set; }
        public string book_name { get; set; }
        public int chapter { get; set; }
        public int verse { get; set; }
        public string text { get; set; }
    }
}
