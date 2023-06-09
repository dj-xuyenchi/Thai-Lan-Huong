<template>
  <v-app>
    <div
      v-if="getIsLoadedData"
      style="
        z-index: 3;
        position: fixed;
        display: flex;
        justify-content: center;
        height: 100vh;
        align-items: center;
        width: 100vw;
      "
    >
      <!-- <img
        :src="require(`./assets/loadingkapoo.gif`)"
        alt="Hình ảnh"
        style="height: 150px"
      /> -->
      <img
        :src="require(`./assets/loading.gif`)"
        alt="Hình ảnh"
        style="position: absolute; top: 40%; width: 200px; height: 150px"
      />
    </div>
    <!-- <v-list-item style="padding: unset"> -->
    <v-list-item :disabled="getIsLoadedData" style="padding: unset">
      <v-main>
        <router-view />
      </v-main>
    </v-list-item>
  </v-app>
</template>
<script lang="ts">
import { defineComponent } from "vue";
import { mapGetters } from "vuex";
import AdminAPI from "./apis/APIAdmin/AdminAPI";
import { mapMutations } from "vuex";
export default defineComponent({
  name: "App",
  data() {
    return {
      data1: "",
    };
  },
  computed: {
    ...mapGetters(["getIsLoadedData"]),
  },
  created() {
    this.isAdmin();
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    async isAdmin() {
      this.setIsLoadedData(true);
      const token = localStorage.getItem("token");
      if (token) {
        const data = await AdminAPI.isMemberOrAdmin(token ? token : "");
      }
      this.setIsLoadedData(false);
    },
  },
});
</script>
<style scoped></style>
