import { createRouter, createWebHistory, RouteRecordRaw } from "vue-router";
import LobbyMain from "../views/MainLobby/LobbyMain.vue";
import LogIn from "../views/Door/LogIn.vue";
import AppNewFeedVue from "@/components/MainHome/AppNewFeed.vue";
import CourseDetail from "@/components/Course/CourseDetail.vue";
import StudyMain from "@/components/StudyMonitor/StudyMain.vue";
import CourseMonitor from "@/components/Course/CourseMonitor.vue";
import PostMonitor from "@/components/Post/PostMonitor.vue";
import ForwardToHome from "../views/ForwardToHome.vue";
import AdminLayout from "@/components/Admin/AdminLayout.vue";
import DashboardAdmin from "@/components/Admin/DashboardAdmin.vue";
import LessonAdmin from "@/components/Admin/Lesson/LessonAdmin.vue";
import ChapterAdmin from "@/components/Admin/Chapter/ChapterAdmin.vue";
import CourseAdmin from "@/components/Admin/Course/CourseAdmin.vue";
const routes: Array<RouteRecordRaw> = [
  {
    path: "",
    name: "",
    component: ForwardToHome,
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
    path: "/study/:id/:idCourse",
    name: "study",
    component: StudyMain,
  },
  {
    path: "/admin",
    name: "admin",
    component: AdminLayout,
    children: [
      {
        path: "dashboard",
        component: DashboardAdmin,
      },
      {
        path: "lesson",
        component: LessonAdmin,
      },
      {
        path: "chapter",
        component: ChapterAdmin,
      },
      {
        path: "course",
        component: CourseAdmin,
      },
    ],
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
