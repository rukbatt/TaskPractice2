﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskPractice.RequestResponse.Account
{
    public class RegisterRequest
    {
        public string userName { get; set; }

        public string password { get; set; }

        public DateTime birthDate { get; set; }
    }
}
