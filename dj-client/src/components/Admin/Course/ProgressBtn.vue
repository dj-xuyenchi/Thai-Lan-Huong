<template>
  <div>
    <v-row>
      <v-dialog v-model="dialog" persistent width="80vw" height=" 70vh">
        <template v-slot:activator="{ props }">
          <v-btn
            color="green"
            density="compact"
            v-bind="{ props }"
            @click="dialog = true"
            icon="mdi-magnify"
          >
          </v-btn>
        </template>
        <v-card style="overflow: scroll">
          <v-card-title>
            <span class="text-h5"
              >Tiến độ học <span style="color: red">{{ courseName }}</span> của:
              <span style="color: red; font-size: 26px">{{ userName }}</span>
              <span style="font-size: 24px; font-weight: 550"> {{}}</span></span
            >
          </v-card-title>
          <div
            v-for="(item, index) in list"
            :key="index"
            style="margin-bottom: 20px"
          >
            <h4 style="margin-left: 8px">Tên học phần:</h4>
            <v-table>
              <thead>
                <tr>
                  <th class="text-left">#</th>
                  <th class="text-left">Tên bài học</th>
                  <th class="text-left">Thời lượng</th>
                  <th class="text-left">Loại bài học</th>
                  <th class="text-left">Ngày mở</th>
                  <th class="text-left">Trạng thái</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="(item, index) in item" :key="index">
                  <td>{{ index + 1 }}</td>
                  <td style="max-width: 220px">{{ item.lessonName }}</td>
                  <td>{{ index + 1 }}</td>
                  <td>{{ item.lessonType }}</td>
                  <td>{{ item.openTime }}</td>
                  <td style="max-width: 120px; color: green" v-if="item.isDone">
                    Đã hoàn thành
                  </td>
                  <td
                    style="max-width: 120px; color: red"
                    v-if="item.isDone == false"
                  >
                    Chưa hoàn thành
                  </td>
                </tr>
              </tbody>
            </v-table>
          </div>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn color="blue-darken-1" variant="text" @click="dialog = false">
              Thoát
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
      <v-snackbar v-model="snackbar">
        {{ text }}
        <template v-slot:actions>
          <v-btn color="green" variant="text" @click="snackbar = false">
            Đóng
          </v-btn>
        </template>
      </v-snackbar>
    </v-row>
  </div>
</template>

<script>
import AdminAPI from "../../../apis/APIAdmin/AdminAPI";
export default {
  name: "ProgressBtn",
  props: {
    item: Object,
    courseId: Number,
  },
  data: () => ({
    dialog: false,
    btnLoading: false,
    text: "",
    list: [],
    snackbar: false,
    userName: "",
    courseName: "",
    opt: false,
  }),
  methods: {
    async getCourseProgress() {
      const data = await AdminAPI.getCourseProgress(
        this.courseId,
        this.item.studentId,
        localStorage.getItem("token")
      );
      this.list = data.progress;
      this.courseName = data.courseName;
      this.userName = data.userName;
    },
  },
  created() {
    this.getCourseProgress();
  },
};
</script>

<style lang="css" scoped></style>
