export const Error = (err: any) => {
  switch (err.response.status) {
    case 401:
      document.cookie = "token=;expires=Thu, 01 Jan 1970 00:00:01 GMT;";
      document.cookie = "refreshToken=;expires=Thu, 01 Jan 1970 00:00:01 GMT;";
      localStorage.removeItem("token");
      localStorage.removeItem("refreshToken");
      localStorage.removeItem("avatar");
      localStorage.removeItem("name");
      localStorage.removeItem("id");
      localStorage.removeItem("nickName");
      localStorage.removeItem("role");
      window.location.replace("/#");
      break;
    case 403:
      document.cookie = "token=;expires=Thu, 01 Jan 1970 00:00:01 GMT;";
      document.cookie = "refreshToken=;expires=Thu, 01 Jan 1970 00:00:01 GMT;";
      localStorage.removeItem("token");
      localStorage.removeItem("refreshToken");
      localStorage.removeItem("avatar");
      localStorage.removeItem("name");
      localStorage.removeItem("id");
      localStorage.removeItem("nickName");
      localStorage.removeItem("role");
      window.location.replace("/#");
      break;
  }
};
