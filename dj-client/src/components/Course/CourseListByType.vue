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
      >Khóa học {{ title }}
    </span>
    <div class="course-list">
      <CourseItemMonitor
        v-for="(item, index) in listCourse"
        :courseData="item.courseImageData"
        :key="index"
        :studentCount="item.studentCount"
        :courseName="item.courseName"
        :courseId="item.courseId"
        :isActive="item.isActive"
      />
    </div>
  </div>
</template>

<script>
import CourseItemMonitor from "./CourseItemMonitor";
export default {
  name: "CourseListByType",
  components: { CourseItemMonitor },
  props: {
    title: String,
    listCourse: [],
  },
};
</script>

<style lang="css" scoped>
.course-list-by-type-container {
  margin-left: 2%;
  margin-bottom: 40px;
  width: 93%;
}
.course-list-by-type-container .course-list {
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
}
</style>
