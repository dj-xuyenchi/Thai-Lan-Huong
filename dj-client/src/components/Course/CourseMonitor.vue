<template>
  <div class="course-monitor-container">
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
    <CourseListByType title="Khóa học Back End" />
    <CourseListByType title="Khóa học Front End" />
    <CourseListByType title="Khóa học CSDL" />
  </div>
</template>

<script>
import CourseListByType from "./CourseListByType";
export default {
  name: "CourseMonitor",
  components: { CourseListByType },
};
</script>

<style lang="css" scoped>
.course-monitor-container {
  margin-left: 3%;
  width: 92%;
}
</style>
