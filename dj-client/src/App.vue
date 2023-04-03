<template>
  <v-app>
    <v-list-item :disabled="getIsLoadedData" style="padding: unset">
      <v-progress-circular
        :size="50"
        color="primary"
        indeterminate
        v-if="getIsLoadedData"
        style="z-index: 5; position: fixed; top: 40%; left: 50%"
      ></v-progress-circular>
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
