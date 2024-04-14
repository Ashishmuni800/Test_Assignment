using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_Assignment.contract.Response;
using Test_Assignment.Email;
using Test_Assignment.Model;
using Test_Assignment.Repository;

namespace Test_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoDetailsCollectionsController : ControllerBase
    {
        private IUserInfoDetailsCollections _IIUserInfoDetailsCollectionsServices;
        private ApiResponse response = new ApiResponse();
        private EmailSend emailSend = new EmailSend();
        public UserInfoDetailsCollectionsController(IUserInfoDetailsCollections IIUserInfoDetailsCollectionsServices)
        {
            this._IIUserInfoDetailsCollectionsServices = IIUserInfoDetailsCollectionsServices;
        }
        [HttpPost]
        [Route("CreateUserInfoDetails")]
        public IActionResult CreateUserInfoDetails(UserInfoDetails u)
        {
            try
            {
                _IIUserInfoDetailsCollectionsServices.CreateUserInfoDetails(u);
                response.Ok = true;
                response.Massage = "User Create Successfully";
                response.Status = 200;
                response.Data = u;
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
        [HttpPost]
        [Route("City")]
        public IActionResult City(Country cityies)
        {
            try
            {
                _IIUserInfoDetailsCollectionsServices.CreateCountry(cityies);
                response.Ok = true;
                response.Massage = "City Create Successfully";
                response.Status = 200;
                response.Data = cityies;
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
        [HttpPost]
        [Route("CreateStates")]
        public IActionResult CreateStates(States states)
        {
            try
            {
                _IIUserInfoDetailsCollectionsServices.CreateStates(states);
                response.Ok = true;
                response.Massage = "States Create Successfully";
                response.Status = 200;
                response.Data = states;
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
        [HttpPost]
        [Route("CreateDistrict")]
        public IActionResult CreateDistrict(Disttrict disttrict)
        {
            try
            {
                _IIUserInfoDetailsCollectionsServices.CreateDistrict(disttrict);
                response.Ok = true;
                response.Massage = "Disttrict Create Successfully";
                response.Status = 200;
                response.Data = disttrict;
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
