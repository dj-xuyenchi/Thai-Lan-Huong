import TokenModel from "@/entities/AuthEntities/TokenModel";
import { HTTP } from "../HTTPs";
class AuthApis {
  getLogin(requestLogin: object): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.post(`/login/getlogin`, requestLogin)
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }

  refreshToken(tokenModel: TokenModel): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.post(`/login/refresh`, tokenModel)
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }
  signIn(newAccount: object): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.post(`/login/signin`, newAccount)
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }
  confirmAccount(code: string): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.get(`/login/confirmemail?code=` + code)
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }
  forgetPass(forgetRequest: string): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.post(`/login/forgetpass`, forgetRequest)
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }
  confirmCode(code: string): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.get(`login/confirmcodeforgetpass?code=${code}`)
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }
  confirmPass(request: object): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.post(`login/confirmpass`, request)
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }
}
export default new AuthApis();
