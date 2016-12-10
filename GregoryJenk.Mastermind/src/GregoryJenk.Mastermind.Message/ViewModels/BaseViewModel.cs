using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Message.ViewModels
{
    public abstract class BaseViewModel<TId>
    {
        public TId Id { get; set; }
    }
}