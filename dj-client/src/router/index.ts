import {
  createRouter,
  createWebHistory,
  createWebHashHistory,
  RouteRecordRaw,
} from "vue-router";
import LobbyMain from "../views/MainLobby/LobbyMain.vue";
import LogIn from "../views/Door/LogIn.vue";
import SignIn from "../views/Door/SignIn.vue";
import ConfirmEmail from "../views/Door/ConfirmEmail.vue";
import ConfirmForgetPass from "../views/Door/ConfirmForgetPass.vue";
import ChangePass from "../views/Door/ChangePass.vue";
import ForgetPass from "../views/Door/ForgetPass.vue";
import ForwardRequestForgetPass from "../views/Door/ForwardRequestForgetPass.vue";
import CheckConfirm from "../views/Door/CheckConfirm.vue";
import AppNewFeedVue from "@/components/MainHome/AppNewFeed.vue";
import CourseDetail from "@/components/Course/CourseDetail.vue";
import StudyMain from "@/components/StudyMonitor/StudyMain.vue";
import ForwardLesson from "../components/StudyMonitor/ForwardLesson.vue";
import CourseMonitor from "@/components/Course/CourseMonitor.vue";
import PostMonitor from "@/components/Post/PostMonitor.vue";
import ForwardToHome from "../views/ForwardToHome.vue";
import AdminLayout from "@/components/Admin/AdminLayout.vue";
import DashboardAdmin from "@/components/Admin/DashboardAdmin.vue";
import LessonAdmin from "@/components/Admin/Lesson/LessonAdmin.vue";
import ChapterAdmin from "@/components/Admin/Chapter/ChapterAdmin.vue";
import CourseAdmin from "@/components/Admin/Course/CourseAdmin.vue";
import UserMain from "@/components/User/UserMain.vue";
import InforContact from "@/components/User/InforContact.vue";
import CourseResisted from "@/components/User/CourseResisted.vue";
import ChangePassUser from "@/components/User/ChangePassUser.vue";
const routes: Array<RouteRecordRaw> = [
  {
    path: "",
    name: "",
    component: ForwardToHome,
  },
  {
    path: "/forget",
    name: "",
    component: ForgetPass,
  },
  {
    path: "/forwardlesson",
    name: "forwardlesson",
    component: ForwardLesson,
  },
  {
    path: "/forwardrequestforgetpass/:code",
    name: "forwardrequestforgetpass",
    component: ForwardRequestForgetPass,
  },
  {
    path: "/confirmforgetpass",
    name: "",
    component: ConfirmForgetPass,
  },
  {
    path: "/changepass",
    name: "",
    component: ChangePass,
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
      {
        path: "user",
        component: UserMain,
        children: [
          {
            path: "inforcontact",
            component: InforContact,
          },
          {
            path: "courseresisted",
            component: CourseResisted,
          },
          {
            path: "changpass",
            component: ChangePassUser,
          },
        ],
      },
    ],
  },
  {
    path: "/login",
    name: "login",
    component: LogIn,
  },
  {
    path: "/signin",
    name: "signin",
    component: SignIn,
  },
  {
    path: "/confirm",
    name: "confirm",
    component: ConfirmEmail,
  },
  {
    path: "/checkconfirm/:code",
    name: "checkconfirm",
    component: CheckConfirm,
  },
  {
    path: "/study/:id/:idCourse/:idChapter",
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
  history: createWebHashHistory(process.env.BASE_URL),
  routes,
});

export default router;
