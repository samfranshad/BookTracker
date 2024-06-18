namespace BookTracker.Models
{
    public class Book
    {
        public int ID { get; set; }
        public long ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int YearPublished { get; set; }
        public string Genre { get; set; }
        public string Completed { get; set; }
        public string Description { get; set; }
        

    }
}
