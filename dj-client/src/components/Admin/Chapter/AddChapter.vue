<template>
  <div>
    <v-dialog v-model="dialog" persistent width="1024">
      <template v-slot:activator="{ props }">
        <v-btn color="primary" v-bind="props"> Thêm học phần</v-btn>
      </template>
      <v-form @submit.prevent="submit()" ref="form">
        <v-card style="overflow: scroll">
          <v-card-title>
            <span class="text-h5">Thêm học phần</span>
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
                  <v-select
                    v-model="select"
                    :hint="
                      `Học phần được thêm cho khóa học ` + select.courseName
                    "
                    :items="courseList"
                    item-title="courseName"
                    item-value="courseId"
                    label="Dành cho khóa học"
                    persistent-hint
                    return-object
                    single-line
                  ></v-select>
                </v-col>
              </v-row>
            </v-container>
            <small
              >* là trường là bắt buộc. Học phần khi thêm mặc định sẽ được sếp
              xuống cuối cùng trong danh sách học phần của khóa học!</small
            >
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn color="blue-darken-1" variant="text" @click="dialog = false">
              Hủy
            </v-btn>
            <v-btn
              color="blue-darken-1"
              :loading="btnLoading"
              variant="text"
              type="submit"
            >
              Thêm bài tập
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-form>
    </v-dialog>
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
  name: "AddChapter",
  data() {
    return {
      text: "",
      snackbar: false,
      select: {
        courseName: "Khóa học",
      },
      chapterName: "",
      chapterTime: "",
      courseList: [],
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
      const result = await AdminAPI.addChapter(
        {
          CourseId: this.select.courseId,
          ChapterName: this.chapterName,
          ChapterTotalTime: this.chapterTime,
        },
        token
      );
      if (result.status == 1) {
        this.text = "Thêm thành công";
        this.dialog = false;
        this.snackbar = true;
        this.chapterName = "";
        this.chapterTime = "";
        this.getChapterDetail();
      }
      if (result.status == 2) {
        this.text = "Thêm thất bại";
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
  },
  created() {
    this.getCourseForSelect();
  },
};
</script>

<style lang="css" scoped></style>
