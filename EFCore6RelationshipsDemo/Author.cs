
public class Author
{
    public Author(string first, string last)
    {
        FirstName = first;
        LastName = last;
    }
    private Author()
    {

    }
    public int AuthorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<Book> Books { get; set; } = new List<Book>();
}

