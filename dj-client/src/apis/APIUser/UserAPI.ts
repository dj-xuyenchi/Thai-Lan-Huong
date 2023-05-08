import { HTTP } from "../HTTPs";
import { Error } from "@/store/redirect";
class UserAPI {
  getUserInfor(userId: number, token: string): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.get(`/user/getuserinformation?userId=${userId}`, {
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
  getOptionUpdate(token: string): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.get(`/user/getoptionupdate`, {
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
export default new UserAPI();
