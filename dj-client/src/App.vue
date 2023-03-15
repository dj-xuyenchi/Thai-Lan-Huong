<template>
  <v-app>
    <SelectionNav />
    <TopHeader />
    <v-main class="main-content">
      <router-view />
    </v-main>
  </v-app>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import SelectionNav from "./views/MainLobby/SelectionNav.vue";
import TopHeader from "./views/MainLobby/TopHeader.vue";
export default defineComponent({
  name: "App",
  components: {
    SelectionNav,
    TopHeader,
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
  margin-left: 6vw;
  margin-top: 9vh;
  width: 92vw;
}
</style>
