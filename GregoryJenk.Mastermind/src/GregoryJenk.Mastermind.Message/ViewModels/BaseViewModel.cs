using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Message.ViewModels
{
    public abstract class BaseViewModel<TId>
    {
        public TId Id { get; set; }
        public DateTimeOffset Created { get; set; }
        public Nullable<DateTimeOffset> Updated { get; set; }
        public Nullable<DateTimeOffset> Deleted { get; set; }
        public int Version { get; set; }
    }
}