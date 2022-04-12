// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

//AddBookToExistingAuthorTracked();
void AddBookToExistingAuthorTracked()
{
   
    var context = new PubContext();
    var author = context.Authors.FirstOrDefault();
    var book = new Book("A Great Book!");
    author.Books.Add(book);
    //context.Authors.Update(author);
    context.ChangeTracker.DetectChanges();
    var dv = context.ChangeTracker.DebugView.ShortView;
 }

//AddBookToExistingAuthorTracked_Wrong_1();
void AddBookToExistingAuthorTracked_Wrong_1()
{
    using var context = new PubContext();
    var author = context.Authors.FirstOrDefault();
    var book = new Book("A Great Book!");
    author.Books.Add(book);
    //calling Add or Update WITHOUT DetectChanges will fail.
    //context.Add(author); // No need to add this when its being tracked
    context.ChangeTracker.DetectChanges();
    var dv = context.ChangeTracker.DebugView.ShortView;
}

//AddBookToExistingAuthorNotTracked();
void AddBookToExistingAuthorNotTracked()
{
    //author with new book coming from a elsewhere
    var existingAuthor = new Author("Ruth", "Ozeki") { AuthorId = 2 };
    existingAuthor.Books.Add(new Book("A Tale for the Time Being"));

    using var context =new PubContext();
    //context.Authors.Add(existingAuthor); //FK is good, but Author will get inserted: FAIL
    //context.Authors.Update(existingAuthor); //FK is good, but Author will get updated: bad for performance
    var book = existingAuthor.Books[0];
    book.AuthorId = existingAuthor.AuthorId; //without this, book will not get the FK value
    context.Add(book); 
    //context.ChangeTracker.DetectChanges(); 
    var dv = context.ChangeTracker.DebugView.ShortView;
}

AddBookToExistingAuthorNotTrackedUsingAttach();
void AddBookToExistingAuthorNotTrackedUsingAttach()
{
    //author with new book coming from a elsewhere
    var existingAuthor = new Author("Ruth", "Ozeki") { AuthorId = 2 };
    existingAuthor.Books.Add(new Book("A Tale for the Time Being"));

    using var context = new PubContext();
    context.Authors.Attach(existingAuthor); //state and FK discovered 
    //context.ChangeTracker.DetectChanges(); //attach the full graph works with or without detect changes
    var dv = context.ChangeTracker.DebugView.ShortView;
}


AddBookToExistingAuthorNotTrackedEntry();
void AddBookToExistingAuthorNotTrackedEntry()
{

    //existing author with new book coming from elsewhere
    var existingAuthor = new Author("Ruth", "Ozeki") { AuthorId = 2 };
    existingAuthor.Books.Add(new Book("A Tale for the Time Being"));

    using var context = new PubContext();
    var book = existingAuthor.Books[0];
    book.AuthorId= existingAuthor.AuthorId;
    context.Entry(book).State=EntityState.Added;
    var dv = context.ChangeTracker.DebugView.ShortView;
}