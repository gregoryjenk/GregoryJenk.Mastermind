using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Message.ViewModels.Users
{
    /// <summary>
    /// No need to inherit from the base view model as this is used for external messaging.
    /// </summary>
    public class ExternalUserViewModel
    {
        public string Image { get; set; }
    }
}