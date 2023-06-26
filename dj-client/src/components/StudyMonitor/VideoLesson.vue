<template>
  <div class="video-container">
    <iframe
      width="100%"
      height="100%"
      :src="videoPath"
      title="YouTube video player"
      frameborder="0"
      allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share"
      allowfullscreen
    ></iframe>
    <v-snackbar v-model="snackbarOk" multi-line>
      {{ snackBarContent }}
      <template v-slot:actions>
        <v-btn color="green" variant="text" @click="snackbarOk = false">
          Đóng
        </v-btn>
      </template>
    </v-snackbar>
  </div>
</template>

<script>
import StudyAPI from "../../apis/APIStudy/StudyAPI.ts";
export default {
  name: "VideoLesson",
  data() {
    return {
      snackbarOk: false,
      snackBarContent: "",
    };
  },
  props: {
    videoPath: String,
    passCourse: Function,
  },
  methods: {
    async sendQuestion() {
      const token = localStorage.getItem("token");
      const userId = localStorage.getItem("id");
      const result = await StudyAPI.sendVideoOk(
        {
          UserId: userId,
          LessonId: this.$route.params.id,
          CourseId: this.$route.params.idCourse,
          ChapterId: this.$route.params.idChapter,
        },
        token
      );
      if (result.data == 7) {
        this.snackBarContent = "Đã mở bài học mới!";
        this.snackbarOk = true;
        return;
      }
      if (result.data == 11) {
        this.snackBarContent =
          "Chúc mừng bạn đã hoàn thành khóa học bạn có thể nhận chứng chỉ tại Chứng chỉ của tôi!";
        this.snackbarOk = true;
        this.passCourse();
        return;
      }
    },
  },
  mounted() {
    setTimeout(() => {
      this.sendQuestion();
    }, 60000);
  },
};
</script>

<style lang="css" scoped></style>
