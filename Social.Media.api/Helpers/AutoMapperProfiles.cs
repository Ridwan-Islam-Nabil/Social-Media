using AutoMapper;
using Social.Media.api.DTOs;
using Social.Media.api.Entities;

namespace Social.Media.api.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
                .ForMember(d => d.PhotoUrl, o => 
                    o.MapFrom(s => s.Photos.FirstOrDefault(x => x.IsMain)!.Url));
            CreateMap<Photo, PhotoDto>();
        }
    }
}
