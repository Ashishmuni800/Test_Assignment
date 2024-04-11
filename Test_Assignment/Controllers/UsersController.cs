using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using Test_Assignment.contract.Response;
using Test_Assignment.Data;
using Test_Assignment.Email;
using Test_Assignment.Model;

namespace Test_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private ApplicationDbContext _dbContext;
        private ApiResponse response = new ApiResponse();
        private EmailSend emailSend = new EmailSend();
        public UsersController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;   
        }
        [HttpPost]
        [Route("Registration")]
        public IActionResult Registration(UserModel u)
        {
            try
            {
                _dbContext.Add(u);
                _dbContext.SaveChanges();

                response.Ok = true;
                response.Massage = "User Create Successfully";
                response.Status = 200;
                response.Data = u;

                string sentEmail = u.Email;

                MailMessage mail = new MailMessage(sentEmail, emailSend.Email);
                mail.Subject = emailSend.Subject;
                mail.Body = emailSend.Body;

                SmtpClient smtpClient = new SmtpClient("smtp.mailtrap.io");
                smtpClient.Port = 25;
                smtpClient.EnableSsl=true; 
                smtpClient.Send(mail);


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
                var Exist = _dbContext.UserInfo.Where(x => x.Email == email && x.Password == password);

                if(Exist != null)
                {
                    response.Ok = true;
                    response.Massage = "User Login Successfully";
                    response.Status = 200;
                    response.Data = email;

                    return Ok(response);
                }
                else
                {
                    response.Ok = false;
                }

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
