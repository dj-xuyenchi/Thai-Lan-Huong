<template>
  <v-carousel
    class="container"
    cycle
    height="400"
    hide-delimiter-background
    show-arrows="hover"
  >
    <v-carousel-item v-for="(slide, i) in slides" :key="i">
      <v-sheet height="100%" width="100%">
        <div class="d-flex fill-height justify-center align-center">
          <img :src="sources[i]" alt="" style="width: 100%" />
        </div>
      </v-sheet>
    </v-carousel-item>
  </v-carousel>
</template>
<script>
export default {
  data() {
    return {
      slides: ["First", "Second", "Third", "Fourth", "Fifth"],
      sources: [
        "https://cdn.pixabay.com/photo/2017/11/14/13/06/kitty-2948404__340.jpg",
        "https://cdn.pixabay.com/photo/2017/11/14/13/06/kitty-2948404__340.jpg",
        "https://cdn.pixabay.com/photo/2017/11/14/13/06/kitty-2948404__340.jpg",
        "https://cdn.pixabay.com/photo/2017/11/14/13/06/kitty-2948404__340.jpg",
        "https://cdn.pixabay.com/photo/2017/11/14/13/06/kitty-2948404__340.jpg",
        "https://cdn.pixabay.com/photo/2017/11/14/13/06/kitty-2948404__340.jpg",
      ],
    };
  },
};
</script>
<style scoped>
.container {
  border-radius: 10px;
}
</style>
