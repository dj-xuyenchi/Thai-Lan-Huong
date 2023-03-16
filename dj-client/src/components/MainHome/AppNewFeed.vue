<template>
  <div>
    <HeaderSlider />
    <CourseList />
  </div>
</template>

<script>
import HeaderSlider from "./HeaderSlider.vue";
import CourseList from "./CourseList.vue";
export default {
  name: "AppNewFeed",
  components: { HeaderSlider, CourseList },
  data() {
    return {};
  },
};
</script>

<style lang="scss" scoped></style>
