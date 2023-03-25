import { createStore } from "vuex";
interface State {
  user: string;
}

const store = createStore<State>({});
export default store;
