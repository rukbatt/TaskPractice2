using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskPractice.ModelLayer.Entity;
using TaskPractice.RequestResponse.Account;

namespace TaskPractice.OAuth
{
    public interface IUserService
    {
        User Authenticate(LoginRequest user);
    }
}
