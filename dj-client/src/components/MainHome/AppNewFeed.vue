<template>
  <div>
    <HeaderSlider />
    <CourseList />
    <PostList />
  </div>
</template>

<script>
import HeaderSlider from "./HeaderSlider.vue";
import CourseList from "./CourseList.vue";
import PostList from "./PostList.vue";
export default {
  name: "AppNewFeed",
  components: { HeaderSlider, CourseList, PostList },
  data() {
    return {};
  },
};
</script>

<style lang="scss" scoped></style>
