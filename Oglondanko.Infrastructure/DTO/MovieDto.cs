using Oglondanko.Core.Domain;

namespace Oglondanko.Infrastructure.DTO
{
    public class MovieDto
    {
        public Guid Id {get;set;}
        private ISet<VodLink> _vodLinks = new HashSet<VodLink>();
        public string Title { get;  set;}
        public string Description { get;  set;}
        public string FilmwebURL { get;  set;}
        public int WatchScore { get;  set;}
        public DateTime UpdatedAt { get;  set;}

        public int VodLinksCount {get;set;}
    }
}