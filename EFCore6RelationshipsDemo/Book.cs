
    public class Book
    {
    public Book(string title)
    {
        Title= title;
    }
        public int BookId { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
    }

