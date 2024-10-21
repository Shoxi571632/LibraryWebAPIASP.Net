using ApI2.Data;
using ApI2.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApI2.Controllers;
[ApiController]
[Route("Category")]
public class CategorysController : ControllerBase
{
    private readonly LibraryDbContext _context;
    public CategorysController(LibraryDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public Category AddCategory(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
        return category;
    }

    [HttpGet]
    public ICollection<Category> GetBookList()
    {
        return _context.Categories.ToList();
    }

    [HttpGet("GetById")]
    public Category GetCategory(int id)
    {
        Category category = _context.Categories
            .Include(c => c.Books)
            .FirstOrDefault(c => c.Id == id);
        if (category == null)
        {
            throw new Exception("Xatolik bor ");
        }
        return category;
    }

    [HttpDelete]
    public Category Remove(int id)
    {
        Category category = _context.Categories
            .FirstOrDefault(c => c.Id == id);
        if (category == null)
        {
            throw new Exception("Xatolik bor");
        }
        _context.Categories
            .Remove(category);
        _context.SaveChanges();
        return category;
    }

    [HttpPut]
    public Category UpdateCategory(Category category)
    {
        var updateCategroy = _context.Categories
            .Update(category);
        _context.SaveChanges();
        return category;
    }

}
