<template>
  <v-app>
    <div>
      <v-main>
        <router-view />
      </v-main>
    </div>
  </v-app>
</template>

<script lang="ts">
import { defineComponent } from "vue";
export default defineComponent({
  name: "App",

  data() {
    return {
      //
    };
  },
});
</script>
<style scoped></style>
