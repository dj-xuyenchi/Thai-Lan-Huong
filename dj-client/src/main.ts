import { createApp } from "vue";
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
} from "@fortawesome/free-solid-svg-icons";
import {
  faCalendarPlus,
  faCalendarDays,
  faComment,
  faComments,
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
  faBook,
  faCalendarPlus,
  faBloggerB,
  faCalendarDays,
  faUsers,
  faEnvelope,
  faPhone,
  faLocationDot,
  faFacebook,
  faYoutube,
  faTiktok,
  faHeart,
  faComment,
  faCheck,
  faChevronLeft,
  faComments,
  faList,
  faPlus,
  faEllipsis,
  faChevronDown,
  faChevronUp,
  faCaretRight,
  faFloppyDisk
);
loadFonts();
createApp(App)
  .component("font-awesome-icon", FontAwesomeIcon)
  .use(router)
  .use(store)
  .use(vuetify)
  .mount("#app");
