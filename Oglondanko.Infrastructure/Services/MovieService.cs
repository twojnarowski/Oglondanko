using AutoMapper;
using Oglondanko.Core.Domain;
using Oglondanko.Core.Repositories;
using Oglondanko.Infrastructure.DTO;
using Oglondanko.Infrastructure.Extensions;

namespace Oglondanko.Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }
        
        public async Task<MovieDetailsDTO> GetAsync(Guid id)
        {
            var movie = await _movieRepository.GetAsync(id);
            
            return _mapper.Map<MovieDetailsDTO>(movie);  

        }

        public async Task<MovieDetailsDTO> GetAsync(string name)
        {
            var movie = await _movieRepository.GetAsync(name);

            return _mapper.Map<MovieDetailsDTO>(movie);  
        }

        public async Task AddVodLinkAsync(Guid guid, string vodName, string vodUrl)
        {
            var movie = await _movieRepository.GetOrFailAsync(guid);
            movie.AddVodLinks(vodName, vodUrl);
            await _movieRepository.UpdateAsync(movie);
        }

        public async Task<IEnumerable<MovieDto>> BrowseAsync(string? name = null)
        {
            var movies = await _movieRepository.BrowseAsync(name);

            return _mapper.Map<IEnumerable<MovieDto>>(movies);
        }

        public async Task CreateAsync(Guid id, string title, string description, string filmwebURL, int watchScore)
        {
            var movie  = await _movieRepository.GetAsync(title);
            if(movie != null)
            {
                throw new Exception($"Movie title: '{title}' already exists.");   
            }
            movie = new Movie(id, title, description, filmwebURL, watchScore);
            await _movieRepository.AddAsync(movie);
        }

        public async Task DeleteAsync(Guid id)
        {
            var movie = await _movieRepository.GetOrFailAsync(id);
            await _movieRepository.DeleteAsync(movie);
        }


        public async Task UpdateAsync(Guid id, string title, string description, string filmwebURL, int watchScore)
        {
            var movie = await _movieRepository.GetOrFailAsync(id);
            movie  = await _movieRepository.GetAsync(title);
            if(movie != null)
            {
                throw new Exception($"Movie title: '{title}' already exists.");   
            }

            movie  = await _movieRepository.GetAsync(id);
            movie.setTitle(title);
            movie.setDescription(description);
            movie.setFilmwebUrl(filmwebURL);
            movie.setWatchScore(watchScore);

            await _movieRepository.UpdateAsync(movie);
        }
    }
}