using System.Net.Mail;
using Test_Assignment.contract.Response;
using Test_Assignment.Data;
using Test_Assignment.Email;
using Test_Assignment.Model;
using Test_Assignment.Repository;

namespace Test_Assignment.Services
{
    public class UserInformationServices : IUserInformation
    {
        private ApplicationDbContext _dbContext;
        private EmailSend emailSend = new EmailSend();
        public UserInformationServices(ApplicationDbContext dbContext) 
        {
            this._dbContext = dbContext;
        }

        public void Login(string email, string password)
        {
            if(email !=null& password!=null)
            {
                _dbContext.UserInfo.Where(x => x.Email == email && x.Password == password);
            }
        }

        public void Registration(UserModel userModel)
        {
            _dbContext.Add(userModel);
            _dbContext.SaveChanges();
            //string sentEmail = userModel.Email;

            //MailMessage mail = new MailMessage(sentEmail, emailSend.Email);
            //mail.Subject = emailSend.Subject;
            //mail.Body = emailSend.Body;

            //SmtpClient smtpClient = new SmtpClient("smtp.mailtrap.io");
            //smtpClient.Port = 25;
            //smtpClient.EnableSsl = true;
            //smtpClient.Send(mail);
        }
    }
}
