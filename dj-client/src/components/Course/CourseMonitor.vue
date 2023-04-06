<template>
  <div class="course-monitor-container">
    <div style="margin-bottom: 12px">
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
      <v-badge
        color="info"
        content="Free"
        floating
        style="font-size: 24px"
      ></v-badge>
    </div>

    <CourseListByType
      v-for="(item, index) in listCourse"
      :key="index"
      :title="item.courseType"
      :listCourse="item.courseListByType"
    />
  </div>
</template>

<script>
import CourseListByType from "./CourseListByType";
import HomeApi from "../../apis/APIHome/HomeAPI.ts";
import { mapMutations } from "vuex";
export default {
  name: "CourseMonitor",
  components: { CourseListByType },
  data() {
    return {
      listCourse: [],
    };
  },
  mounted() {
    this.getCourseList();
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    async getCourseList() {
      this.setIsLoadedData(true);
      const data = await HomeApi.getCourseList();
      this.listCourse = data.data;
      this.setIsLoadedData(false);
    },
  },
};
</script>
<style lang="css" scoped>
.course-monitor-container {
  margin-left: 3%;
  width: 92%;
}
</style>
