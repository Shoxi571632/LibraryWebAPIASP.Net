using ApI2.Data;
using Microsoft.AspNetCore.Mvc;
namespace ApI2.Model;

[ApiController]
[Route("User")]
public class UserController
{
    private readonly LibraryDbContext _context;
    public UserController(LibraryDbContext context)
    {
        _context = context;
    }
    [HttpPost]
    public User AddUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }
}
