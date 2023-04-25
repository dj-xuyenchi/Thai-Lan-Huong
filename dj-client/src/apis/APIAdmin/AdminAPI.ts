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
}
export default new AdminAPI();
