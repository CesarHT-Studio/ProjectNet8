using AutoMapper;

namespace Biblioteca.Application.Dtos.Libro.Profiles;

public class LibroProfile : Profile
{
    public LibroProfile()
    {
        CreateMap<Domain.Models.Libro, LibroDto>();
        CreateMap<Domain.Models.Libro, LibroSmallDto>();

        CreateMap<Domain.Models.Libro, LibroBodyDto>().ReverseMap();
    }
}