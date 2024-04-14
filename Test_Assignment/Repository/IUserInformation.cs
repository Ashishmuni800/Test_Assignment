using Test_Assignment.Model;

namespace Test_Assignment.Repository
{
    public interface IUserInformation
    {
        void Registration(UserModel userModel);
        void Login(string email, string password);
    }
}
