<template>
  <v-app>
    <SelectionNav />
    <TopHeader />
    <v-main class="main-content">
      <router-view />
    </v-main>
    <HomeFooter />
  </v-app>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import SelectionNav from "./views/MainLobby/SelectionNav.vue";
import TopHeader from "./views/MainLobby/TopHeader.vue";
import HomeFooter from "./views/MainLobby/HomeFooter.vue";
export default defineComponent({
  name: "App",
  components: {
    SelectionNav,
    TopHeader,
    HomeFooter,
  },
  data() {
    return {
      //
    };
  },
});
</script>
<style scoped>
.main-content {
  margin-left: 6%;
  margin-top: 9vh;
  width: 93%;
}
</style>
