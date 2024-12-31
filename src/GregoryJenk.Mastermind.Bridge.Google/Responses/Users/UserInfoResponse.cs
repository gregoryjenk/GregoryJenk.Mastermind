using System;
using System.Linq;
using System.Text.Json.Serialization;

namespace GregoryJenk.Mastermind.Bridge.Google.Responses.Users
{
    public class UserInfoResponse
    {
        [JsonPropertyName("sub")]
        public string Subject { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public string Email { get; set; }
    }
}