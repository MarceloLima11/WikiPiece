using AutoMapper;
using WikiPiece.Data.DTOs.LowDtos;
using WikiPiece.Models;

namespace WikiPiece.Data.DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AkumaNoMi, AkumaNoMiDTO>().ReverseMap();
            CreateMap<Personagem, PersonagemDTO>().ReverseMap();
            CreateMap<Arco, ArcoDTO>().ReverseMap();
            CreateMap<Ilha, IlhaDTO>().ReverseMap();
            

            //Low mappings
            CreateMap<Personagem, PersonagemLowDTO>().ReverseMap();
            CreateMap<AkumaNoMi, AkumaNoMiLowDTO>().ReverseMap();
        }
    }
}