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
  getCourseDetail(courseId: number, userId: number): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.get(`/lobby/lobbycoursedetail?courseId=${courseId}&userId=${userId}`)
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }
  getCourseList(): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.get(`/lobby/lobbycourselist`)
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }
  sendAdvice(request: object): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.post(`/lobby/sendadvice`, request)
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }
  takeCertificate(courseId: number, userId: number): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.get(`/lobby/certificate?courseId=${courseId}&userId=${userId}`)
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }
  tryCodeHome(tryCode: object): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.post(`/lobby/trycodehome`, tryCode)
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
