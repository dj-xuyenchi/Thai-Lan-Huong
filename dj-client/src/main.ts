import { createApp } from "vue";

import VMdEditor from "@kangc/v-md-editor";
import "@kangc/v-md-editor/lib/style/base-editor.css";
import vuepressTheme from "@kangc/v-md-editor/lib/theme/vuepress.js";
import "@kangc/v-md-editor/lib/theme/style/vuepress.css";
import enUS from "@kangc/v-md-editor/lib/lang/en-US";

import { vi } from "./vi"; // Import tệp ngôn ngữ tiếng Việt bạn đã tạo
// Prism
import Prism from "prismjs";
// highlight code
import "prismjs/components/prism-json";

VMdEditor.use(vuepressTheme, {
  Prism,
});
VMdEditor.lang.use("vi", vi);

// VMdEditor.lang.use("en-US", enUS);

import store from "./store/store";
import App from "./App.vue";
import router from "./router";
import vuetify from "./plugins/vuetify";
import { loadFonts } from "./plugins/webfontloader";
/* import the fontawesome core */
import { library } from "@fortawesome/fontawesome-svg-core";

/* import font awesome icon component */
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";

/* import specific icons */
import {
  faHouse,
  faBook,
  faUsers,
  faPhone,
  faEnvelope,
  faLocationDot,
  faHeart,
  faCheck,
  faChevronLeft,
  faList,
  faPlus,
  faEllipsis,
  faChevronDown,
  faChevronUp,
  faCaretRight,
  faFloppyDisk,
  faChevronRight,
  faRotateRight,
  faPaperPlane,
  faUserDoctor,
  faEye,
  faCertificate,
  faPen,
} from "@fortawesome/free-solid-svg-icons";
import {
  faCalendarPlus,
  faCalendarDays,
  faComment,
  faComments,
  faTrashCan,
  faBell,
} from "@fortawesome/free-regular-svg-icons";
import {
  faBloggerB,
  faFacebook,
  faYoutube,
  faTiktok,
} from "@fortawesome/free-brands-svg-icons";
/* add icons to the library */
library.add(
  faHouse,
  faBell,
  faBook,
  faCalendarPlus,
  faBloggerB,
  faCalendarDays,
  faUsers,
  faEye,
  faPaperPlane,
  faCertificate,
  faTrashCan,
  faEnvelope,
  faPhone,
  faLocationDot,
  faFacebook,
  faYoutube,
  faTiktok,
  faHeart,
  faComment,
  faCheck,
  faUserDoctor,
  faChevronLeft,
  faComments,
  faList,
  faPen,
  faPlus,
  faEllipsis,
  faChevronRight,
  faChevronDown,
  faChevronUp,
  faCaretRight,
  faRotateRight,
  faFloppyDisk
);
loadFonts();
createApp(App)
  .component("font-awesome-icon", FontAwesomeIcon)
  .use(router)
  .use(VMdEditor)
  .use(store)
  .use(vuetify)
  .mount("#app");
