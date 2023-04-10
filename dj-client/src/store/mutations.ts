import LoginAccount from "@/entities/AuthEntities/LoginAccount";
import TokenModel from "@/entities/AuthEntities/TokenModel";

export default {
  setIsLoadedData(state: any, isLoadedData: boolean) {
    state.isLoadedData = isLoadedData;
  },
  setActiveMenu(state: any, activeMenu: boolean) {
    state.activeMenu = activeMenu;
  },
};
