using AutoMapper;
using Oglondanko.Core.Domain;
using Oglondanko.Infrastructure.DTO;

namespace Oglondanko.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
                => new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Movie,MovieDto>()
                    .ForMember(x => x.VodLinksCount, m => m.MapFrom(p => p.VodLinks.Count()));
                    cfg.CreateMap<Movie,MovieDetailsDTO>();
                    cfg.CreateMap<VodLink, VodLinkDTO>();
                })
                .CreateMapper();
    }
}