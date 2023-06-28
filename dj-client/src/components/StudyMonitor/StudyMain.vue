<template>
  <div class="study-main-container">
    <StudyHeader
      :isPass="isPass"
      :courseName="lessonData.courseName"
      :process="lessonData.courseProcess"
      courseProcess="1%/100%"
    />
    <VideoLesson
      :passCourse="passCourse"
      :videoPath="lessonData.studyDetail.videoUrl"
      v-if="lessonData.lessonType == 1"
    />
    <PracticeLesson
      :practiceData="lessonData.studyDetail"
      v-if="lessonData.lessonType == 2"
    />
    <QuizLesson
      :data="lessonData.studyDetail"
      v-if="lessonData.lessonType == 3"
    />
    <div
      style="
        margin-left: 5%;
        margin-top: 12px;
        margin-bottom: 100px;
        position: relative;
      "
    >
      <LessonComment :handleDialog="handleDialog" style="float: left" />
      <LessonList
        style="margin-left: 12px; float: left"
        :chapterList="lessonData.chapterDetail"
      />
      <!-- <div
        style="float: left; margin-left: 12px"
        v-if="lessonData.lessonType == 1"
      >
        <v-btn color="#4FC3F7" v-bind="props">
          <font-awesome-icon
            icon="fa-solid fa-plus"
            color="black"
            style="font-size: 20px; margin-right: 4px"
          />
          Tạo ghi chú.
        </v-btn>
      </div> -->
    </div>
    <div class="text-center">
      <v-dialog v-model="dialog" activator="parent" width="800">
        <v-card>
          <v-card-text>
            Bạn cảm thấy bình luận này không an toàn hoặc không phù hợp?
            <v-col cols="4" sm="4" md="4">
              <v-select
                v-model="type"
                label="Loại vi phạm"
                :items="listDenounce"
                item-title="denounceName"
                persistent-hint
                return-object
                item-value="id"
                variant="outlined"
              ></v-select>
            </v-col>
            <v-col cols="12" sm="12" md="12">
              <v-textarea
                v-model="note"
                density="compact"
                label="Ghi chú của bạn"
                hint="Ghi chú của bạn về bình luận"
                variant="outlined"
                max-rows="5"
              ></v-textarea>
            </v-col>
          </v-card-text>
          <v-spacer></v-spacer>
          <v-btn color="blue-darken-1" variant="text" @click="createDenounce()">
            Gửi báo cáo
          </v-btn>
          <v-btn color="blue-darken-1" variant="text" @click="dialog = false">
            Hủy
          </v-btn>
        </v-card>
      </v-dialog>
    </div>
    <img
      v-if="phaoHoa"
      :src="require(`../../assets/phaohoa.gif`)"
      alt="Hình ảnh"
      style="height: 400px; position: absolute; bottom: 10%; left: 30%"
    />
    <StudyFooter />
  </div>
  <v-snackbar v-model="snackbar">
    {{ text }}
    <template v-slot:actions>
      <v-btn color="green" variant="text" @click="snackbar = false">
        Đóng
      </v-btn>
    </template>
  </v-snackbar>
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
    VideoLesson,
    PracticeLesson,
    QuizLesson,
  },
  data() {
    return {
      lessonData: Object,
      type: "",
      note: "",
      text: "",
      snackbar: false,
      cmtId: 0,
      isPass: false,
      phaoHoa: false,
      listDenounce: [],
      dialog: false,
    };
  },
  created() {
    const token = localStorage.getItem("token");
    const userId = localStorage.getItem("id");
    this.getLessonDetail(
      this.$route.params.id,
      userId,
      this.$route.params.idCourse,
      token
    );
    this.getDenounce(token);
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    handleDialog(id) {
      this.dialog = true;
      this.cmtId = id;
    },
    async createDenounce() {
      const token = localStorage.getItem("token");
      const data = await StudyAPI.createDenounce(
        {
          UserSendId: localStorage.getItem("id"),
          Note: this.note,
          CmtId: this.cmtId,
          TypeId: this.type.id,
          URL: window.location.href,
        },
        token
      );
      if (data.data == 1) {
        this.text =
          "Gửi báo cáo thành công chúng tôi sẽ xem sét trường hợp bạn yêu cầu!";
        this.note = "";
        this.snackbar = true;
      } else if (data.data == 6) {
        this.text = "Bạn không thể báo cáo chính bạn!";
        this.note = "";
        this.snackbar = true;
      } else {
        this.text = "Gửi báo cáo không thành công!";
        this.note = "";
        this.snackbar = true;
      }
      this.dialog = false;
    },
    async getLessonDetail(lessonId, userId, courseId, token) {
      this.setIsLoadedData(true);
      const data = await StudyAPI.getLessonDetail(
        lessonId,
        userId,
        courseId,
        token
      );
      this.lessonData = data.data;
      this.setIsLoadedData(false);
    },
    async getDenounce(token) {
      const data = await StudyAPI.getDenounce(token);
      this.listDenounce = data;
      this.type = data[0];
    },
    passCourse() {
      this.isPass = true;
      this.phaoHoa = true;
      setTimeout(() => {
        this.phaoHoa = false;
      }, 5000);
    },
  },
};
</script>

<style lang="css" scoped>
.study-main-container {
  min-height: 100vh;
  display: inline-block;
  width: 100%;
}
.study-main-container .video-container {
  width: 90%;
  height: 80vh;
  margin-left: 5%;
  margin-top: 62px;
}
</style>
