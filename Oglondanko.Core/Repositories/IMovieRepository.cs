using Oglondanko.Core.Domain;

namespace Oglondanko.Core.Repositories
{
    public interface IMovieRepository
    {
         Task<Movie> GetAsync(Guid id);
         Task<Movie> GetAsync(String title);
         Task<IEnumerable<Movie>> BrowseAsync(String title = "");
         Task AddAsync(Movie movie);
         Task UpdateAsync(Movie movie);
         Task DeleteAsync(Movie movie);
         
    }
}