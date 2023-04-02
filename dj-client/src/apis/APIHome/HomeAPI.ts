import { HTTP } from "../HTTPs";
class HomeAPI {
  getLobbyData(): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.get("/lobby/lobbyhomedata")
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }
  getCourseDetail(courseId: number): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.get(`/lobby/lobbycoursedetail?courseId=${courseId}`)
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }
}
export default new HomeAPI();
