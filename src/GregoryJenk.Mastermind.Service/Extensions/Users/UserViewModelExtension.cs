using GregoryJenk.Mastermind.Message.ViewModels.Users;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Service.Extensions.Users
{
    public static class UserViewModelExtension
    {
        public static void Set(this UserViewModel destinationUserViewModel, UserViewModel sourceUserViewModel)
        {
            destinationUserViewModel.Name = sourceUserViewModel.Name;
            destinationUserViewModel.Email = sourceUserViewModel.Email;
            destinationUserViewModel.Scheme = sourceUserViewModel.Scheme;
            destinationUserViewModel.Image = sourceUserViewModel.Image;
            destinationUserViewModel.ExternalId = sourceUserViewModel.ExternalId;
        }
    }
}