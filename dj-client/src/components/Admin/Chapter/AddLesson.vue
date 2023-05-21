<template>
  <div>
    <v-row>
      <v-dialog v-model="dialog" persistent width="1024">
        <template v-slot:activator="{ props }">
          <v-btn color="primary" v-bind="props" @click="getLessonNotInChapter()"
            >Thêm bài học vào học phần</v-btn
          >
        </template>
        <v-form @submit.prevent="submit()" ref="form">
          <v-card style="overflow: scroll">
            <v-card-title>
              <span class="text-h5">Thêm bài học vào học phần</span>
            </v-card-title>
            <v-card-text>
              <v-container>
                <v-row>
                  <v-col cols="12" sm="6" md="6">
                    <v-select
                      v-model="select"
                      :items="items"
                      item-title="lessonName"
                      item-value="lessonId"
                      label="Select"
                      persistent-hint
                      return-object
                      single-line
                    ></v-select>
                  </v-col>
                </v-row>
              </v-container>
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
                Thêm bài học
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-form>
      </v-dialog>
    </v-row>
    <v-snackbar v-model="snackbar">
      {{ text }}
      <template v-slot:actions>
        <v-btn color="green" variant="text" @click="snackbar = false">
          Đóng
        </v-btn>
      </template>
    </v-snackbar>
  </div>
</template>

<script>
import AdminAPI from "../../../apis/APIAdmin/AdminAPI.ts";
export default {
  name: "AddLesson",
  data() {
    return {
      dialog: false,
      items: [],
      select: null,
      text: "",
      snackbar: false,
      btnLoading: false,
    };
  },
  methods: {
    async getLessonNotInChapter() {
      const token = localStorage.getItem("token");
      const result = await AdminAPI.getLessonNotInChapter(token);
      this.items = result.data;
    },
    async submit() {
      this.btnLoading = true;
      if (this.select == null) {
        this.text = "Vui lòng chọn bài học!";
        this.snackbar = true;
        this.btnLoading = false;
      }
      const token = localStorage.getItem("token");
      const result = await AdminAPI.addLesson2Chapter(
        {
          LessonId: this.select.lessonId,
          CourseChapterId: this.CourseChapterId,
        },
        token
      );
      if (result.status == 1) {
        this.text = "Thêm thành công";
        this.dialog = false;
        this.snackbar = true;
        this.select = null;
        this.getLessonOfChapter();
        this.getLessonNotInChapter();
      }
      if (result.status == 2) {
        this.text = "Thêm thất bại";
        this.snackbar = true;
      }
      this.btnLoading = false;
    },
  },
  // created() {
  //   this.getLessonNotInChapter();
  // },
  props: {
    CourseChapterId: Number,
    getLessonOfChapter: Function,
  },
};
</script>

<style lang="scss" scoped></style>
