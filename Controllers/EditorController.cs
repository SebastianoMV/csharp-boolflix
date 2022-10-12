using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using csharp_boolflix.BoolContext;
using csharp_boolflix.Models;

namespace csharp_boolflix.Controllers
{
    public class EditorController : Controller
    {
        public Context _context = new Context();
        public IActionResult Index()
        {
            List<MediaInfo> filmList = _context.Infos.Include("Film").Include("Cast").Include("Generes").ToList();
            return View(filmList);
        }

        public IActionResult Create()
        {
            MediaFilm mediafilm = new MediaFilm();
            mediafilm.Genres = new Context().Genres.ToList();
            mediafilm.Cast = new Context().Actors.ToList();
            return View(mediafilm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MediaFilm form)
        {
            using (Context context = new Context())
            {
                if (!ModelState.IsValid)
                {
                    form.Genres = _context.Genres.ToList();
                    form.Cast = _context.Actors.ToList();
                    return View("Create", form);
                }
                form.Film.VisualizationCount = 0;
                form.Cast = context.Actors.Where(actor => form.SelectedCast.Contains(actor.Id)).ToList<Actor>();
                form.Genres = context.Genres.Where(genre => form.SelectedGenres.Contains(genre.Id)).ToList<Genre>();

                context.Add(form.Film);
                context.SaveChanges();
                form.MediaInfo.FilmId = form.Film.Id;
                context.Add(form.MediaInfo);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public IActionResult UpdateFilm(int id)
        {

            MediaInfo film = _context.Infos.Include("Film").Include("Cast").Include("Generes").First();
            MediaFilm mediaFilm = new MediaFilm();
            mediaFilm.MediaInfo = film;
            mediaFilm.Genres = _context.Genres.ToList();
            mediaFilm.Cast = _context.Actors.ToList();

            return View(mediaFilm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, MediaFilm form)
        {
            if (!ModelState.IsValid)
            {
                form.Film.Id = id;
                form.Genres = _context.Genres.Where(genre => form.SelectedGenres.Contains(genre.Id)).ToList<Genre>();
                form.Cast = _context.Actors.Where(actor => form.SelectedCast.Contains(actor.Id)).ToList<Actor>();
                form.Genres = _context.Genres.ToList();
                form.Cast = _context.Actors.ToList();
                return View("Update", form);
            }
            MediaInfo film = _context.Infos.Where(x => x.FilmId == id).Include("Film").Include("Cast").Include("Generes").First();
            film.Film.Title = form.Film.Title;
            film.Film.Descrizione = form.Film.Descrizione;
            film.Film.Durata = form.Film.Durata;
            film.Film.VisualizationCount = 0;
            film.Cast = _context.Actors.Where(actor => form.SelectedCast.Contains(actor.Id)).ToList<Actor>();
            film.Generes = _context.Genres.Where(genre => form.SelectedGenres.Contains(genre.Id)).ToList<Genre>();

            _context.Infos.Update(film);

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Serie()
        {
            return View();
        }
    }
}
