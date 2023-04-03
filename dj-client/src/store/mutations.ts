import LoginAccount from "@/entities/AuthEntities/LoginAccount";
import TokenModel from "@/entities/AuthEntities/TokenModel";

export default {
  setUserCheckIn(state: any, tokenModel: TokenModel) {
    state.userCheckIn = tokenModel;
  },
  setUserLogIn(state: any, userLogIn: LoginAccount) {
    state.userLogIn = userLogIn;
  },
  setIsLogIn(state: any, isLogIn: boolean) {
    state.isLogIn = isLogIn;
  },
  setIsLoadedData(state: any, isLoadedData: boolean) {
    state.isLoadedData = isLoadedData;
  },
};
