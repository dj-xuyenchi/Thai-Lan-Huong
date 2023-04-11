export const Error = (err: any) => {
  switch (err.response.status) {
    case 401:
      window.location.replace("/login");
      break;
  }
};
