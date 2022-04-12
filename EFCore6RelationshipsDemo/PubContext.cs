using Microsoft.EntityFrameworkCore;

    public class PubContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        optionsBuilder.UseSqlite("add connection string e.g., 'Data Source= M://Data//EFC6Relationships.db'");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        var authorList = new Author[]{
                new Author("Rhoda", "Lerman") { AuthorId = 1} ,
            new Author("Ruth", "Ozeki") { AuthorId = 2},
            new Author("Sofia", "Segovia") { AuthorId = 3},
            new Author("Ursula K.", "LeGuin") { AuthorId = 4},
            new Author("Hugh", "Howey") { AuthorId = 5},
            new Author("Isabelle", "Allende") { AuthorId = 6}
        };
            modelBuilder.Entity<Author>().HasData(authorList);
        }

    }
