<template>
  <div>
    <HeaderSlider />
    <CourseList
      :courseList="courseList"
      :studentStudyed="studentStudyed"
      :studentStudying="studentStudying"
    />
    <PostList :postList="postList" />
    <BlogList :blogList="blogList" />
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
  components: {
    HeaderSlider,
    CourseList,
    PostList,
    BlogList,
  },
  data: () => {
    return {
      courseList: [],
      studentStudyed: 0,
      studentStudying: 0,
      postList: [],
      blogList: [],
    };
  },
  created() {
    this.getLobbyData();
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    async getLobbyData() {
      this.setIsLoadedData(true);
      const data = await HomeAPI.getLobbyData();
      this.courseList = data.data.listActiveCourse?.courseDTOs;
      this.postList = data.data.listPost;
      this.blogList = data.data.blog;
      this.studentStudyed = data.data.listActiveCourse.studyedStudent;
      this.studentStudying = data.data.listActiveCourse.studyingStudent;
      this.setIsLoadedData(false);
    },
  },
};
</script>

<style lang="css" scoped></style>
