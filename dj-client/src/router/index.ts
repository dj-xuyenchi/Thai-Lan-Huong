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
import TakeCertificate from "@/components/StudyMonitor/TakeCertificate.vue";
import ForwardLesson from "../components/StudyMonitor/ForwardLesson.vue";
import CourseMonitor from "@/components/Course/CourseMonitor.vue";
import PostMonitor from "@/components/Post/PostMonitor.vue";
import ForwardToHome from "../views/ForwardToHome.vue";
import AdminLayout from "@/components/Admin/AdminLayout.vue";
import AnalyticsMain from "@/components/Admin/Analytics/AnalyticsMain.vue";
import AnalyticsApp from "@/components/Admin/Analytics/AnalyticsApp.vue";
import LessonAdmin from "@/components/Admin/Lesson/LessonAdmin.vue";
import ChapterAdmin from "@/components/Admin/Chapter/ChapterAdmin.vue";
import CourseAdmin from "@/components/Admin/Course/CourseAdmin.vue";
import BlogAdmin from "@/components/Admin/Blog/BlogAdmin.vue";
import PostAdmin from "@/components/Admin/Post/PostAdmin.vue";
import UserAdmin from "@/components/Admin/User/UserAdmin.vue";
import AdviceMain from "@/components/Admin/Advice/AdviceMain.vue";
import HomeContent from "@/components/Admin/HomeContent/HomeContent.vue";
import DenounceReport from "@/components/Admin/User/DenounceReport.vue";
import UserDenounce from "@/components/Admin/User/UserDenounce.vue";
import UserMain from "@/components/User/UserMain.vue";
import InforContact from "@/components/User/InforContact.vue";
import CourseResisted from "@/components/User/CourseResisted.vue";
import ChangePassUser from "@/components/User/ChangePassUser.vue";
import UserProfile from "@/components/User/UserProfile.vue";
import UserCreatePost from "@/components/User/UserCreatePost.vue";
import PostPreview from "@/components/User/PostPreview.vue";
import MyPost from "@/components/User/MyPost.vue";
import PostMain from "@/components/Post/PostMain.vue";
import EventMain from "@/components/Even/EventMain.vue";
const routes: Array<RouteRecordRaw> = [
  {
    path: "",
    name: "",
    component: ForwardToHome,
  },
  {
    path: "/profile/:id",
    name: "",
    component: UserProfile,
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
        path: "post/:id/:name",
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
      {
        path: "create-post",
        component: UserCreatePost,
      },
      {
        path: "review",
        component: PostPreview,
      },
      {
        path: "my-post",
        component: MyPost,
      },
      {
        path: "post",
        component: PostMain,
      },
      {
        path: "event-main",
        component: EventMain,
      },
      {
        path: "certificate/:courseId/:userId",
        component: TakeCertificate,
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
        path: "dashboard-seo",
        component: AnalyticsMain,
      },
      {
        path: "dashboard-content",
        component: AnalyticsApp,
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
      {
        path: "blog",
        component: BlogAdmin,
      },
      {
        path: "post",
        component: PostAdmin,
      },
      {
        path: "user",
        component: UserAdmin,
      },
      {
        path: "user-denounce",
        component: UserDenounce,
      },
      {
        path: "user-denounce-report",
        component: DenounceReport,
      },
      {
        path: "home-content",
        component: HomeContent,
      },
      {
        path: "advice",
        component: AdviceMain,
      },
    ],
  },
];

const router = createRouter({
  history: createWebHashHistory(process.env.BASE_URL),
  routes,
});

export default router;
