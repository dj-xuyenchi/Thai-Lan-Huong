import { createStore } from "vuex";
import state from "./states";
import getters from "./getters";
import mutations from "./mutations";
import actions from "./actions";
const store = createStore<any>({
  state,
  getters,
  mutations,
  actions,
});
export default store;
