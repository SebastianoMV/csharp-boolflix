namespace csharp_boolflix.Models
{
    public class MediaFilm
    {
        public MediaInfo MediaInfo { get; set; }
        public Film? Film { get; set; }
        public List<Genre>? Genres { get; set; }
        public List<Actor>? Cast { get; set; }
        public List<int>? SelectedGenres { get; set; }
        public List<int>? SelectedCast { get; set; }

        public MediaFilm()
        {
            MediaInfo = new MediaInfo();
            Film = new Film();
            Genres = new List<Genre>();
            Cast = new List<Actor>();
            SelectedGenres = new List<int>();
            SelectedCast = new List<int>();

        }

    }
}
