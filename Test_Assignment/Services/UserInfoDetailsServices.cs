using Microsoft.EntityFrameworkCore;
using Test_Assignment.Data;
using Test_Assignment.Email;
using Test_Assignment.Model;
using Test_Assignment.Repository;

namespace Test_Assignment.Services
{
    public class UserInfoDetailsServices : IUserInfoDetailsCollections
    {
        private ApplicationDbContext _dbContext;
        private EmailSend emailSend = new EmailSend();
        public UserInfoDetailsServices(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public void CreateCountry(Country city)
        {
            _dbContext.Add(city);
            _dbContext.SaveChanges();
        }

        public void CreateDistrict(Disttrict Disttrict)
        {
            _dbContext.Add(Disttrict);
            _dbContext.SaveChanges();
        }

        public void CreateStates(States states)
        {
            _dbContext.Add(states);
            _dbContext.SaveChanges();
        }

        public void CreateUserInfoDetails(UserInfoDetails userInfoDetails)
        {
            _dbContext.Add(userInfoDetails);
            _dbContext.SaveChanges();
        }
    }
}
