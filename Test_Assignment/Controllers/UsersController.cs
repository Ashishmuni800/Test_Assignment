using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using Test_Assignment.contract.Response;
using Test_Assignment.Data;
using Test_Assignment.Email;
using Test_Assignment.Model;
using Test_Assignment.Repository;

namespace Test_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserInformation _IUserServices;
        private ApiResponse response = new ApiResponse();
        private EmailSend emailSend = new EmailSend();
        public UsersController(IUserInformation IUserServices)
        {
            this._IUserServices = IUserServices;   
        }
        [HttpPost]
        [Route("Registration")]
        public IActionResult Registration(UserModel u)
        {
            try
            {
                _IUserServices.Registration(u);
                response.Ok = true;
                response.Massage = "User Create Successfully";
                response.Status = 200;
                response.Data = u;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Ok=false;
                response.Massage=ex.Message;
                response.Status=500;
            }
            return BadRequest(response);
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string email, string password)
        {
            try
            {
                _IUserServices.Login(email, password);
                response.Ok = true;
                response.Massage = "User Login Successfully";
                response.Status = 200;
                response.Data = email;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Ok = false;
                response.Massage = ex.Message;
                response.Status = 500;
            }
            return BadRequest(response);
        }
    }
}
