using csharp_boolflix.BoolContext;
using Microsoft.AspNetCore.Mvc;

namespace csharp_boolflix.Controllers
{
    public class GenreController : Controller
    {
        readonly Context _context = new();
        public IActionResult Index()
        {
            List<Genre> genres = _context.Genres.ToList();

            return View(genres);
        }

        public IActionResult Create()
        {
            Genre genre = new Genre();
            return View(genre);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Genre form)
        {
            _context.Genres.Add(form);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
