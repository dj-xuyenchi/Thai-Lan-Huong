import { createStore } from "vuex";

const store = createStore<any>({
  state: {
    name: "as",
  },
  getters: {
    name: (state) => {
      return state.name;
    },
  },
  mutations: {
    setName(state, data) {
      state.name = data.nam;
    },
  },
  actions:{
    
  }
});
export default store;
