using AutoMapper;
using WebChat.Models;

namespace WebChat.Repositories
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserRepository>(MemberList.Destination).ReverseMap();
            CreateMap<Message, MessageRepository>(MemberList.Destination).ReverseMap();
        }
    }
}
