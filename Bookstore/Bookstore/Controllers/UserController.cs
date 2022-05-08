using BusinessLayer.Interface;
using CommonLayer;
using CommonLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL userBL;
        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }
        [HttpPost("Register")]
        public IActionResult UserRegister(UserModel userModel)
        {
            try
            {
                var user = this.userBL.UserRegister(userModel);
                if (user != null)
                {
                    return this.Ok(new { Success = true, message = " Sucessfull User Registration", Response = user });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = " Unsuccessfull User Registration Failed" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }

        [HttpPost("Login")]
        public IActionResult UserLogin(UserLoginModel userLogin)
        {
            try
            {
                var login = this.userBL.UserLogin(userLogin.Email, userLogin.Password);
                if (login != null)
                {
                    return this.Ok(new { Success = true, message = " Sucessfull Login -Token", Response = login });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = " Unsuccessfull Login" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }

        [HttpPost("ForgotPassword")]
        public IActionResult ForgotPassword(ForgotPassModel FPModel)
        {
            try
            {
                var forgotPassword = this.userBL.ForgotPassword(FPModel.Email);
                if (forgotPassword != null)
                {
                    return this.Ok(new { Success = true, message = " Mail sent To Email Check inbox", Response = forgotPassword });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Unsuccessfull To Add ForgotPassword" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }

        [Authorize]
        [HttpPut("ResetPassword")]
        public IActionResult ResetPassword(ResetPassModel RPModel)
        {
            try
            {
                var email = User.Claims.FirstOrDefault(e => e.Type == "Email").Value.ToString();
                if (this.userBL.ResetPassword(email, RPModel.newPassword, RPModel.confirmPassword))
                {
                    return this.Ok(new { Success = true, message = "  Sucessfully Password Changed" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "  Please Try Again Later!!! " });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
    }
}
