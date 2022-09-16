using Microsoft.AspNetCore.Mvc;
using CustomerService;
using System.Linq;


namespace CustomerService.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;

    private static long _customerId = 1;
    private static List<Customer> _customers = new() {
        new Customer()
        {
            Id = _customerId,
            Name = "International Bicycles A/S",
            Address1 = "Nydamsvej 8",
            Address2 = null,
            PostalCode = 8362,
            City = "Hørning",
            TaxNumber = "DK-75627732"
        }
    };

    public CustomerController(ILogger<CustomerController> logger)
    {
        _logger = logger;
    }

    // -----------------------------------------------------------------

    [HttpGet("/api/customer")]
    public List<Customer> GetCustomers()
    {
        _logger.LogInformation("Method {string}() called at {DateTime}",
            System.Reflection.MethodBase.GetCurrentMethod()?.Name,
            DateTime.Now.ToLongTimeString());

        return _customers
            .ToList();
    }

    [HttpGet("/api/customer/{id}")]
    public Customer GetCustomerById(int id)
    {
        _logger.LogInformation("Method {string}() called at {DateTime}",
            System.Reflection.MethodBase.GetCurrentMethod()?.Name,
            DateTime.Now.ToLongTimeString());

        return _customers
            .Where(c => c.Id == id)
            .First();
    }

    // -----------------------------------------------------------------

}
