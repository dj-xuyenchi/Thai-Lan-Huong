import { createRouter, createWebHistory, RouteRecordRaw } from "vue-router";
import AppNewFeed from "../components/MainHome/AppNewFeed.vue";
const routes: Array<RouteRecordRaw> = [
  {
    path: "/home",
    name: "home",
    component: AppNewFeed,
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
