<template>
  <div>
    <HeaderSlider :slide="slide" />
    <CourseList
      :courseList="courseList"
      :studentStudyed="studentStudyed"
      :studentStudying="studentStudying"
    />
    <CodeHome />
    <ContactAdvice />
    <PostList :postList="postList" />
    <BlogList :blogList="blogList" />
  </div>
</template>

<script>
import HeaderSlider from "./HeaderSlider.vue";
import CourseList from "./CourseList.vue";
import PostList from "./PostList.vue";
import BlogList from "./BlogList.vue";
import CodeHome from "./CodeHome.vue";
import ContactAdvice from "./ContactAdvice.vue";
import HomeAPI from "../../apis/APIHome/HomeAPI";
import { mapMutations } from "vuex";

export default {
  name: "AppNewFeed",
  components: {
    HeaderSlider,
    CourseList,
    PostList,
    BlogList,
    ContactAdvice,
    CodeHome,
  },
  data: () => {
    return {
      courseList: [],
      studentStudyed: 0,
      studentStudying: 0,
      postList: [],
      blogList: [],
      slide: [],
      footer: {},
    };
  },
  created() {
    this.getLobbyData();
    var sp = document.querySelector(".echbay-sms-messenger");
    sp.style.display = "block";
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
      this.slide = data.data.slide;
      this.setIsLoadedData(false);
    },
  },
};
</script>

<style lang="css" scoped></style>
