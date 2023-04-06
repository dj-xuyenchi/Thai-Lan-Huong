<template>
  <v-app>
    <div style="z-index: 5; position: fixed; top: 30%; left: 40%">
      <img
        :src="require(`./assets/loadingkapoo.gif`)"
        alt=""
        style="height: 150px"
        v-if="getIsLoadedData"
      />
      <img
        :src="require(`./assets/loading.gif`)"
        alt=""
        style="position: absolute; top: 10px; left: -65%"
        v-if="getIsLoadedData"
      />
    </div>

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
