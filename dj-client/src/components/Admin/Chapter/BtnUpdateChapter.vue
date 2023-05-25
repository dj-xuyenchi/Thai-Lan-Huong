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
        <v-form @submit.prevent="submit()" ref="form">
          <v-card style="overflow: scroll">
            <v-card-title>
              <span class="text-h5">Cập nhật học phần</span>
            </v-card-title>
            <v-card-text>
              <v-container>
                <v-row>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Tên học phần*"
                      hint="Tên học phần"
                      v-model="chapterName"
                      :rules="rules"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Tổng thời gian học*"
                      hint="Tổng thời gian học"
                      :rules="rules"
                      v-model="chapterTime"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Số bài học*"
                      hint="Số bài học"
                      :rules="rules"
                      type="number"
                      v-model="lessonCount"
                    ></v-text-field>
                  </v-col>
                </v-row>
              </v-container>
              <small>* là trường là bắt buộc. !</small>
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
  name: "BtnUpdateChapter",
  data() {
    return {
      text: "",
      snackbar: false,
      chapterName: "",
      chapterTime: "",
      lessonCount: 0,
      dialog: false,
      btnLoading: false,
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
    async submit() {
      this.btnLoading = true;
      if (
        this.chapterName.trim().length < 1 ||
        this.chapterTime.trim().length < 1
      ) {
        this.btnLoading = false;
        return;
      }
      const token = localStorage.getItem("token");
      const result = await AdminAPI.updateChapter(
        {
          ChapterId: this.chapterId,
          ChapterName: this.chapterName,
          ChapterTotalTime: this.chapterTime,
          LessonCount: this.lessonCount,
        },
        token
      );
      if (result.status == 1) {
        this.text = "Cập nhật thành công";
        this.dialog = false;
        this.snackbar = true;
        this.getChapterDetail();
      }
      if (result.status == 2) {
        this.text = "Cập nhật thất bại";
        this.snackbar = true;
      }
      this.btnLoading = false;
    },
    async getCourseForSelect() {
      const token = localStorage.getItem("token");
      const data = await AdminAPI.getCourseForChapter(token);
      this.courseList = data.data;
    },
  },
  props: {
    getChapterDetail: Function,
    chapterId: Number,
    item: Object,
  },
  created() {
    this.getCourseForSelect();
    this.chapterName = this.item.chapterName;
    this.chapterTime = this.item.timeTotal;
    this.lessonCount = this.item.lessonCount;
  },
  watch: {
    item: {
      immediate: true,
      handler(newItem) {
        // Cập nhật dữ liệu khi prop item thay đổi
        this.chapterName = newItem.chapterName;
        this.chapterTime = newItem.timeTotal;
        this.lessonCount = newItem.lessonCount;
      },
    },
  },
};
</script>

<style lang="css" scoped></style>
