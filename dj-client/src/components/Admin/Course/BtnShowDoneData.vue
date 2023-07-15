<template>
  <div>
    <v-row>
      <v-dialog v-model="dialog" persistent width="1024">
        <template v-slot:activator="{ props }">
          <v-btn
            color="green"
            v-bind="props"
            density="compact"
            icon="mdi-magnify"
          >
          </v-btn>
        </template>
        <v-card>
          <v-card-title class="text-h5"> Bài làm của học viên </v-card-title>
          <v-card-text
            >Sếp có chắc muốn xóa học phần này sau khi xóa sẽ không thể khôi
            phục lại.</v-card-text
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
              @click="deleteCourseChapter()"
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
  name: "BtnShowDoneData",
  data() {
    return {
      dialog: false,
      data: {},
    };
  },
  methods: {
    async getData() {
      const token = localStorage.getItem("token");
      const result = await AdminAPI.getDoneData(
        this.userId,
        this.lessonId,
        token
      );
      this.data = result;
    },
  },
  created() {
    this.getData();
  },
  props: {
    userId: Number,
    lessonId: Number,
  },
};
</script>
