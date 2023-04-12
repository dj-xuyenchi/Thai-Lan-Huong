<template>
  <div class="study-header-container">
    <div class="study-header-item">
      <div style="margin-left: 2.5%; display: flex; align-items: center">
        <font-awesome-icon
          icon="fa-solid fa-chevron-left"
          color="white"
          style="font-size: 20px"
          @click="backToCourse()"
          class="icon-back"
        />
        <img
          style="height: 40px; margin-left: 12px"
          :src="require('../../assets/logo-web.png')"
        />
        <span
          style="
            font-size: 14px;
            margin-left: 14px;
            font-weight: 700;
            color: white;
            font: system-ui, `Segoe UI`, Roboto, Helvetica, Arial, sans-serif,
              `Apple Color Emoji`, `Segoe UI Emoji`, `Segoe UI Symbol`;
          "
          >{{ courseName }}</span
        >
      </div>
    </div>
    <div class="study-header-item">
      <div style="color: white; text-align: right">
        <span>Hoàn thành: </span>
        <span style="margin-right: 2.5%">{{ courseProcess }}</span>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "StudyHeader",
  props: {
    courseName: String,
    courseProcess: String,
  },
  methods: {
    backToCourse() {
      this.$router.push({
        path: "/home/course/" + this.$route.params.idCourse,
      });
    },
  },
};
</script>

<style lang="css" scoped>
.study-header-container {
  width: 100%;
  height: 52px;
  background-color: #29303b;
  position: fixed;
  top: 0;
  display: flex;
  justify-content: space-between;
  align-items: center;
}
.study-header-container .icon-back:hover {
  cursor: pointer;
}
.study-header-container .study-header-item {
  width: 100%;
}
</style>
