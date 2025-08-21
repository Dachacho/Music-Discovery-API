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
        }
    }
}