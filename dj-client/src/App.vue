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
      <img
        :src="require(`./assets/loadingkapoo.gif`)"
        alt=""
        style="height: 150px"
      />
      <img
        :src="require(`./assets/loading.gif`)"
        alt=""
        style="position: absolute; top: 45%"
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
});
</script>
<style scoped></style>
