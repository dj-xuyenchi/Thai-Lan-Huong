import { HTTP } from "../HTTPs";
import { Error } from "@/store/redirect";
class AdminAPI {
  getLessonPage(page: number, token: string): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.get(`/admin/getlessonpage?page=${page}`, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      })
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          Error(error);
          reject(error);
        });
    });
  }
  getChapterPage(page: number, token: string): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.get(`/admin/getchapterpage?page=${page}`, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      })
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          Error(error);
          reject(error);
        });
    });
  }
  getCoursePage(page: number, token: string): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.get(`/admin/getcoursepage?page=${page}`, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      })
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          Error(error);
          reject(error);
        });
    });
  }
  isAdmin(token: string): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.get("/admin/checkadmin", {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      })
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          Error(error);
          reject(error);
        });
    });
  }
  isMemberOrAdmin(token: string): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.get("/study/checkmember", {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      })
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          Error(error);
          reject(error);
        });
    });
  }
  addPracticeLesson(practiceLesson: object, token: string): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.post("/admin/addpracticelesson", practiceLesson, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      })
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          Error(error);
          reject(error);
        });
    });
  }
  addTheoryLesson(theoryRequest: object, token: string): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.post("/admin/addtheorylesson", theoryRequest, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      })
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          Error(error);
          reject(error);
        });
    });
  }
  addQuestionLesson(questionRequest: object, token: string): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.post("/admin/addquestionlesson", questionRequest, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      })
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          Error(error);
          reject(error);
        });
    });
  }
  updatePracticeLesson(
    lessonId: number,
    practiceRequest: object,
    token: string
  ): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.post(
        `/admin/updatepracticelesson?lessonId=${lessonId}`,
        practiceRequest,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      )
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          Error(error);
          reject(error);
        });
    });
  }
  updateQuestionLesson(
    lessonId: number,
    questionRequest: object,
    token: string
  ): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.post(
        `/admin/updatequestionlesson?lessonId=${lessonId}`,
        questionRequest,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      )
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          Error(error);
          reject(error);
        });
    });
  }
  updateTheoryLesson(
    lessonId: number,
    theoryRequest: object,
    token: string
  ): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.post(
        `/admin/updatetheorylesson?lessonId=${lessonId}`,
        theoryRequest,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      )
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          Error(error);
          reject(error);
        });
    });
  }
  getCourseForChapter(token: string): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.get(`/admin/selectcourseforchapter`, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      })
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          Error(error);
          reject(error);
        });
    });
  }
  addChapter(addChapterRequest: object, token: string): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.post(`/admin/addchapter`, addChapterRequest, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      })
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          Error(error);
          reject(error);
        });
    });
  }
  updateChapter(updateChapterRequest: object, token: string): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.post(`/admin/updatechapter`, updateChapterRequest, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      })
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          Error(error);
          reject(error);
        });
    });
  }
  getAllTestCase(practiceId: number, token: string): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.get(`/admin/gettestcase?practiceId=${practiceId}`, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      })
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          Error(error);
          reject(error);
        });
    });
  }
  addTestCase(testCase: object, token: string): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.post(`/admin/addtestcase`, testCase, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      })
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          Error(error);
          reject(error);
        });
    });
  }
  updateTestCase(
    testCaseId: number,
    testCase: object,
    token: string
  ): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.post(`/admin/updatetestcase?testCaseId=${testCaseId}`, testCase, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      })
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          Error(error);
          reject(error);
        });
    });
  }
  deleteTestCase(testCaseId: number, token: string): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.get(`/admin/deletetestcase?testCaseId=${testCaseId}`, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      })
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          Error(error);
          reject(error);
        });
    });
  }
  getLessonOfChapter(chapterId: number, token: string): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.get(`/admin/getlessonofchapter?chapterId=${chapterId}`, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      })
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          Error(error);
          reject(error);
        });
    });
  }

  updateSortNumberLesson(
    updateSortNumberLessonRequest: object,
    token: string
  ): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.post(
        `/admin/updatesortnumberlesson`,
        updateSortNumberLessonRequest,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      )
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          Error(error);
          reject(error);
        });
    });
  }
  addLesson2Chapter(
    updateSortNumberLessonRequest: object,
    token: string
  ): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.post(`/admin/addlesson2chapter`, updateSortNumberLessonRequest, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      })
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          Error(error);
          reject(error);
        });
    });
  }
  deleteLessonOfChapter(lessonChapterId: number, token: string): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.get(
        `/admin/deletelessonofchapter?lessonChapterId=${lessonChapterId}`,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      )
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          Error(error);
          reject(error);
        });
    });
  }
  getLessonNotInChapter(token: string): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.get(`/admin/getlessonnotinchapter`, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      })
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          Error(error);
          reject(error);
        });
    });
  }
}
export default new AdminAPI();
