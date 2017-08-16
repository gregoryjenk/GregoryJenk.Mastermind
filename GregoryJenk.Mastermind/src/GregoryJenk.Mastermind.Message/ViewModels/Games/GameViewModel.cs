using GregoryJenk.Mastermind.Message.ViewModels.Pegs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GregoryJenk.Mastermind.Message.ViewModels.Games
{
    public class GameViewModel : BaseViewModel<Guid>
    {
        public IList<GuessViewModel> Guesses { get; set; }
        public IList<CodePegViewModel> AnswerCodePegs { get; set; }
    }
}