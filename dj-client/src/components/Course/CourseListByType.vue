<template>
  <div class="course-list-by-type-container">
    <span
      style="
        color: #242424;
        font-size: 16px;
        font-weight: 900;
        padding-left: 14px;
        font: system-ui, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif,
          'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol';
      "
      >{{ title }}
    </span>
    <CourseItemMonitor
      :courseData="require(`../../../src/assets/course/bec#.jpeg`)"
      studentCount="10"
      courseName="Java Spring"
      courseId="item.courseId"
    />
  </div>
</template>

<script>
import CourseItemMonitor from "./CourseItemMonitor";
export default {
  name: "CourseListByType",
  components: { CourseItemMonitor },
  props: {
    title: String,
  },
};
</script>

<style lang="css" scoped>
.course-list-by-type-container {
  margin-left: 3%;
  width: 92%;
}
</style>
