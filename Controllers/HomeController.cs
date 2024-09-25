using System.Diagnostics;
using Dto.Payment;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Models.Context;
using Project.Models.DataBase;
using Project.Models.Models;
using ZarinPal.Class;

namespace Project.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly Application db;
    private readonly Payment _payment;
    private readonly Authority _authority;
    private readonly Transactions _transactions;

    public HomeController(ILogger<HomeController> logger, Application _db)
    {
        var expose = new Expose();
        _payment = expose.CreatePayment();
        _authority = expose.CreateAuthority();
        _transactions = expose.CreateTransactions();

        _logger = logger;
        db = _db;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult GoToPay()
    {
        return View();
    }
    public async Task<IActionResult> Pay(Vm_Pay vm)
    {
        // Tbl_Pay tbl = new Tbl_Pay()
        // {
        //     PhoneNumber = vm.Vm_PhoneNumber,
        //     Email = vm.Vm_Email,
        //     Detail = vm.Vm_Detail,
        //     Price = vm.Vm_Price,
        //     Status = false,
        //     Time = DateTime.UtcNow,
        // };
        // db.tbl_pays.Add(tbl);
        // db.SaveChanges();

    var result = await _payment.Request(new DtoRequest()
    {
        Mobile = "09214351340",
        CallbackUrl = "https://localhost:5260/home/validate",
        Description = "buy",
        Email ="salam@gamil.com",
        Amount = 12000,
        MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"
    }, ZarinPal.Class.Payment.Mode.sandbox);
        return Redirect($"https://sandbox.zarinpal.com/pg/StartPay/{result.Authority}");
}
public IActionResult validate()
{
    // TODO: Your code here
    return View();
}



public IActionResult Privacy()
{
    return View();
}

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
public IActionResult Error()
{
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
}
