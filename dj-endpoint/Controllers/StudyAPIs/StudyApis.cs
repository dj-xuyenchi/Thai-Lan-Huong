using dj_actionlayer.Business.Study;
using dj_webdesigncore.Business.Study;
using dj_webdesigncore.Enums.CourseEnums;
using dj_webdesigncore.Request.Course;
using dj_webdesigncore.Request.Lesson;
using dj_webdesigncore.Request.SomeThingElse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dj_endpoint.Controllers.StudyAPIs
{
    [Authorize(Policy = "ADMINANDMEMBER")]
    [Route("/study")]
    public class StudyAPIs : BaseApi
    {
        private readonly IStudyBusiness _study;

        public StudyAPIs()
        {
            this._study = new StudyBusiness();
        }
        [HttpGet("checkmember")]
        public async Task<IActionResult> checkAdmin()
        {
            return Ok("MemberOrAdmin");
        }
        [HttpGet("getcommentoflesson")]
        public async Task<IActionResult> getCommentOfLesson(int? lessonId, int? userId)
        {
            return Ok(await _study.CommentOfLesson(lessonId, userId));
        }

        [HttpGet("getlessondetail")]
        public async Task<IActionResult> getLesson(int? lessonId, int? userId, int? courseId)
        {
            int type = (int)_appContext.lesson.Find(lessonId).LessonTypeId;
            switch (type)
            {
                case 1:
                    return Ok(await _study.VideoLessonContent(lessonId, userId, courseId));
                case 2:
                    return Ok(await _study.PracticeLessonContent(lessonId, userId, courseId));
                case 3:
                    return Ok(await _study.QuestionLessonContent(lessonId, userId, courseId));
                default:
                    return BadRequest();
            }
        }

        [HttpPost("trytestcase")]
        public async Task<IActionResult> tryTestCase(CodeRequest codeRequest)
        {
            return Ok(await _study.TryTestCase(codeRequest));
        }

        [HttpPost("registercourse")]
        public async Task<IActionResult> registerCourse(RegisterCourse registerCourse)
        {
            return Ok(await _study.RegisterCourse(registerCourse));
        }

        [HttpPost("commentlesson")]
        public async Task<IActionResult> commentLesson(CommentLessonRequest commentLessonRequest)
        {
            return Ok(await _study.CommentLesson(commentLessonRequest));
        }
        [HttpPost("subcommentlesson")]
        public async Task<IActionResult> commentLesson(SubCommentLessonRequest subCommentLessonRequest)
        {
            return Ok(await _study.SubCommentLesson(subCommentLessonRequest));
        }
        [HttpPost("likecommentlesson")]
        public async Task<IActionResult> likeCommentLesson(LikeComment likeComment)
        {
            return Ok(await _study.LikeComment(likeComment));
        }
        [HttpPost("sendcodeok")]
        public async Task<IActionResult> sendCodeOk(SendPracticeRequest sendPracticeRequest)
        {
            return Ok(await _study.SendPracticeOk(sendPracticeRequest));
        }
        [HttpPost("sendquestionok")]
        public async Task<IActionResult> sendQuestionAnswer(SendQuestionRequest sendQuestionRequest)
        {
            return Ok(await _study.SendQuestionAnswer(sendQuestionRequest));
        }
        [HttpPost("sendvideook")]
        public async Task<IActionResult> sendVideoOk(SendVideoDoneRequest sendVideoDoneRequest)
        {
            return Ok(await _study.SendVideoDoneRequest(sendVideoDoneRequest));
        }
        [HttpGet("getchapterlessonofuser")]
        public async Task<IActionResult> lessonListOfUser(int? userId, int? courseId)
        {
            return Ok(await _study.LessonListOfUser(userId, courseId));
        }
        [HttpGet("getalllangue")]
        public async Task<IActionResult> getAllLangue()
        {
            return Ok(await _study.getAllLangue());
        }
        [HttpGet("gettestcaseofpracticeid")]
        public async Task<IActionResult> getTestCaseOfPractice(int practiceLessonId)
        {
            return Ok(await _study.getTestCaseOfPractice(practiceLessonId));
        }
        [HttpGet("getdenounce")]
        public async Task<IActionResult> getDenounce()
        {
            return Ok(await _study.getDenounce());
        }
        [HttpPost("createdenounce")]
        public async Task<IActionResult> createDenounce(DenounceRequest denounceRequest)
        {
            return Ok(await _study.CreateDenounce(denounceRequest));
        }
       
    }
}
