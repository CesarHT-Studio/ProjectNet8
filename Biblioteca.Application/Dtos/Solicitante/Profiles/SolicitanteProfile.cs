using AutoMapper;

namespace Biblioteca.Application.Dtos.Solicitante.Profiles;

public class SolicitanteProfile : Profile
{
    public SolicitanteProfile()
    {
        CreateMap<Domain.Models.Solicitante, SolicitanteDto>();
        CreateMap<Domain.Models.Solicitante, SolicitanteSmallDto>();
        CreateMap<Domain.Models.Solicitante, SolicitanteBodyDto>().ReverseMap();
    }
}