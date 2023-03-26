import axios, { AxiosRequestConfig, AxiosInstance } from "axios";
//axios 1.3.4
export class HTTPSingleton {
  private static instance: HTTPSingleton;
  private static config: AxiosRequestConfig = {
    baseURL: "https://localhost:44375/",
    headers: {
      "Content-Type": "application/json",
      "Access-Control-Allow-Origin": "*",
    },
    timeout: 1000000,
    responseType: "json",
    xsrfCookieName: "XSRF-TOKEN",
    xsrfHeaderName: "X-XSRF-TOKEN",
  };
  private HTTP: AxiosInstance;
  private constructor() {
    this.HTTP = axios.create(HTTPSingleton.config);
  }
  static getInstance() {
    if (!HTTPSingleton.instance) {
      HTTPSingleton.instance = new HTTPSingleton();
    }
    return HTTPSingleton.instance;
  }
  getHTTP(): AxiosInstance {
    return this.HTTP;
  }
}
// Exemple api
//  getData: () => {
//     return new Promise((resolve: any, reject: any) => {
//       HTTP.get(`api/hocvien/hihi`)
//         .then((response: any) => {
//           resolve(response.data);g
//         })
//         .catch((error: any) => {
//           reject(error);
//         });
//     });
//   },
export const HTTP: AxiosInstance = HTTPSingleton.getInstance().getHTTP();
