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
  commentOfPost(postId: number, userId: number): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.get(`/lobby/commentofpost?postId=${postId}&userId=${userId}`)
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }
  commmentPost(
    postId: number,
    userId: number,
    content: string,
    token: string
  ): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.get(
        `/user/usercmtpost?userId=${userId}&postId=${postId}&content=${content}`,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      )
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }
  commmentSubPost(
    cmtId: number,
    userId: number,
    content: string,
    token: string
  ): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.get(
        `/user/usersubcmtpost?userId=${userId}&content=${content}&cmtId=${cmtId}`,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      )
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }
  likeComment(userId: number, cmtId: number, token: string): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.get(`/user/likecmtpost?userId=${userId}&cmtId=${cmtId}`, {
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
  getPostMain(): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      HTTP.get(`/lobby/postmain`)
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
