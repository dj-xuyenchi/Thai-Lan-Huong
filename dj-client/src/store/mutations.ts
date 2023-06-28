export default {
  setIsLoadedData(state: any, isLoadedData: boolean) {
    state.isLoadedData = isLoadedData;
  },
  setActiveMenu(state: any, activeMenu: boolean) {
    state.activeMenu = activeMenu;
  },
  setActiveUserNav(state: any, activeUserNav: boolean) {
    state.activeUserNav = activeUserNav;
  },
  setIsKYC(state: any, isKYC: boolean) {
    state.isKYC = isKYC;
    // localStorage.setItem("isKYC", isKYC);
  },
};
