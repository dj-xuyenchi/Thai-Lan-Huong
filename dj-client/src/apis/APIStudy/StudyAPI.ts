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
}
export default new StudyAPI();
