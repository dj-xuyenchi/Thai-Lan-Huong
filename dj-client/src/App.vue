<template>
  <v-app>
    <SelectionNav class="select-navs" />
    <v-main class="main-content">
      <router-view />
    </v-main>
  </v-app>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import SelectionNav from "./views/MainLobby/SelectionNav.vue";
export default defineComponent({
  name: "App",
  components: {
    SelectionNav,
  },
  data() {
    return {
      //
    };
  },
});
</script>
<style scoped>
.select-navs {
  position: fixed;
  z-index: 1;
  width: 8%;
}
.select-navs:hover .main-content {
  width: 70%;
}
.main-content {
  margin-left: 2.5%;
  width: 90%;
}
</style>
