import { createRouter, createWebHistory, RouteRecordRaw } from "vue-router";
import LobbyMain from "../views/MainLobby/LobbyMain.vue";
import LogIn from "../views/Door/LogIn.vue";
import AppNewFeedVue from "@/components/MainHome/AppNewFeed.vue";
import CourseDetail from "@/components/Course/CourseDetail.vue";
import StudyMain from "@/components/StudyMonitor/StudyMain.vue";
import CourseMonitor from "@/components/Course/CourseMonitor.vue";
import PostMonitor from "@/components/Post/PostMonitor.vue";
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
        path: "course/:id",
        component: CourseDetail,
      },
      {
        path: "courselist",
        component: CourseMonitor,
      },
      {
        path: "post/:id",
        component: PostMonitor,
      },
    ],
  },
  {
    path: "/login",
    name: "login",
    component: LogIn,
  },
  {
    path: "/study/:id",
    name: "study",
    component: StudyMain,
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
