using ApI2.Data;
using ApI2.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApI2.Controllers;
[ApiController]
[Route("Book")]
public class BooksController : ControllerBase
{
    private readonly LibraryDbContext _context;
    public BooksController(LibraryDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ICollection<Book> GetBooksList()
    {
        return _context.Books.ToList();
    }

    [HttpGet("GetById")]
    public Book GetBookById(int id)
    {
        Book book = _context.Books.FirstOrDefault(x => x.Id == id);
        if (book == null)
        {
            throw new Exception("Bunday kitob mavjud emas");
        }
        return book;
    }

    [HttpPost]
    public Book PostBook(Book book)
    {
        var category = _context.Categories.FirstOrDefault(c => c.Id == book.CategoryId);

        if (category == null)
        {
            throw new Exception("CategoryId bilan bog'liqlik yo'q");
        }
        _context.Books.Add(book);
        _context.SaveChanges();
        return book;
    }

    [HttpDelete]
    public Book DeleteBook(int id)
    {
        Book book = _context.Books
            .FirstOrDefault(s => s.Id == id);
        _context.Books.Remove(book);
        _context.SaveChanges();
        return book;
    }

    [HttpPut]
    public Book PutBooks(Book book)
    {
        _context.Books.Update(book);
        _context.SaveChanges();
        return book;
    }
}


