<template>
  <div class="course-list-container">
    <span
      style="
        color: #242424;
        font-size: 24px;
        font-weight: 900;
        font: system-ui, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif,
          'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol';
      "
      >Danh sách khóa học
    </span>
    <v-badge
      color="info"
      content="Free"
      floating
      style="font-size: 18px"
    ></v-badge>
    <div class="course-list">
      <CourseItem class="margin-1-percent" />
      <CourseItem class="margin-1-percent" />
      <CourseItem class="margin-1-percent" />
      <CourseItem />
      <CourseItem class="margin-1-percent" />
      <CourseItem class="margin-1-percent" />
      <CourseItem class="margin-1-percent" />
    </div>
  </div>
</template>

<script>
import CourseItem from "./CourseItem.vue";
export default {
  name: "CourseList",
  components: {
    CourseItem,
  },
};
</script>

<style lang="css" scoped>
.course-list-container {
  margin-left: 4%;
  width: 92%;
}
.margin-1-percent {
  margin-right: 1%;
}
.course-list-container .course-list {
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
}
</style>
