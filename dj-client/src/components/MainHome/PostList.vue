<template>
  <div class="course-list-container">
    <span
      style="
        color: #242424;
        font-size: 24px;
        font-weight: 900;
        padding-left: 14px;
        font: system-ui, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif,
          'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol';
      "
      >Bài viết nổi bật
    </span>
    <div class="course-list">
      <CourseItem
        coursePath="https://bizflyportal.mediacdn.vn/thumb_wm/1000,100/bizflyportal/images/htm16157917934978.jpg"
      />
    </div>
  </div>
</template>

<script>
import CourseItem from "./CourseItem.vue";
export default {
  name: "PostList",
  components: {
    CourseItem,
  },
};
</script>

<style lang="css" scoped>
.course-list-container {
  margin-left: 3%;
  width: 92%;
}
.course-list-container .course-list {
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
}
</style>
