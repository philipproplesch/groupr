using AutoMapper;
using Groupr.Core.Models;
using Groupr.Mvc.ViewModels;
using StructureMap.Configuration.DSL;

namespace Groupr.Mvc.Infrastructure
{
    public class MapperRegistry : Registry
    {
        public MapperRegistry()
        {
            Mapper.CreateMap<MeetingViewModel, Meeting>();
            Mapper.CreateMap<Meeting, MeetingViewModel>();

            Mapper.CreateMap<LocationViewModel, Location>();
            Mapper.CreateMap<Location, LocationViewModel>();

            Mapper.CreateMap<MessageViewModel, Message>();
            Mapper.CreateMap<Message, MessageViewModel>();
        }
    }
}
