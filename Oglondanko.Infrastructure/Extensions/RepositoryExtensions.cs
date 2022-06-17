using Oglondanko.Core.Domain;
using Oglondanko.Core.Repositories;

namespace Oglondanko.Infrastructure.Extensions
{
    public static class RepositoryExtensions
    {
        public static async Task<Movie> GetOrFailAsync(this IMovieRepository repository, Guid id)
        {
            var movie  = await repository.GetAsync(id);
            if(movie == null)
            {
                throw new Exception($"Movie ID: '{id}' does not exist.");   
            }

            return movie;
        }
    }
}