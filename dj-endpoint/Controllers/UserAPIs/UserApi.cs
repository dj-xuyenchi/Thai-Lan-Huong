using dj_actionlayer.Business.PostBusiness;
using dj_actionlayer.Business.UserBusiness;
using dj_webdesigncore.Business.Post;
using dj_webdesigncore.Business.Study;
using dj_webdesigncore.Business.UserIBusiness;
using dj_webdesigncore.Request.Account;
using dj_webdesigncore.Request.Course;
using dj_webdesigncore.Request.Post;
using dj_webdesigncore.Request.SomeThingElse;
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
        private readonly IPostBusiness _post;
        public UserApi()
        {
            _user = new UserBusiness();
            _post = new PostBusiness();
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
        [HttpPost("changepass")]
        public async Task<IActionResult> changePass(RePass request)
        {
            return Ok(await _user.changePass(request));
        }
        [HttpGet("getnotifi")]
        public async Task<IActionResult> notificattionUser(int userId)
        {
            return Ok(await _user.notificationUser(userId));
        }
        [HttpGet("seennoti")]
        public async Task<IActionResult> seenNoti(int notificationId)
        {
            return Ok(await _user.seenNotifi(notificationId));
        }
        [HttpGet("seenallnoti")]
        public async Task<IActionResult> seenAllNoti(int userId)
        {
            return Ok(await _user.seenAllNotifi(userId));
        }
        [HttpGet("getprofile")]
        public async Task<IActionResult> getProfile(int userId)
        {
            return Ok(await _user.getProfile(userId));
        }
        [HttpPost("createpost")]
        public async Task<IActionResult> createPost(PostCreateRequest request)
        {
            return Ok(await _user.createPost(request));
        }
        [HttpGet("getwaitpost")]
        public async Task<IActionResult> getWaitPost(int userId)
        {
            return Ok(await _user.getWaitPost(userId));
        }
        [HttpGet("ishavewaitpost")]
        public async Task<IActionResult> isHaveWaitPost(int userId)
        {
            return Ok(await _user.isHaveWaitPost(userId));
        }
        [HttpGet("deletewaitpost")]
        public async Task<IActionResult> deleteWaitPost(int userId)
        {
            return Ok(await _user.deleteWaitPost(userId));
        }
        [HttpPost("confirmpost")]
        public async Task<IActionResult> confirmPost([FromForm] IFormFile img, [FromForm] string data, [FromForm] int userId)
        {
            UserConfirmPost userConfirmPost= JsonConvert.DeserializeObject<UserConfirmPost>(data);
            return Ok(await _user.confirmPost(img, userConfirmPost, userId));
        }
        [HttpGet("userlikepost")]
        public async Task<IActionResult> userlikePost(int userId, int postId)
        {
            return Ok(await _post.userLikePost(userId, postId));
        }
        [HttpGet("usercmtpost")]
        public async Task<IActionResult> userCmtPost(int userId, int postId, string content)
        {
            return Ok(await _post.userCmtPost(userId, postId, content));
        }
        [HttpGet("usersubcmtpost")]
        public async Task<IActionResult> userSubCmtPost(int userId, string content, int cmtId)
        {
            return Ok(await _post.userSubCmtPost(userId, content, cmtId));
        }
        [HttpGet("mypost")]
        public async Task<IActionResult> getMyPost(int userId)
        {
            return Ok(await _post.myPost(userId));
        }
        [HttpGet("likecmtpost")]
        public async Task<IActionResult> likeCmtPost(int userId, int cmtId)
        {
            return Ok(await _post.userLikeCmtPost(userId, cmtId));
        }
        [HttpPost("createdenounce")]
        public async Task<IActionResult> createDenounce(DenounceRequest denounceRequest)
        {
            return Ok(await _user.CreateDenounce(denounceRequest));
        }
        [HttpGet("getmycertificate")]
        public async Task<IActionResult> getMyCertificate(int userId)
        {
            return Ok(await _user.GetAllCerti(userId));
        }
    }
}
