using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Message.ViewModels
{
    public abstract class BaseValueObjectViewModel
    {
        public DateTimeOffset Created { get; set; }
    }
}