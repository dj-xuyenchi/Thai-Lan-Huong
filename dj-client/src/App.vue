<template>
  <v-app>
    <SelectionNav />
    <TopHeader />
    <div id="main-body">
      <v-main class="main-content">
        <router-view />
      </v-main>
    </div>
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
  width: 99%;
}
#main-body {
  margin-left: 116px;
  margin-top: 92px;
}
</style>
