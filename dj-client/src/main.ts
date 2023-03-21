import { createApp } from "vue";
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
} from "@fortawesome/free-solid-svg-icons";
import {
  faCalendarPlus,
  faCalendarDays,
  faComment,
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
  faCheck
);
loadFonts();
createApp(App)
  .component("font-awesome-icon", FontAwesomeIcon)
  .use(router)
  .use(vuetify)
  .mount("#app");
