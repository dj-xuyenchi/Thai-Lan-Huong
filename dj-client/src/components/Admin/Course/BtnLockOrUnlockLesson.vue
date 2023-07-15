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
        <v-card>
          <v-card-title class="text-h5"> Xoá bài học? </v-card-title>
          <v-card-text
            >Sếp có chắc muốn thay đổi trạng thái học bài học này của học
            viên?</v-card-text
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
              @click="lockOrUnlock()"
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
  name: "BtnLockOrUnlockLesson",
  data() {
    return {
      dialog: false,
      text: "",
      snackbar: false,
    };
  },
  methods: {
    async lockOrUnlock() {
      const result = await AdminAPI.lockOrUnlockLesson(
        this.userId,
        this.lessonId,
        localStorage.getItem("token")
      );
      if (result == 1) {
        this.text = "Thành công!";
        this.snackbar = true;
      }
      if (result == 6) {
        this.text = "Không thể xóa bài học khởi đầu của học phần thứ 1!";
        this.snackbar = true;
      }
      if (result == 2) {
        this.text = "Thất bại!";
        this.snackbar = true;
      }
      this.getCourseProgress();
      this.dialog = false;
    },
  },
  props: {
    userId: Number,
    lessonId: Number,
    getCourseProgress: Function,
  },
};
</script>
