using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Message.ViewModels
{
    public abstract class ViewModelBase<TId>
    {
        public TId Id { get; set; }
    }
}