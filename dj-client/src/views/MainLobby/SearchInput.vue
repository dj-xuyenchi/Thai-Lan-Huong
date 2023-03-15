<template>
  <v-card-text class="search-input">
    <v-text-field
      :loading="loading"
      density="compact"
      variant="solo"
      label="Tìm kiếm bài viết, khóa học"
      append-inner-icon="mdi-magnify"
      single-line
      hint="Hướng dẫn tán Crush bằng HTML CSS"
      hide-details
      @click:append-inner="onClick"
    ></v-text-field>
  </v-card-text>
</template>
<script>
export default {
  name: "SearchInput",
  data: () => ({
    loaded: false,
    loading: false,
  }),
  methods: {
    onClick() {
      this.loading = true;
      setTimeout(() => {
        this.loading = false;
        this.loaded = true;
      }, 2000);
    },
  },
};
</script>
<style scoped>
.search-input {
  margin-left: 28vw;
  width: 24vw;
}
</style>
