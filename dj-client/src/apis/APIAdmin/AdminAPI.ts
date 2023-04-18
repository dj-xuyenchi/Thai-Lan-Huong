import { HTTP } from "../HTTPs";
import { Error } from "@/store/redirect";
class AdminAPI {
  getLesson(token: string): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.get("/admin/getlesson", {
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
}
export default new AdminAPI();
