using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SeasonTracker.Dtos;
using SeasonTracker.Models;

namespace SeasonTracker.App_Start
{
    public class MappingProfile : Profile
    {
        //Automapper maps properties based on their name. This is convention based mapping tool.
        public MappingProfile()
        {
            //Domain to Dto
            Mapper.CreateMap<Member, MemberDto>();
            Mapper.CreateMap<TvShow, TvShowDto>();
            Mapper.CreateMap<WatchList, WatchListDto>();

            //Dto to Domain
            Mapper.CreateMap<MemberDto, Member>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<TvShowDto, TvShow>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<WatchListDto, WatchList>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}