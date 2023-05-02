using dj_webdesigncore.Business.Admin;
using dj_webdesigncore.DTOs;
using dj_webdesigncore.DTOs.Admin;
using dj_webdesigncore.Entities.CourseEntity;
using dj_webdesigncore.Request.Chapter;
using dj_webdesigncore.Request.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_actionlayer.Business.Admin
{
    public class AdminBusiness : BaseBusiness, IAdminBusiness
    {
        public async Task<ResponData<AddChapterDTO>> addChapter(AddChapterRequest addChapterRequest)
        {
            ResponData<AddChapterDTO> result = new ResponData<AddChapterDTO>();
            AddChapterDTO data = new AddChapterDTO();
            try
            {
                CourseChapter courseChapter = new CourseChapter();
                courseChapter.ChapterCreateDateTime = DateTime.Now;
                courseChapter.ChapterTotalTime = addChapterRequest.ChapterTotalTime;
                courseChapter.ChapterName = addChapterRequest.ChapterName;
                courseChapter.CourseId = addChapterRequest.CourseId;
                var lastChapter = _context.course_chapter.Where(x => x.CourseId == addChapterRequest.CourseId).OrderByDescending(x => x.SortNumber).FirstOrDefault();
                if (lastChapter == null)
                {
                    courseChapter.SortNumber = 1;
                }
                else
                {
                    courseChapter.SortNumber = lastChapter.SortNumber + 1;
                }
                await _context.AddAsync(courseChapter);
                await _context.SaveChangesAsync();
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            catch (Exception ex)
            {
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.FAILED;
                result.Messenger = "Lấy dữ liệu thất bại! Exception: " + ex.Message;
                return result;
            }
        }

        public async Task<ResponData<AddLessonDTO>> addPracticeLesson(dj_webdesigncore.Request.Lesson.PracticeLesson practiceLesson)
        {
            ResponData<AddLessonDTO> result = new ResponData<AddLessonDTO>();
            AddLessonDTO data = new AddLessonDTO();
            try
            {
            Lesson lesson = new Lesson();
            lesson.LessonStatusId = 1;
            lesson.LessonName = practiceLesson.lessonName;
            lesson.LessonDescription = practiceLesson.lessonDescription;
            lesson.VideoTime = practiceLesson.lessonTime;
            lesson.CreateDateTime=DateTime.Now;
            lesson.LessonTypeId = 2;
            await _context.AddAsync(lesson);
            await _context.SaveChangesAsync();
            dj_webdesigncore.Entities.CourseEntity.PracticeLesson practiceNew = new dj_webdesigncore.Entities.CourseEntity.PracticeLesson();
            practiceNew.LessonId = lesson.Id;
            practiceNew.BeginCodeMethod = practiceLesson.beginCode;
            practiceNew.Problem= practiceLesson.problem;
            practiceNew.ProblemDetail= practiceLesson.problemDetail;
            practiceNew.CallTestCode = practiceLesson.callTestCode;
            practiceNew.ExpectOutput= practiceLesson.outputExemple;
            practiceNew.Input= practiceLesson.inputExemple;
            practiceNew.Suggest = practiceLesson.suggest;
            practiceNew.Explain= practiceLesson.explainCode;
            await _context.AddAsync(practiceNew);
            await _context.SaveChangesAsync();
            TestCase defaultTestCase = new TestCase();
            defaultTestCase.ExpectOutput=practiceNew.ExpectOutput;
            defaultTestCase.Input = practiceNew.Input;      
            defaultTestCase.PracticeLessonId = practiceNew.Id;
            defaultTestCase.LockTestCase = false;
            defaultTestCase.InputDetail = practiceLesson.caseDefaultDetail;
            defaultTestCase.SortNumber = 1;
            await _context.AddAsync(defaultTestCase);
            await _context.SaveChangesAsync();
            data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.SECCESSFULLY;
            data.Mes = "Thêm bài học thành công!";
            result.Data = data;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
            }catch(Exception ex)
            {
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.FAILED;
                result.Messenger = "Lấy dữ liệu thất bại! Exception: " + ex.Message;
                return result;
            }
        }

        public async Task<ResponData<AddLessonDTO>> addQuestionLesson(QuestionLessonRequest questionLessonRequest)
        {
            ResponData<AddLessonDTO> result = new ResponData<AddLessonDTO>();
            AddLessonDTO data = new AddLessonDTO();
            try
            {
                Lesson lesson = new Lesson();
                lesson.LessonStatusId = 1;
                lesson.LessonName = questionLessonRequest.lessonName;
                lesson.LessonDescription = questionLessonRequest.lessonDescription;
                lesson.VideoTime = questionLessonRequest.lessonTime;
                lesson.CreateDateTime = DateTime.Now;
                lesson.LessonTypeId = 3;
                await _context.AddAsync(lesson);
                await _context.SaveChangesAsync();
                QuestionLesson questionLesson = new QuestionLesson();
                questionLesson.LessonId = lesson.Id;
                questionLesson.AnswerA = questionLessonRequest.answerA;
                questionLesson.AnswerB= questionLessonRequest.answerB;
                questionLesson.AnswerC = questionLessonRequest.answerC;
                questionLesson.AnswerD = questionLessonRequest.answerD;
                questionLesson.Answer = questionLessonRequest.answer;
                questionLesson.Question = questionLessonRequest.question;
                await _context.AddAsync(questionLesson);
                await _context.SaveChangesAsync();
                data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.SECCESSFULLY;
                data.Mes = "Thêm bài học thành công!";
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            catch (Exception ex)
            {
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.FAILED;
                result.Messenger = "Lấy dữ liệu thất bại! Exception: " + ex.Message;
                return result;
            }
        }

        public async Task<ResponData<AddTestCaseDTO>> addTestCase(TestCaseRequest testCaseRequest)
        {
            ResponData<AddTestCaseDTO> result = new ResponData<AddTestCaseDTO>();
            AddTestCaseDTO data = new AddTestCaseDTO();
            try
            {
                var lastCase = _context.test_case.Where(x => x.PracticeLessonId == testCaseRequest.PracticeId).OrderByDescending(x => x.SortNumber).FirstOrDefault();
                TestCase testCase = new TestCase();
                testCase.ExpectOutput = testCaseRequest.Output;
                testCase.Input = testCaseRequest.Input;
                testCase.InputDetail = testCaseRequest.InputDetail;
                testCase.LockTestCase = testCaseRequest.IsLock;
                testCase.PracticeLessonId = testCaseRequest.PracticeId;
                testCase.SortNumber = lastCase.SortNumber + 1;
                await _context.AddAsync(testCase);
                await _context.SaveChangesAsync();
                data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.SECCESSFULLY;
                data.Mes = "Thêm bài học thành công!";
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            catch (Exception ex)
            {
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.FAILED;
                result.Messenger = "Lấy dữ liệu thất bại! Exception: " + ex.Message;
                return result;
            }
        }

        public async Task<ResponData<AddLessonDTO>> addTheoryLesson(TheoryLessonRequest theoryLessonRequest)
        {
            ResponData<AddLessonDTO> result = new ResponData<AddLessonDTO>();
            AddLessonDTO data = new AddLessonDTO();
            try
            {
                Lesson lesson = new Lesson();
                lesson.LessonStatusId = 1;
                lesson.LessonName = theoryLessonRequest.lessonName;
                lesson.LessonDescription = theoryLessonRequest.lessonDescription;
                lesson.VideoTime = theoryLessonRequest.lessonTime;
                lesson.CreateDateTime = DateTime.Now;
                lesson.LessonTypeId = 1;
                await _context.AddAsync(lesson);
                await _context.SaveChangesAsync();
                VideoLesson videoLesson = new VideoLesson();
                videoLesson.LessonId = lesson.Id;
                videoLesson.LessonLinkUrl = theoryLessonRequest.videoLink;
                await _context.AddAsync(videoLesson);
                await _context.SaveChangesAsync();
                data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.SECCESSFULLY;
                data.Mes = "Thêm bài học thành công!";
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            catch (Exception ex)
            {
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.FAILED;
                result.Messenger = "Lấy dữ liệu thất bại! Exception: " + ex.Message;
                return result;
            }
        }

        public async Task<ResponData<List<TestCaseDTO>>> getAllTestCase(int practiceId)
        {
            ResponData<List<TestCaseDTO>> result = new ResponData<List<TestCaseDTO>>();
            try
            {
                List<TestCaseDTO> data = new List<TestCaseDTO>();
                var testList = _context.test_case.Where(x => x.PracticeLessonId == practiceId).OrderBy(x=>x.SortNumber).ToList();
                foreach(var item in testList)
                {
                    TestCaseDTO testCaseDTO = new TestCaseDTO();
                    testCaseDTO.Input = item.Input;
                    testCaseDTO.Output = item.ExpectOutput;
                    testCaseDTO.SortNumber = item.SortNumber;
                    testCaseDTO.TestCaseDetail = item.InputDetail;
                    testCaseDTO.IsLock = item.LockTestCase;
                    data.Add(testCaseDTO);
                }
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            catch (Exception ex)
            {
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.FAILED;
                result.Messenger = "Lấy dữ liệu thất bại! Exception: " + ex.Message;
                return result;
            }
        }

        public async Task<ResponData<GetChapterDTO>> getChapterPage(int page)
        {
            ResponData<GetChapterDTO> result = new ResponData<GetChapterDTO>();
            GetChapterDTO data = new GetChapterDTO();
            try
            {
                List<ChapterDetailDTO> chapterDetail = new List<ChapterDetailDTO>();
                var listChapter = _context.course_chapter.OrderByDescending(x => x.ChapterCreateDateTime).Skip((page - 1) * 10).Take(10).ToList();
                foreach (var item in listChapter)
                {
                    ChapterDetailDTO chapterDetailDTO = new ChapterDetailDTO();
                    chapterDetailDTO.ChapterId = item.Id;
                    chapterDetailDTO.ChapterName = item.ChapterName;
                    chapterDetailDTO.CreateDateTime = item.ChapterCreateDateTime.Day + " - " + item.ChapterCreateDateTime.Month + " - " + item.ChapterCreateDateTime.Year;
                    chapterDetailDTO.TimeTotal = item.ChapterTotalTime;
                    chapterDetailDTO.LessonCount = _context.chapter_lesson.Where(x => x.CourseChapterId == item.Id).Count().ToString();
                    chapterDetail.Add(chapterDetailDTO);
                }
                data.list = chapterDetail;
                int size = _context.lesson.Count();
                data.maxPage = _context.lesson.Count() / 10;
                if (size % 10 != 0&&size>10)
                {
                    data.maxPage++;
                }
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            catch (Exception ex)
            {
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.FAILED;
                result.Messenger = "Lấy dữ liệu thất bại! Exception: " + ex.Message;
                return result;
            }
        }

        public async Task<ResponData<GetCourseDTO>> getCoursePage(int page)
        {
            ResponData<GetCourseDTO> result = new ResponData<GetCourseDTO>();
            GetCourseDTO data = new GetCourseDTO();
            try
            {
                List<CourseDetailDTO> courseDetailDTOs = new List<CourseDetailDTO>();
                var listCourse = _context.course.Skip((page - 1) * 10).Take(10).ToList();
                foreach (var item in listCourse)
                {
                    CourseDetailDTO courseDetailDTO = new CourseDetailDTO();
                    courseDetailDTO.ChapterCount = item.ChapterCount + " học phần";
                    courseDetailDTO.CourseCode = item.CourseCode;
                    courseDetailDTO.CourseName = item.CourseName;
                    courseDetailDTO.CourseLevel = _context.course_level.Find(item.CourseLevelId).LevelName;
                    courseDetailDTO.CourseStatus = _context.course_status.Find(item.CourseStatusId).CourseStatusName;
                    courseDetailDTO.CourseImageData = item.CourseImageData;
                    courseDetailDTO.CourseSubTitle = item.CourseSubTitle;
                    courseDetailDTO.CourseType = _context.course_type.Find(item.CourseTypeId).CourseTypeName;
                    courseDetailDTO.CourseTypeId=item.CourseTypeId;
                    courseDetailDTO.TimeLessonTotal = item.TimeLessonTotal;
                    courseDetailDTOs.Add(courseDetailDTO);
                }
                data.list = courseDetailDTOs;
                int size = _context.lesson.Count();
                data.maxPage = _context.lesson.Count() / 10;
                if (size % 10 != 0 && size > 10)
                {
                    data.maxPage++;
                }
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            catch (Exception ex)
            {
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.FAILED;
                result.Messenger = "Lấy dữ liệu thất bại! Exception: " + ex.Message;
                return result;
            }
        }

        public async Task<ResponData<GetLessonDTO>> getLessonPage(int page)
        {
            ResponData<GetLessonDTO> result = new ResponData<GetLessonDTO>();
            GetLessonDTO data = new GetLessonDTO();
            try
            {
                List<LessonDetailDTO> lessonDetailDTO = new List<LessonDetailDTO>();
                var listLesson = _context.lesson.OrderByDescending(x=>x.CreateDateTime).Skip((page-1)*10).Take(10).ToList();
                foreach (var item in listLesson)
                {
                    LessonDetailDTO lessonDetail = new LessonDetailDTO();
                    lessonDetail.LessonId = item.Id;
                    lessonDetail.LessonDescription = item.LessonDescription;
                    lessonDetail.LessonName = item.LessonName;
                    lessonDetail.CreateDateTime = item.CreateDateTime.Day + " - " + item.CreateDateTime.Month + " - " + item.CreateDateTime.Year;
                    lessonDetail.VideoTime = item.VideoTime;
                    lessonDetail.LessonType = _context.lesson_type.Find(item.LessonTypeId).LessonTypeName;
                    lessonDetail.LessonTypeId = (int)item.LessonTypeId;
                    if (item.UpdateDateTime != null)
                    {
                        lessonDetail.UpdateDateTime = item.UpdateDateTime.Value.Day + " - " + item.UpdateDateTime.Value.Month + " - " + item.UpdateDateTime.Value.Year;
                    }
                    else
                    {
                        lessonDetail.UpdateDateTime = "";
                    }
                    if (item.LessonTypeId == 3)
                    {
                        QuestionLesson questionLesson = _context.question_lesson.Where(x => x.LessonId == item.Id).FirstOrDefault();
                        if (questionLesson == null)
                        {
                            continue;
                        }
                        lessonDetail.question = questionLesson.Question;
                        lessonDetail.answerA = questionLesson.AnswerA;
                        lessonDetail.answerB = questionLesson.AnswerB;
                        lessonDetail.answerC = questionLesson.AnswerC;
                        lessonDetail.answerD = questionLesson.AnswerD;
                        switch (questionLesson.Answer)
                        {
                            case 1:
                                lessonDetail.answer = "A";
                                break;
                            case 2:
                                lessonDetail.answer = "B";
                                break;
                            case 3:
                                lessonDetail.answer = "C";
                                break;
                            case 4:
                                lessonDetail.answer = "D";
                                break;
                        }
                    }
                    if (item.LessonTypeId == 2)
                    {
                        dj_webdesigncore.Entities.CourseEntity.PracticeLesson practiceLesson = _context.practice_lesson.Where(x => x.LessonId == item.Id).FirstOrDefault();
                        TestCase testCase = _context.test_case.Where(x => x.PracticeLessonId == practiceLesson.Id&&x.SortNumber==1).FirstOrDefault();
                        lessonDetail.problem = practiceLesson.Problem;
                        lessonDetail.practiceId = practiceLesson.Id;
                        lessonDetail.problemDetail = practiceLesson.ProblemDetail;
                        lessonDetail.outputExemple = practiceLesson.ExpectOutput;
                        lessonDetail.suggest = practiceLesson.Suggest;
                        lessonDetail.inputExemple = practiceLesson.Input;
                        lessonDetail.beginCode = practiceLesson.BeginCodeMethod;
                        lessonDetail.callTestCode = practiceLesson.CallTestCode;
                        lessonDetail.caseDefaultDetail = testCase.InputDetail;
                        lessonDetail.explainCode = practiceLesson.Explain;
                    }
                    if (item.LessonTypeId == 1)
                    {
                        VideoLesson videoLesson=_context.video_lesson.Where(x => x.LessonId == item.Id).FirstOrDefault();
                       
                        lessonDetail.linkVideo = videoLesson.LessonLinkUrl;
                    }
                    lessonDetailDTO.Add(lessonDetail);
                }
                data.list = lessonDetailDTO;
                int size = _context.lesson.Count();
                data.maxPage = _context.lesson.Count() / 10;
                if (size % 10 != 0 && size > 10)
                {
                    data.maxPage++;
                }
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            catch (Exception ex)
            {
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.FAILED;
                result.Messenger = "Lấy dữ liệu thất bại! Exception: " + ex.Message;
                return result;
            }
        }

        public async Task<ResponData<List<SelectCourseForChapter>>> selectCourseForChapter()
        {
            ResponData<List<SelectCourseForChapter>> result = new ResponData<List<SelectCourseForChapter>>();
            var listCourse = _context.course.ToList();
            List<SelectCourseForChapter> data = new List<SelectCourseForChapter>();
            foreach(var item in listCourse)
            {
                data.Add(new SelectCourseForChapter()
                {
                    CourseId = item.Id,
                    CourseName = item.CourseName
                });
            }
            result.Data = data;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }

        public async Task<ResponData<AddChapterDTO>> updateChapter(UpdateChapterRequest updateChapterRequest)
        {
            ResponData<AddChapterDTO> result = new ResponData<AddChapterDTO>();
            AddChapterDTO data = new AddChapterDTO();
            try
            {
                CourseChapter courseChapter = await _context.course_chapter.FindAsync(updateChapterRequest.ChapterId);
                if(courseChapter == null)
                {
                    data.Mes = "Không tồn tại học phần!";
                    data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.NOTFOUND;
                    result.Data = data;
                    result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                    result.Messenger = "Lấy dữ liệu thành công!";
                    return result;
                }
                courseChapter.ChapterLessonCount = updateChapterRequest.LessonCount;
                courseChapter.ChapterName = updateChapterRequest.ChapterName;
                courseChapter.ChapterTotalTime = updateChapterRequest.ChapterTotalTime;
                await _context.SaveChangesAsync();
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            catch(Exception ex)
            {
                data.Mes = "Lỗi";
                data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.FAILED;
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.FAILED;
                result.Messenger = "Lấy dữ liệu thất bại! Exception: " + ex.Message;
                return result;
            }
        }

        public async Task<ResponData<AddLessonDTO>> updatePracticeLesson(int lessonId, dj_webdesigncore.Request.Lesson.PracticeLesson practiceLesson)
        {
            ResponData<AddLessonDTO> result = new ResponData<AddLessonDTO>();
            AddLessonDTO data = new AddLessonDTO();
            Lesson lesson = await _context.lesson.FindAsync(lessonId);
            if (lesson == null)
            {
                data.Mes = "Không tồn tại bài học có Id là "+lessonId;
                data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.NOTFOUND;
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            try
            {
                lesson.UpdateDateTime = DateTime.Now;
                lesson.LessonDescription = practiceLesson.lessonDescription;
                lesson.LessonName = practiceLesson.lessonName;
                lesson.VideoTime = practiceLesson.lessonTime;
                dj_webdesigncore.Entities.CourseEntity.PracticeLesson practice = _context.practice_lesson.Where(x => x.LessonId == lesson.Id).FirstOrDefault();
                practice.BeginCodeMethod = practiceLesson.beginCode;
                practice.CallTestCode = practiceLesson.callTestCode;
                practice.ExpectOutput = practiceLesson.outputExemple;
                practice.Explain = practiceLesson.explainCode;
                practice.Input = practiceLesson.inputExemple;
                practice.Problem = practiceLesson.problem;
                practice.ProblemDetail = practiceLesson.problemDetail;
                practice.Suggest = practiceLesson.suggest;
                TestCase testCase = _context.test_case.Where(x => x.PracticeLessonId == practice.Id && x.SortNumber == 1).FirstOrDefault();
                testCase.ExpectOutput = practiceLesson.outputExemple;
                testCase.Input = practiceLesson.inputExemple;
                testCase.InputDetail = practiceLesson.caseDefaultDetail;
                await _context.SaveChangesAsync();
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            catch(Exception ex)
            {
                data.Mes = "Lỗi";
                data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.FAILED;
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.FAILED;
                result.Messenger = "Lấy dữ liệu thất bại! Exception: " + ex.Message;
                return result;
            }
        }

        public async Task<ResponData<AddLessonDTO>> updateQuestionLesson(int lessonId, QuestionLessonRequest questionLessonRequest)
        {
            ResponData<AddLessonDTO> result = new ResponData<AddLessonDTO>();
            AddLessonDTO data = new AddLessonDTO();
            Lesson lesson = await _context.lesson.FindAsync(lessonId);
            if (lesson == null)
            {
                data.Mes = "Không tồn tại bài học có Id là " + lessonId;
                data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.NOTFOUND;
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            try
            {
                lesson.UpdateDateTime = DateTime.Now;
                lesson.LessonDescription = questionLessonRequest.lessonDescription;
                lesson.LessonName = questionLessonRequest.lessonName;
                lesson.VideoTime = questionLessonRequest.lessonTime;
                QuestionLesson questionLesson = _context.question_lesson.Where(x => x.LessonId == lesson.Id).FirstOrDefault();
                questionLesson.Answer = questionLessonRequest.answer;
                questionLesson.AnswerA = questionLessonRequest.answerA;
                questionLesson.AnswerB = questionLessonRequest.answerB;
                questionLesson.AnswerC = questionLessonRequest.answerC;
                questionLesson.AnswerD = questionLessonRequest.answerD;
                questionLesson.Question = questionLessonRequest.question;
                await _context.SaveChangesAsync();
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            catch (Exception ex)
            {
                data.Mes = "Lỗi";
                data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.FAILED;
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.FAILED;
                result.Messenger = "Lấy dữ liệu thất bại! Exception: " + ex.Message;
                return result;
            }
        }

        public async Task<ResponData<AddLessonDTO>> updateTheoryLesson(int lessonId, TheoryLessonRequest theoryLessonRequest)
        {
            ResponData<AddLessonDTO> result = new ResponData<AddLessonDTO>();
            AddLessonDTO data = new AddLessonDTO();
            Lesson lesson = await _context.lesson.FindAsync(lessonId);
            if (lesson == null)
            {
                data.Mes = "Không tồn tại bài học có Id là " + lessonId;
                data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.NOTFOUND;
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            try
            {
                lesson.UpdateDateTime = DateTime.Now;
                lesson.LessonDescription = theoryLessonRequest.lessonDescription;
                lesson.LessonName = theoryLessonRequest.lessonName;
                lesson.VideoTime = theoryLessonRequest.lessonTime;
                VideoLesson videoLesson = _context.video_lesson.Where(x => x.LessonId == lesson.Id).FirstOrDefault();
                videoLesson.LessonLinkUrl = theoryLessonRequest.videoLink;
                await _context.SaveChangesAsync();
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            catch (Exception ex)
            {
                data.Mes = "Lỗi";
                data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.FAILED;
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.FAILED;
                result.Messenger = "Lấy dữ liệu thất bại! Exception: " + ex.Message;
                return result;
            }
        }
    }
}
