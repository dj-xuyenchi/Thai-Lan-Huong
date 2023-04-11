<template>
  <div class="study-main-container">
    <StudyHeader />
    <VideoLesson />
    <div
      style="
        margin-left: 5%;
        margin-top: 12px;
        margin-bottom: 100px;
        position: relative;
      "
    >
      <LessonComment />
      <LessonList style="margin-left: 12px" />
      <div style="position: absolute; right: 5%; top: 0">
        <v-btn color="#4FC3F7" v-bind="props">
          <font-awesome-icon
            icon="fa-solid fa-plus"
            color="black"
            style="font-size: 20px; margin-right: 4px"
          />
          Tạo ghi chú.
        </v-btn>
      </div>
    </div>
    <StudyFooter />
  </div>
</template>

<script>
import StudyHeader from "./StudyHeader.vue";
import StudyFooter from "./StudyFooter.vue";
import LessonComment from "./LessonComment.vue";
import LessonList from "./LessonList.vue";
import VideoLesson from "./VideoLesson.vue";
import HomeApi from "../../apis/APIHome/HomeAPI.ts";
import { mapMutations } from "vuex";
import { mapGetters } from "vuex";
export default {
  name: "StudyMain",
  components: {
    StudyHeader,
    StudyFooter,
    LessonComment,
    LessonList,
    VideoLesson,
  },
  mounted() {
    const token = localStorage.getItem("token");
    const refreshToken = localStorage.getItem("refreshToken");
    if (!token || !refreshToken) {
      this.$router.push({ path: "/login" });
    }
  },
  computed: {},
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    // async getCourseDetail(courseId, userId) {
    //   this.setIsLoadedData(true);
    //   const data = await HomeApi.getCourseDetail(courseId, userId);
    //   this.courseTitle = data.data.courseTitle;
    //   this.courseSubTitle = data.data.courseSubTitle;
    //   this.courseProfit = data.data.courseProfit;
    //   this.courseRequire = data.data.courseRequire;
    //   this.timeTotal = data.data.timeTotal;
    //   this.chapterCount = data.data.chapterCount;
    //   this.lessonCount = data.data.lessonCount;
    //   this.chapterDetail = data.data.chapterDetail;
    //   this.setIsLoadedData(false);
    // },
  },
};
</script>

<style lang="css" scoped>
.study-main-container {
  height: 100%;
  width: 100%;
}
.study-main-container .video-container {
  width: 90%;
  height: 80vh;
  margin-left: 5%;
  margin-top: 62px;
}
</style>
