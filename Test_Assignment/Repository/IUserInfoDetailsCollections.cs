using Test_Assignment.Model;

namespace Test_Assignment.Repository
{
    public interface IUserInfoDetailsCollections
    {
        void CreateUserInfoDetails(UserInfoDetails userInfoDetails);
        void CreateCountry(Country city);
        void CreateStates(States states);
        void CreateDistrict(Disttrict Disttrict);
    }
}
