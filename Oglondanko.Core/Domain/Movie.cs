namespace Oglondanko.Core.Domain
{
    public class Movie : Entity
    {
        private ISet<VodLink> _vodLinks = new HashSet<VodLink>();
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public string FilmwebURL { get; protected set; }
        public int WatchScore { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        public IEnumerable<VodLink> VodLinks => _vodLinks;

        public IEnumerable<VodLink> AvailableVodLinks => _vodLinks.Where(x => x.VodAvailable);

        public IEnumerable<VodLink> HistoricalVodLinks => _vodLinks.Except(AvailableVodLinks);


        protected Movie()
        {

        }

        public void setTitle(string title)
        {
            if(string.IsNullOrWhiteSpace(title))
            {
                throw new Exception($"Movie with id: '{Id}' cannot have an empty title!");
            }
            Title = title;
            UpdatedAt = DateTime.UtcNow;
        }
        public void setDescription(string description)
        {

            if(string.IsNullOrWhiteSpace(description))
            {
                throw new Exception($"Movie with id: '{Id}' cannot have an empty description!");
            }
            Description = description;
            UpdatedAt = DateTime.UtcNow;
        }

        public void setFilmwebUrl(string filmwebUrl)
        {
            if(string.IsNullOrWhiteSpace(filmwebUrl))
            {
                throw new Exception($"Movie with id: '{Id}' cannot have an empty filmwebUrl!");
            }
            FilmwebURL = filmwebUrl;
            UpdatedAt = DateTime.UtcNow;
        }

        public void setWatchScore(int watchScore)
        {
            if(watchScore > 0 && watchScore <= 10)
            {
                throw new Exception($"Movie with id: '{Id}' must have a score between 0 and 10!");
            }
            WatchScore = watchScore;
            UpdatedAt = DateTime.UtcNow;
        }

        public Movie(Guid id, string title, string description, string filmwebURL, int watchScore)
        {
            Id = id;
            setTitle(title);
            setDescription(description);
            setFilmwebUrl(filmwebURL);
            setWatchScore(watchScore);
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddVodLinks(string vodUrl, string vodName)
        {
            _vodLinks.Add(new VodLink(this, vodName, vodUrl));
        }
    }
}