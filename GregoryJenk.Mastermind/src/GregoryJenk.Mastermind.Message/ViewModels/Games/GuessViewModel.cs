using GregoryJenk.Mastermind.Message.ViewModels.Pegs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GregoryJenk.Mastermind.Message.ViewModels.Games
{
    public class GuessViewModel : BaseValueObjectViewModel
    {
        public IList<CodePegViewModel> GuessCodePegs { get; set; }
    }
}