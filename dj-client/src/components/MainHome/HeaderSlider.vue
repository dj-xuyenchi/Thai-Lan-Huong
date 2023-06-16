<template>
  <div style="margin-bottom: 40px">
    <v-carousel
      class="rounded-xl"
      cycle
      hide-delimiter-background
      show-arrows="hover"
      height="600"
    >
      <v-carousel-item v-for="(slide1, i) in slides" :key="i">
        <v-sheet height="100%" width="100%">
          <div class="d-flex fill-height justify-center align-center">
            <img :src="slide[i]" alt="" style="width: 100%" />
          </div>
        </v-sheet>
      </v-carousel-item>
    </v-carousel>
  </div>
</template>
<script>
export default {
  data() {
    return {
      slides: ["First", "Second", "Third", "Fourth", "Fifth"],
    };
  },
  props: {
    slide: Array,
  },
};
</script>
<style scoped>
.container {
  border-radius: 10px;
}
</style>
