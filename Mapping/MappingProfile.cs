using AutoMapper;
using MusicDiscoveryAPI.Models;
using MusicDiscoveryAPI.DTOs;

namespace MusicDiscoveryAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Song, SongDTO>().ReverseMap();
            CreateMap<SongCreateDTO, Song>();

            CreateMap<PlaylistCreateDTO, Playlist>();
            CreateMap<Playlist, PlaylistDTO>()
                .ForMember(dest => dest.SongIds, opt => opt.MapFrom(src => src.Songs.Select(s => s.Id)));
        }
    }
}