using AutoMapper;
using Biblioteca.Application.Dtos.Libro;

namespace Biblioteca.Application.Dtos.Prestamo.Profiles;

public class PrestamoProfile : Profile
{
    public PrestamoProfile()
    {
        CreateMap<Domain.Models.Prestamo, PrestamoDto>();
        CreateMap<Domain.Models.Prestamo, PrestamoSmallDto>();
        CreateMap<Domain.Models.Prestamo, PrestamoBodyDto>().ReverseMap();
    }
}