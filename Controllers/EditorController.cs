using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using csharp_boolflix.BoolContext;


namespace csharp_boolflix.Controllers
{
    public class EditorController : Controller
    {
        private readonly Context _context;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Film()
        {
            return View();
        }

        public IActionResult Serie()
        {
            return View();
        }
    }
}
