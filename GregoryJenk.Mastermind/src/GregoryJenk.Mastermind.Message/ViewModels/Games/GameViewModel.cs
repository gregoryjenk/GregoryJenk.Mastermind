using System;
using System.Collections.Generic;
using System.Linq;

namespace GregoryJenk.Mastermind.Message.ViewModels.Games
{
    public class GameViewModel : BaseViewModel<Guid>
    {
        public IList<GuessViewModel> Guesses { get; set; }
    }
}