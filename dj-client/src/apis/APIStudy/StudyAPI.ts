import { HTTP } from "../HTTPs";
import { Error } from "@/store/redirect";
class StudyAPI {
  getLobbyData(lessonId: number, token: string): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.get(`/study/getcommentoflesson?lessonId=${lessonId}`, {
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
  getLessonDetail(
    lessonId: number,
    userId: number,
    courseId: number,
    token: string
  ): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.get(
        `/study/getlessondetail?lessonId=${lessonId}&userId=${userId}&courseId=${courseId}`,
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
  tryTestCase(
    code: string,
    practiceLessonId: number,
    token: string
  ): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.get(
        `/study/trytestcase?code=${code}&practiceLessonId=${practiceLessonId}`,
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
  registerCourse(resisterCourse: object, token: string): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.post(`/study/registercourse`, resisterCourse, {
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
  commentLesson(commentLesson: object, token: string): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.post(`/study/commentlesson`, commentLesson, {
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
export default new StudyAPI();
