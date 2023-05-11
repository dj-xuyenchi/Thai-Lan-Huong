using dj_actionlayer.Business.UserBusiness;
using dj_webdesigncore.Business.Study;
using dj_webdesigncore.Business.UserIBusiness;
using dj_webdesigncore.Request.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Cryptography.Xml;

namespace dj_endpoint.Controllers.UserAPIs
{
    [Authorize(Policy = "ADMINANDMEMBER")]
    [Route("/user")]
    public class UserApi : BaseApi
    {
        private readonly IUserBusiness _user;

        public UserApi()
        {
            _user = new UserBusiness();
        }

        [HttpGet("getuserinformation")]
        public async Task<IActionResult> getUserInformation(int userId)
        {
            return Ok(await _user.getInformation(userId));
        }
        [HttpGet("getoptionupdate")]
        public async Task<IActionResult> getOptionUpdate()
        {
            return Ok(await _user.optionUpdateInfor());
        }
        [HttpGet("getdistrict")]
        public async Task<IActionResult> getDistrict(string provinceCode)
        {
            return Ok(await _user.getDistrict(provinceCode));
        }
        [HttpGet("getward")]
        public async Task<IActionResult> getWard(string districtCode)
        {
            return Ok(await _user.getWard(districtCode));
        }
        [HttpPost("updateuser")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile? avatar, [FromForm] string updateUserRequest)
        {
            UpdateUserRequest userRequest = JsonConvert.DeserializeObject<UpdateUserRequest>(updateUserRequest);
            return Ok(await _user.updateUser(avatar, userRequest));
        }
        [HttpPost("createexperience")]
        public async Task<IActionResult> createExperience(CreateExperience createExperience)
        {
            return Ok(await _user.createExperience(createExperience));
        }
        [HttpGet("deleteexperience")]
        public async Task<IActionResult> deleteExperience(int experienceId)
        {
            return Ok(await _user.deleteExperience(experienceId));
        }
        [HttpGet("getoption")]
        public async Task<IActionResult> getOption()
        {
            return Ok(await _user.getOptionAddLearning());
        }
        [HttpPost("createlearning")]
        public async Task<IActionResult> createLearning(AddLearningExperience addLearningExperience)
        {
            return Ok(await _user.createLearningExperience(addLearningExperience));
        }
        [HttpGet("deletelearning")]
        public async Task<IActionResult> deleteLearning(int learningId)
        {
            return Ok(await _user.deleteLearningExperience(learningId));
        }
    }
}
