using AutoMapper;
using GregoryJenk.Mastermind.Bridge.Google.Responses.Users;
using GregoryJenk.Mastermind.Message.ViewModels.Users;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Bridge.Google.Profiles.Users
{
    public class UserViewModelProfile : Profile
    {
        public UserViewModelProfile()
        {
            CreateMap<UserInfoResponse, UserViewModel>()
                .ForMember(destination => destination.Image, options => options.MapFrom(source => source.Picture))
                .ForMember(destination => destination.ExternalId, options => options.MapFrom(source => source.Subject));
        }
    }
}