using Oglondanko.Core.Domain;
using Oglondanko.Core.Repositories;

namespace Oglondanko.Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private static readonly ISet<Movie> _movies = new HashSet<Movie>()
        {
            new Movie(Guid.NewGuid(), "title2", "Descriptio2", "http://www.pl", 10),
            new Movie(Guid.NewGuid(), "title", "Descriptio", "http://www.pl", 10),
        };


        public async Task<Movie> GetAsync(Guid id)
            => await Task.FromResult(_movies.SingleOrDefault(x => x.Id == id));

        public async Task<Movie> GetAsync(string title)
            => await Task.FromResult(_movies.SingleOrDefault(x => x.Title.ToLowerInvariant() == title.ToLowerInvariant()));

        
        public async Task<IEnumerable<Movie>> BrowseAsync(string title = "")
        {
            var movies = _movies.AsEnumerable();
            if(!string.IsNullOrWhiteSpace(title))
            {
                movies = movies.Where(x => x.Title.ToLowerInvariant().Contains(title.ToLowerInvariant()));
            }

            return await Task.FromResult(movies);
        }


        public async Task AddAsync(Movie movie)
        {
            _movies.Add(movie);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Movie movie)
        {
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Movie movie)
        {
            _movies.Remove(movie);
            await Task.CompletedTask;
        }
    }
}