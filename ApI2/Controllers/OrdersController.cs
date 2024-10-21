using ApI2.Data;
using ApI2.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApI2.Controllers;
[ApiController]
[Route("Order")]
public class OrdersController : ControllerBase
{
    private readonly LibraryDbContext _context;
    public OrdersController(LibraryDbContext context)
    {
        _context = context;
    }
    [HttpPost]
    public Order AddOrder(Order order)
    {
        if (order == null || order.OrderBooks == null || !order.OrderBooks.Any())
        {
            throw new Exception("Buyurtma yoki kitoblar bo'sh bo'lmasin");
        }

        foreach (var orderBook in order.OrderBooks)
        {
            var book = _context.Books
                .Find(orderBook.BookId);
            if (book == null)
            {
                throw new Exception($"Kitob {orderBook.BookId} topilmadi.");
            }

            book.NumberOfOrders++;
            book.amount--;

            orderBook.Book = book;

        }

        _context.Orders.Add(order);
        _context.SaveChanges();
        return order;
    }
    [HttpGet]
    public ICollection<Order> UpdateOrder()
    {
        return _context.Orders.ToList();
    }
}
