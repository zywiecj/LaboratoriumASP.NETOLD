using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LaboratoriumASP.NET.Models;

namespace LaboratoriumASP.NET.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    
    
    /*
     * Utworz metode Calculator oraz widok w nim wyswietl tylko napis Kalkulator
     * Dodaj link w nawigacji aplikacji do metody Kalkulator
     */
    

    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult About()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    public IActionResult Calculator(Operator? op, double? x, double? y)
    {
        //https://localhost:7019/Home/Calculator?op=add&x=4&y=1,5
        // var op = Request.Query["op"];
        // var x = double.Parse(Request.Query["x"]);
        // // var y= double.Parse(Request.Query["y"]);
        if (x is null || y is null)
        {
            ViewBag.ErrorMessage = "Niepoprawny format liczby x lub y lub ich brak!";
            return View("CalculatorError");
        }

        if (op is null)
        {
            ViewBag.ErrorMessage = "Nieznany operator!";
            return View("CalculatorError");
        }
        
        double? result = 0.0;
        switch (op)
        {
            case Operator.Add:
                result = x + y;
                ViewBag.Operator = "+";
                break;
            case Operator.Sub:
                result = x - y;
                ViewBag.Operator = "-";
                break;
            case Operator.Mul:
                result = x * y;
                ViewBag.Operator = "*";
                break;
            case Operator.Div:
                result = x / y;
                ViewBag.Operator = ":";
                break;
            
        }
        ViewBag.Result = result;
        ViewBag.X = x;
        ViewBag.Y = y;
        return View();
        
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

public enum Operator
{
    Add, Sub, Mul, Div
}

/*  Zadanie domowe 
* Napisz metode Age, ktora przyjmuje parametry z datą urodzin i wyświetla wiek
* w latach, miesiącach i dniach.
*/