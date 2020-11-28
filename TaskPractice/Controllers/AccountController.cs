using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskPractice.OAuth;
using TaskPractice.RequestResponse;
using TaskPractice.RequestResponse.Account;

namespace TaskPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public ActionResult<RE<LoginResponse>> Login(LoginRequest request)
        {
            var response = new RE<LoginResponse>();         
             
            try
            {
                var user = _userService.Authenticate(request);

                if (user == null)
                    return Unauthorized();


                var r = new LoginResponse();

                r.credidentals = new Credidentals() { access_token = user.authToken,token_type = "Bearer"};

                //automap
                r.user = new Models.LoginUser() { id = user.id.ToString(), userName = user.username };

                response.data = r;
                response.code = Ok().StatusCode;

            }
            catch (Error ex)
            {
                var re = response.Exception(ex);



                return BadRequest();
            }
            catch (Exception ex)
            {
                return response.Exception(ex);
            }


            return response;
        }


        [Route("Register")]
        [AllowAnonymous]
        [HttpPost]
        public ActionResult<RE<LoginResponse>> Register()
        {

            _userService.AddUser(new ModelLayer.Entity.User() { password = "a",username = "m"});





            return Ok();
        }
    }
}