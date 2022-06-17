namespace Oglondanko.Infrastructure.Commands.Movies
{
    public class UpdateMovie
    {
        public Guid MovieId {get;set;}
        public string Title { get;  set;}
        public string Description { get;  set;}
        public string FilmwebURL { get;  set;}
        public int WatchScore { get;  set;}
    }
}