// Styles
import "vuetify/styles";
import { createVuetify } from "vuetify";
import { aliases, mdi } from "vuetify/iconsets/mdi";

import { VDataTable } from "vuetify/labs/VDataTable";
export default createVuetify({
  icons: {
    defaultSet: "mdi",
    aliases,
    sets: {
      mdi,
    },
  },
  components: {
    VDataTable,
  },
});
// Vuetify
// https://vuetifyjs.com/en/introduction/why-vuetify/#feature-guides
