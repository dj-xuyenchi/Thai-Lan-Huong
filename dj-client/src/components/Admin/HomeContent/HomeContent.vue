<template>
  <div>
    <div>
      <v-carousel
        class="container rounded-xl"
        cycle
        hide-delimiter-background
        show-arrows="hover"
        height="400"
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
  </div>
</template>

<script>
import AdminAPI from "../../../apis/APIAdmin/AdminAPI";
import { mapMutations } from "vuex";
export default {
  data() {
    return {
      slides: ["First", "Second", "Third", "Fourth", "Fifth"],
      slide: [],
    };
  },
  created() {
    this.getHomeSlide();
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    async getHomeSlide() {
      this.setIsLoadedData(true);
      const token = localStorage.getItem("token");
      const data = await AdminAPI.getHomeContent(token);
      this.slide.push(data.data.slide1);
      this.slide.push(data.data.slide2);
      this.slide.push(data.data.slide3);
      this.slide.push(data.data.slide4);
      this.slide.push(data.data.slide5);
      this.setIsLoadedData(false);
    },
  },
};
</script>

<style lang="scss" scoped></style>
