using GregoryJenk.Mastermind.Message.ViewModels.Games;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GregoryJenk.Mastermind.Message.ViewModels.Users
{
    public class UserViewModel : BaseViewModel<string>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public IList<GameViewModel> Games { get; set; }
    }
}