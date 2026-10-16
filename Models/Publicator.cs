namespace Krestel_Erich_Lab2.Models
{
    public class Publicator
    {
        public int ID { get; set; }
        public string PublisherName { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
