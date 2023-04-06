<template>
  <div>
    <HeaderSlider />
    <CourseList />
    <PostList />
    <BlogList />
  </div>
</template>

<script>
import HeaderSlider from "./HeaderSlider.vue";
import CourseList from "./CourseList.vue";
import PostList from "./PostList.vue";
import BlogList from "./BlogList.vue";
import HomeAPI from "../../apis/APIHome/HomeAPI";
import { mapMutations } from "vuex";
export default {
  name: "AppNewFeed",
  components: { HeaderSlider, CourseList, PostList, BlogList },
  data: () => {
    return {};
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
  },
};
</script>

<style lang="css" scoped></style>
