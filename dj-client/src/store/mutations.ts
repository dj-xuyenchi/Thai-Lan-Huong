import TokenModel from "@/entities/AuthEntities/TokenModel";

export default {
  setUserCheckIn(state: any, tokenModel: TokenModel) {
    state.userCheckIn = tokenModel;
  },
  setUserNameLogIn(state: any, userNameLogIn: string) {
    state.userNameLogIn = userNameLogIn;
  },
};
