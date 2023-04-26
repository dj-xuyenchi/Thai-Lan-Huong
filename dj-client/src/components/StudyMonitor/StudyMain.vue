<template>
  <div class="study-main-container">
    <StudyHeader :courseName="lessonData.courseName" courseProcess="1%/100%" />
    <!-- <VideoLesson
      :videoPath="lessonData.studyDetail.videoUrl"
      v-if="lessonData.lessonType == 1"
    />
    <PracticeLesson
      :practiceData="lessonData.studyDetail"
      v-if="lessonData.lessonType == 2"
    /> -->
    <QuizLesson />
    <div
      style="
        margin-left: 5%;
        margin-top: 12px;
        margin-bottom: 100px;
        position: relative;
      "
    >
      <LessonComment style="float: left" />
      <LessonList
        style="margin-left: 12px; float: left"
        :chapterList="lessonData.chapterDetail"
      />
      <div style="float: left; margin-left: 12px">
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
import PracticeLesson from "./PracticeLesson.vue";
import QuizLesson from "./QuizLesson.vue";
import { mapGetters } from "vuex";
import StudyAPI from "../../apis/APIStudy/StudyAPI.ts";
import { mapMutations } from "vuex";
export default {
  name: "StudyMain",
  components: {
    StudyHeader,
    StudyFooter,
    LessonComment,
    LessonList,
    // VideoLesson,
    // PracticeLesson,
    QuizLesson,
  },
  data() {
    return {
      lessonData: Object,
    };
  },
  computed: {},
  created() {
    const token = localStorage.getItem("token");
    const userId = localStorage.getItem("id");
    this.getLessonDetail(
      this.$route.params.id,
      userId,
      this.$route.params.idCourse,
      token
    );
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    async getLessonDetail(lessonId, userId, courseId, token) {
      this.setIsLoadedData(true);
      const data = await StudyAPI.getLessonDetail(
        lessonId,
        userId,
        courseId,
        token
      );
      this.lessonData = data.data;
      console.log(this.lessonData);
      this.setIsLoadedData(false);
    },
  },
};
</script>

<style lang="css" scoped>
.study-main-container {
  height: 92vh;
  width: 100%;
}
.study-main-container .video-container {
  width: 90%;
  height: 80vh;
  margin-left: 5%;
  margin-top: 62px;
}
</style>
