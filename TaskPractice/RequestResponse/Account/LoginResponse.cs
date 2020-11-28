using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskPractice.RequestResponse.Account
{
    public class LoginResponse
    {
        public Models.LoginUser user { get; set; }
        public Credidentals credidentals { get; set; }
    }

    public class Credidentals
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
    }
}
