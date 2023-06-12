<template>
  <div>
    <v-row>
      <v-dialog v-model="dialog" persistent width="1024">
        <template v-slot:activator="{ props }">
          <v-btn color="red" v-bind="props" density="compact" icon="mdi-delete">
          </v-btn>
        </template>
        <v-card>
          <v-card-title class="text-h5">
            Xoá bài học khỏi học phần?
          </v-card-title>
          <v-card-text
            >Sếp có chắc muốn xóa bài học này khỏi học phần?</v-card-text
          >
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn
              color="green-darken-1"
              variant="text"
              @click="dialog = false"
            >
              Hủy
            </v-btn>
            <v-btn
              color="green-darken-1"
              variant="text"
              @click="deleteTestCase()"
            >
              Đồng ý
            </v-btn>
          </v-card-actions>
        </v-card>
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
export default {
  name: "BtnDeleteLesson",
  data() {
    return {
      dialog: false,
      text: "",
      snackbar: false,
    };
  },
  methods: {
    async deleteTestCase() {
      const token = localStorage.getItem("token");
      const result = await AdminAPI.deleteLessonOfChapter(
        this.chapterLessonId,
        token
      );
      if (result.status == 1) {
        this.text = "Xóa thành công";
        this.dialog = false;
        this.snackbar = true;
        this.getLessonOfChapter();
      }
      if (result.status == 2) {
        this.text = "Xóa thất bại";
        this.snackbar = true;
      }
      this.dialog = false;
    },
  },
  props: {
    chapterLessonId: Number,
    getLessonOfChapter: Function,
  },
};
</script>
