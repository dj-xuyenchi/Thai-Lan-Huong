<template>
  <div d-flex align-start flex-column mb-6 bg-surface-variant>
    <router-link class="text-decoration-none" to="/home">
      <v-btn
        class="btn"
        stacked
        prepend-icon="mdi-home"
        variant="tonal"
        active="true"
        color="#187498"
      >
        Home
      </v-btn>
    </router-link>
    <router-link class="text-decoration-none" to="/home">
      <v-btn
        class="btn"
        stacked
        prepend-icon="mdi-school"
        variant="tonal"
        color="#187498"
      >
        Khóa học
      </v-btn>
    </router-link>
    <router-link class="text-decoration-none" to="/home">
      <v-btn
        class="btn"
        stacked
        prepend-icon="mdi-book"
        variant="tonal"
        color="#187498"
      >
        Bài viết
      </v-btn>
    </router-link>
    <router-link class="text-decoration-none" to="/home">
      <v-btn
        class="btn"
        stacked
        prepend-icon="mdi-update"
        variant="tonal"
        color="#187498"
      >
        Câu đố
      </v-btn>
    </router-link>
  </div>
</template>
<script>
export default {};
</script>
<style scoped>
.btn {
  width: 8vh;
  height: 8vh;
  margin: 14px 14px 0 14px;
}
div {
  /* border-right: 1px solid rgba(0, 0, 0, 0.05); */
  width: 6vw;
  position: fixed;
  height: 92vh;
  top: 8vh;
}
</style>
