using Abac.Web.Api.Core.DTO;
using Abac.Web.Api.Infrastructure.Entities;
using AutoMapper;
using System.Linq;

namespace Abac.Web.Api.Core.Config.AutoMapper
{
    public class CustomMapper : Profile
    {
        public CustomMapper()
        {
            CreateMap<PlanetDTO, Planet>()
                   .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                   .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                   .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status))
                   .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                   .ForMember(d => d.ImageLink, opt => opt.MapFrom(s => s.ImageLink))
                  .ForAllOtherMembers(x => x.Ignore());

            CreateMap<Planet, PlanetDTO>()
               .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
               .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
               .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status))
               .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
               .ForMember(d => d.ImageLink, opt => opt.MapFrom(s => s.ImageLink))
              .ForAllOtherMembers(x => x.Ignore());

            CreateMap<Planet, ColonistPlanetDTO>()
                 .ForMember(d => d.PlanetId, opt => opt.MapFrom(s => s.Id))
                 .ForMember(d => d.CaptainName, opt => opt.MapFrom(s => s.ColonistPlanet.Where(x => x.Colonist.TypeId == 1).Select(x => x.Colonist.Name).FirstOrDefault()))
                 .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status == null ? "En route" : (s.Status == true ? "OK" : "!OK")))
                 .ForMember(d => d.PlanetName, opt => opt.MapFrom(s => s.Name))
                 .ForMember(d => d.PlanetDescription, opt => opt.MapFrom(s => s.Description))
                 .ForMember(d => d.PlanetImageUrl, opt => opt.MapFrom(s => s.ImageLink))
                 .ForMember(d => d.Robots, opt => opt.MapFrom(s => s.ColonistPlanet.Where(x => x.Colonist.TypeId != 1).Select(x => x.Colonist.Name).ToArray()));

            CreateMap<User, UserDTO>()
                 .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                 .ForMember(d => d.Username, opt => opt.MapFrom(s => s.Username))
                 .ForMember(d => d.Roles, opt => opt.MapFrom(s => s.UserRole.Select(x=>x.Role.Description).ToArray()))
                 .ForMember(d => d.Token, opt => opt.MapFrom(s => s.Token))
                 .ForMember(d => d.TokenExpirationDate, opt => opt.MapFrom(s => s.TokenExpirationDate))
                 .ForMember(d => d.Password, opt => opt.Ignore());

        }
    }

}
