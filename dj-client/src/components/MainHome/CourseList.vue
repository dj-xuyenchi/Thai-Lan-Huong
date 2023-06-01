<template>
  <div class="course-list-container">
    <div>
      <span
        style="
          color: #82919b;
          font-size: 14px;
          margin-right: 1%;
          padding-left: 14px;
        "
        ><font-awesome-icon
          icon="fa-solid fa-users"
          color="black"
          style="margin-right: 5px"
        /><span style="color: #36ea7c; font-weight: 550"
          >{{ studentStudyed }}+</span
        >
        Học viên đã học</span
      >
      <span style="color: #82919b; font-size: 14px"
        ><font-awesome-icon
          icon="fa-solid fa-users"
          color="black"
          style="margin-right: 5px"
        /><span style="color: #4fc3f7; font-weight: 550"
          >{{ studentStudying }}+</span
        >
        Học viên đang học</span
      >
    </div>
    <span
      style="
        color: #242424;
        font-size: 24px;
        font-weight: 900;
        padding-left: 14px;
        font: system-ui, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif,
          'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol';
      "
      >Danh sách khóa học
    </span>
    <span class="showAll" @click="redirect()">Xem tất cả </span>
    <v-badge
      color="info"
      content="Free"
      floating
      style="font-size: 24px"
    ></v-badge>
    <div class="course-list">
      <CourseItem
        v-for="(item, index) in courseList"
        :key="index"
        :courseData="item.courseImageData"
        :studentCount="item.studentCount"
        :courseName="item.courseName"
        :courseId="item.courseId"
        :isActive="item.isActive"
      />
    </div>
  </div>
</template>

<script>
import CourseItem from "./CourseItem.vue";
import { mapMutations } from "vuex";
export default {
  name: "CourseList",
  components: {
    CourseItem,
  },
  data() {
    return {};
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    redirect() {
      this.$router.push({ path: "/home/courselist" });
    },
  },
  props: {
    courseList: [],
    studentStudying: Number,
    studentStudyed: Number,
  },
};
</script>

<style lang="css" scoped>
.course-list-container {
  margin-left: 3%;
  width: 92%;
  margin-bottom: 20px;
}
.course-list-container .course-list {
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
}
.showAll {
  color: red;
  font-size: 14px;
  font-weight: 900;
  padding-left: 14px;
  float: right;
  font: system-ui, "Segoe UI", Roboto, Helvetica, Arial, sans-serif,
    "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol";
}
.showAll:hover {
  cursor: pointer;
  text-decoration: underline;
  color: #eb5353;
}
@media screen and (max-width: 739px) {
  .course-item {
    width: 100% !important;
  }

  .course-item .item-hover {
    height: 200px !important;
  }

  .course-item img {
    height: 200px !important;
  }
}
@media screen and (max-width: 1023px) and (min-width: 740px) {
  .course-item {
    width: 50% !important;
  }
}

@media screen and (max-width: 1370px) and (min-width: 1023px) {
  .course-item {
    /* width: 33.33% !important; */
  }
}
</style>
