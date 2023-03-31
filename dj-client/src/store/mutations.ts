import LoginAccount from "@/entities/AuthEntities/LoginAccount";
import TokenModel from "@/entities/AuthEntities/TokenModel";

export default {
  setUserCheckIn(state: any, tokenModel: TokenModel) {
    state.userCheckIn = tokenModel;
  },
  setUserNameLogIn(state: any, userNameLogIn: LoginAccount) {
    state.userNameLogIn = userNameLogIn;
  },
  setIsLogIn(state: any, isLogIn: boolean) {
    state.isLogIn = isLogIn;
  },
};
