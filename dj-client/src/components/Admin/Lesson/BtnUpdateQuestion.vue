<template>
  <div>
    <v-row>
      <v-dialog v-model="dialog" persistent width="1024">
        <template v-slot:activator="{ props }">
          <v-btn
            color="green"
            v-bind="props"
            density="compact"
            icon="mdi-pencil"
          >
          </v-btn>
        </template>
        <v-form @submit.prevent="submit()" ref="form" style="overflow: scroll">
          <v-card>
            <v-card-title>
              <span class="text-h5">Cập nhật bài quiz</span>
            </v-card-title>
            <v-card-text>
              <v-container>
                <v-row>
                  <v-col cols="12" sm="12" md="12">
                    <v-text-field
                      label="Tên bài học*"
                      hint="Với bài học dạng câu hỏi tên sẽ là Quiz: + tên bài học"
                      v-model="lessonName"
                      :rules="rules"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="6">
                    <v-text-field
                      label="Mô tả*"
                      hint="Mô tả bài học"
                      :rules="rules"
                      v-model="lessonDescription"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="6">
                    <v-text-field
                      label="Thời lượng*"
                      hint="Thời lượng của bài học"
                      :rules="rules"
                      v-model="lessonTime"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12">
                    <v-text-field
                      label="Câu hỏi*"
                      hint="Câu hỏi hiển thị"
                      :rules="rules"
                      v-model="question"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12">
                    <v-text-field
                      label="Đáp án A*"
                      hint="Đáp án A"
                      :rules="rules"
                      v-model="answera"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12">
                    <v-text-field
                      label="Đáp án B*"
                      hint="Đáp án B"
                      :rules="rules"
                      v-model="answerb"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12">
                    <v-text-field
                      label="Đáp án C*"
                      hint="Đáp án C"
                      :rules="rules"
                      v-model="answerc"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12">
                    <v-text-field
                      label="Đáp án D*"
                      hint="Đáp án D"
                      :rules="rules"
                      v-model="answerd"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12">
                    <v-select
                      label="Đáp án đúng"
                      :items="['A', 'B', 'C', 'D']"
                      :rules="rules"
                      v-model="answer"
                    ></v-select>
                  </v-col>
                </v-row>
              </v-container>
              <small>* là trường là bắt buộc!</small>
            </v-card-text>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn
                color="blue-darken-1"
                variant="text"
                @click="dialog = false"
              >
                Hủy
              </v-btn>
              <v-btn
                color="blue-darken-1"
                :loading="btnLoading"
                variant="text"
                type="submit"
              >
                Cập nhật
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-form>
      </v-dialog>
    </v-row>
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
import AdminAPI from "../../../apis/APIAdmin/AdminAPI.ts";
import { mapMutations } from "vuex";
export default {
  name: "BtnUpdateQuestion",
  data() {
    return {
      text: "",
      snackbar: false,
      lessonName: "",
      lessonDescription: "",
      lessonTime: "",
      question: "",
      answera: "",
      answerb: "",
      answerc: "",
      answerd: "",
      btnLoading: false,
      answer: "A",
      dialog: false,
      rules: [
        (value) => {
          if (value) return true;
          return "Không được để trống!";
        },
      ],
    };
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    getData() {
      var answerResult;
      switch (this.answer) {
        case "A":
          answerResult = 1;
          break;
        case "B":
          answerResult = 2;
          break;
        case "C":
          answerResult = 3;
          break;
        case "D":
          answerResult = 4;
          break;
        default:
          break;
      }
      return {
        lessonName: this.lessonName,
        lessonDescription: this.lessonDescription,
        lessonTime: this.lessonTime,
        question: this.question,
        answerA: this.answera,
        answerB: this.answerb,
        answerC: this.answerc,
        answerD: this.answerd,
        answer: answerResult,
      };
    },
    async submit() {
      this.btnLoading = true;
      if (
        this.lessonName.trim().length < 1 ||
        this.lessonDescription.trim().length < 1 ||
        this.lessonTime.trim().length < 1 ||
        this.question.trim().length < 1 ||
        this.answera.trim().length < 1 ||
        this.answerb.trim().length < 1 ||
        this.answerc.trim().length < 1 ||
        this.answerd.trim().length < 1
      ) {
        this.btnLoading = false;
        return;
      }
      const token = localStorage.getItem("token");
      const result = await AdminAPI.updateQuestionLesson(
        this.lessonId,
        this.getData(),
        token
      );
      if (result.status == 1) {
        this.text = "Cập nhật thành công";
        this.dialog = false;
        this.snackbar = true;
        this.getLessonDetail();
      }
      if (result.status == 2) {
        this.text = "Cập nhật thất bại";
        this.snackbar = true;
      }
      this.btnLoading = false;
    },
  },
  mounted() {
    this.lessonName = this.item.lessonName;
    this.lessonDescription = this.item.lessonDescription;
    this.lessonTime = this.item.videoTime;
    this.question = this.item.question;
    this.answera = this.item.answerA;
    this.answerb = this.item.answerB;
    this.answerc = this.item.answerC;
    this.answerd = this.item.answerD;
    this.answer = this.item.answer;
  },
  props: {
    getLessonDetail: Function,
    item: Object,
    lessonId: Number,
  },
  watch: {
    item: {
      immediate: true,
      handler(newItem) {
        this.lessonName = newItem.lessonName;
        this.lessonDescription = newItem.lessonDescription;
        this.lessonTime = newItem.videoTime;
        this.question = newItem.question;
        this.answera = newItem.answerA;
        this.answerb = newItem.answerB;
        this.answerc = newItem.answerC;
        this.answerd = newItem.answerD;
        this.answer = newItem.answer;
      },
    },
  },
};
</script>

<style lang="css" scoped></style>
