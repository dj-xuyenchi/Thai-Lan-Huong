<template>
  <div style="margin-bottom: 40px">
    <v-carousel
      class="container rounded-xl"
      cycle
      hide-delimiter-background
      show-arrows="hover"
      height="400"
    >
      <v-carousel-item v-for="(slide, i) in slides" :key="i">
        <v-sheet height="100%" width="100%">
          <div class="d-flex fill-height justify-center align-center">
            <img :src="sources[i]" alt="" style="width: 100%" />
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
      sources: [
        "https://tuhoclaptrinh.edu.vn/upload/post/2022/07/04/hoc-lap-trinh-can-luu-y-nhung-gi-20220704102621-884273.jpg",
        "https://tino.org/wp-content/uploads/2021/09/word-image-62-1024x532.jpeg",
        "https://thpt-lequydon-quangtri.edu.vn/wp-content/uploads/2022/03/nnlt-web.png",
        "https://co-well.vn/wp-content/uploads/2019/10/banner-copy.jpg",
        "https://media.techmaster.vn/api/fileman/Uploads/ImageBlog/ky-nang-lap-trinh-vien-gioi-1.jpg",
        "https://datacollection.gso.gov.vn/Data/Images/Article/4c3a2427-e8eb-4b58-a6eb-30fa762b8ff8.jpg",
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
