import TokenModel from "@/entities/AuthEntities/TokenModel";
import { HTTP } from "../HTTPs";
class AuthApis {
  getLogin(userName: string, password: string): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.get(`/login/getlogin?userName=${userName}&password=${password}`)
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

  //   detail(id: number): Promise<CamNhanHocVien> {
  //     return new Promise<CamNhanHocVien>((resolve: any, reject: any) => {
  //       HTTP.get("camnhanhocvien/" + id)
  //         .then((response) => {
  //           resolve(response.data);
  //         })
  //         .catch((error) => {
  //           reject(error);
  //         });
  //     });
  //   }
  //   update(id: number, camNhanHocVien: CamNhanHocVien): Promise<CamNhanHocVien> {
  //     return new Promise<CamNhanHocVien>((resolve: any, reject: any) => {
  //       HTTP.put("camnhanhocvien/" + id, camNhanHocVien)
  //         .then((response) => {
  //           resolve(response.data);
  //         })
  //         .catch((error) => {
  //           reject(error);
  //         });
  //     });
  //   }
  //   insert(camNhanHocVien: CamNhanHocVien): Promise<CamNhanHocVien> {
  //     return new Promise<CamNhanHocVien>((resolve: any, reject: any) => {
  //       HTTP.post("camnhanhocvien", camNhanHocVien)
  //         .then((response) => {
  //           resolve(response.data);
  //         })
  //         .catch((error) => {
  //           reject(error);
  //         });
  //     });
  //   }
  //   delete(id: number): Promise<CamNhanHocVien> {
  //     return new Promise<CamNhanHocVien>((resolve: any, reject: any) => {
  //       HTTP.delete("camnhanhocvien/" + id)
  //         .then((response) => {
  //           resolve(response.data);
  //         })
  //         .catch((error) => {
  //           reject(error);
  //         });
  //     });
  //   }
}
export default new AuthApis();