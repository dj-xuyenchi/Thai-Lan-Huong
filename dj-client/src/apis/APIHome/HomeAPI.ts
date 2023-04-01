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
export default new HomeAPI();
