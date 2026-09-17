using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NorthwindWithPagingExample.Data;
using NorthwindWithPagingExample.Models;
using X.PagedList.Extensions;

namespace NorthwindWithPagingExample.Controllers;

public class HomeController : Controller
{
    private const string SessionKey_Customer = "HomeController_Customer";

    private readonly NorthwindContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, NorthwindContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        // Selects only customers with orders using an SQL query.
        // NOTE: Adding parameters using interpolated strings is safe using FromSql in EF Core 7.0 and later,
        // as they use parameterisation to prevent SQL injection.
        var customers = await _context.Customers.FromSql(
            $"""
            select c.* from Customers c
            where exists (select o.OrderID from Orders o where o.CustomerID = c.CustomerID)
            """).ToListAsync();

        // NOTE: Can also use context.Database.SqlQuery<T>(...) to return types that are unmapped.

        return View(customers);
    }

    [HttpPost]
    public async Task<IActionResult> IndexToViewOrders(string customerId)
    {
        var customer = await _context.Customers.FindAsync(customerId);
        if(customer == null)
            return NotFound();

        // Store a complex object in the session via JSON serialisation.
        var customerJson = JsonConvert.SerializeObject(customer);
        HttpContext.Session.SetString(SessionKey_Customer, customerJson);

        return RedirectToAction(nameof(ViewOrders));
    }

    public IActionResult ViewOrders(int page = 1)
    {
        var customerJson = HttpContext.Session.GetString(SessionKey_Customer);
        if(customerJson == null)
            return RedirectToAction(nameof(Index)); // OR return BadRequest();
            
        // Retrieve complex object from the session via JSON deserialisation.
        var customer = JsonConvert.DeserializeObject<Customer>(customerJson);
        ViewBag.Customer = customer;

        // Page the orders, maximum of 3 per page.
        const int pageSize = 3;
        var pagedList =
            _context.Orders.
                Where(x => x.CustomerId == customer.CustomerId).
                OrderBy(x => x.OrderId).
                ToPagedList(page, pageSize);

        return View(pagedList);
    }

    // GET: /Home/BulkUpdateAndBulkDelete
    public IActionResult BulkUpdateAndBulkDelete()
    {
        // You can read more here:
        // https://learn.microsoft.com/en-au/ef/core/saving/execute-insert-update-delete

        // The following is for example purposes only.

        // Bulk Update.
        var rows = _context.OrderDetails.
            Where(x => x.ProductId == 1).
            ExecuteUpdate(setters => setters.SetProperty(x => x.Discount, 0));

        // Bulk Update using existing property value.
        //var rows = _context.OrderDetails.
        //    Where(x => x.ProductId == 1).
        //    ExecuteUpdate(setters => setters.SetProperty(x => x.UnitPrice, x => x.UnitPrice + 2));

        // Bulk Delete.
        //var rows = _context.OrderDetails.Where(x => x.ProductId == 1).ExecuteDelete();

        // Delete all rows.
        //var rows = _context.OrderDetails.ExecuteDelete();

        // Executing non-querying SQL.
        //var rows = _context.Database.ExecuteSql($"delete from [Order Details]");

        _logger.LogInformation("Rows: {Rows}", rows);

        return View();
    }

    public IActionResult Privacy() => View();

    public IActionResult ContactUs(bool approved = false)
    {
        return View(approved);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
