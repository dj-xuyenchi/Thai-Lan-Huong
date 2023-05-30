import { HTTP } from "../HTTPs";
class PostAPI {
  getPostDetail(postId: number, userId: number): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.get(`/lobby/getpostdetail?postId=${postId}&userId=${userId}`)
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }
}
export default new PostAPI();
