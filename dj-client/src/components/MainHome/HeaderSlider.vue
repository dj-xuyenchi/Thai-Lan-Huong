<template>
  <div style="margin-bottom: 40px">
    <v-carousel
      class="container rounded-xl"
      cycle
      height="480"
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
  </div>
</template>
<script>
export default {
  data() {
    return {
      slides: ["First", "Second", "Third", "Fourth", "Fifth"],
      sources: [
        "https://lh5.googleusercontent.com/Tq3T_cBpRqRz9mAoHjDj9LaYjLuuY2ypncFbUb-Gxl4OyaIX7ZT1pKBpc85eUeQ0_UlYl2BTTfBRpngi-hAqydqtg3-ULSpGjTA5uDCZ1NIDCdr6YLYdlUAgvBFzBdKaYUHXs9hW",
        "https://elearning-vnuhcm.vn/pluginfile.php/356/course/overviewfiles/1-3.png",
        "https://techvccloud.mediacdn.vn/2018/4/5/lap-trinh-vien-dev-15228984151521972318542-74-0-523-800-crop-15228984234982004020009.jpg",
        "https://dcv.vn/wp-content/uploads/2020/09/4fb5d63ad2042d5a7415.jpg",
        "https://blogdaytinhoc.com/public/files/images/2022/10/12/hoc-lap-trinh-tai-tphcm.jpg",
        "https://aptechvietnam.com.vn/wp-content/uploads/banner-pc_48.png",
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
