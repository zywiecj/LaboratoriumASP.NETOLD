using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LaboratoriumASP.NET.Models;

namespace LaboratoriumASP.NET.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

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

        // Dodaj nową metodę Age
        [HttpGet]
        public IActionResult Age(DateTime? birthDate)
        {
            if (birthDate.HasValue)
            {
                // Oblicz aktualną datę
                DateTime today = DateTime.Now;

                // Oblicz różnicę w latach, miesiącach i dniach
                int years = today.Year - birthDate.Value.Year;
                int months = today.Month - birthDate.Value.Month;
                int days = today.Day - birthDate.Value.Day;

                // Korekta na dni
                if (days < 0)
                {
                    months--;
                    days += DateTime.DaysInMonth(today.Year, today.Month - 1);
                }

                // Korekta na miesiące
                if (months < 0)
                {
                    years--;
                    months += 12;
                }

                // Przekazujemy wynik do widoku za pomocą ViewBag
                ViewBag.AgeResult = $"{years} lat, {months} miesięcy, {days} dni";
                ViewBag.BirthDate = birthDate.Value.ToShortDateString();
            }

            return View();
        }
    }

    public enum Operator
    {
        Add, Sub, Mul, Div
    }
}
