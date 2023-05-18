<template>
  <div>
    <v-row>
      <v-dialog v-model="dialog" persistent width="1024">
        <template v-slot:activator="{ props }">
          <v-btn color="primary" v-bind="props"
            >Thêm học phần vào khóa học</v-btn
          >
        </template>
        <v-form @submit.prevent="submit()" ref="form">
          <v-card style="overflow: scroll">
            <v-card-title>
              <span class="text-h5">Thêm học phần vào khóa học</span>
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
                Thêm học phần
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-form>
      </v-dialog>
    </v-row>
  </div>
</template>

<script>
import AdminAPI from "../../../apis/APIAdmin/AdminAPI.ts";
export default {
  name: "BtnAddChapter",
  data() {
    return {
      dialog: false,
      items: [],
      select: "Chọn bài học",
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
        this.getLessonOfChapter();
      }
      if (result.status == 2) {
        this.text = "Thêm thất bại";
        this.snackbar = true;
      }
      this.btnLoading = false;
    },
  },
  created() {
    this.getLessonNotInChapter();
  },
  props: {
    CourseChapterId: Number,
    getLessonOfChapter: Function,
  },
};
</script>

<style lang="scss" scoped></style>
