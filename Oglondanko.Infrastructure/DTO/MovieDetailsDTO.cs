namespace Oglondanko.Infrastructure.DTO
{
    public class MovieDetailsDTO : MovieDto
    {
        public IEnumerable<VodLinkDTO> VodLinks { get; set;}
    }
}