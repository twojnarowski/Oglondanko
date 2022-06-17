using Oglondanko.Core.Domain;
using Oglondanko.Infrastructure.DTO;

namespace Oglondanko.Infrastructure.Services
{
    public interface IMovieService
    {
        

        Task<MovieDetailsDTO> GetAsync(Guid id);
        Task<MovieDetailsDTO> GetAsync(string name);
        Task<IEnumerable<MovieDto>> BrowseAsync(string? name = null);
        Task CreateAsync(Guid id, string title, string description, string filmwebURL, int watchScore);
        Task AddVodLinkAsync(Guid guid, string vodName, string vodUrl);
        Task UpdateAsync(Guid id, string title, string description, string filmwebURL, int watchScore);
        Task DeleteAsync(Guid id);
        


    }
}