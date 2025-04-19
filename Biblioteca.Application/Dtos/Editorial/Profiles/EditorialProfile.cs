using AutoMapper;
using Biblioteca.Application.Dtos.Libro;

namespace Biblioteca.Application.Dtos.Editorial.Profiles;

public class EditorialProfile : Profile
{
    public EditorialProfile()
    {
        // Mapeo de Editorial
        CreateMap<Domain.Models.Editorial, EditorialDto>();
        CreateMap<Domain.Models.Editorial, EditorialSmallDto>();
        CreateMap<Domain.Models.Editorial,EditorialBodyDto>().ReverseMap();
    }
}