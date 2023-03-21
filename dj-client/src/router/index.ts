import { createRouter, createWebHistory, RouteRecordRaw } from "vue-router";
import LobbyMain from "../views/MainLobby/LobbyMain.vue";
import LoginUser from "../components/Login/LoginUser.vue";
import AppNewFeedVue from "@/components/MainHome/AppNewFeed.vue";
import CourseMonitor from "@/components/Course/CourseMonitor.vue";
import CourseDetail from "@/components/Course/CourseDetail.vue";
const routes: Array<RouteRecordRaw> = [
  {
    path: "",
    name: "",
    component: LobbyMain,
  },
  {
    path: "/home",
    name: "home",
    component: LobbyMain,
    children: [
      {
        path: "lobby",
        component: AppNewFeedVue,
      },
      {
        path: "course",
        component: CourseDetail,
      },
    ],
  },
  {
    path: "/login",
    name: "login",
    component: LoginUser,
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
