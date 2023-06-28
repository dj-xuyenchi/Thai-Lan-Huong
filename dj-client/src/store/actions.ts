export default {
  updateUserCheckIn(context: any) {
    context.commit("setUserCheckIn", {});
  },
  updateUserName(context: any) {
    console.log("context :>> ", context);
    context.commit("setUserNameLogIn", "Hương Mộc Trà");
  },
};
