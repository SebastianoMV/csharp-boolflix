using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using csharp_boolflix.BoolContext;


namespace csharp_boolflix.Controllers
{
    public class UserController : Controller
    {
        public Context _context = new Context();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Film()
        {
            List<MediaInfo> filmList = _context.Infos.Include("Film").Include("Cast").Include("Generes").ToList();
            return View(filmList);
        }

        public IActionResult Serie()
        {
            return View();
        }
    }
}
