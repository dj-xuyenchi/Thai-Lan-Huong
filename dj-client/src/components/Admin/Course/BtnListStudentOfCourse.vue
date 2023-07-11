<template>
  <div>
    <v-row>
      <v-dialog v-model="dialog" persistent width="1024">
        <template v-slot:activator="{ props }">
          <v-btn
            color="green"
            density="compact"
            v-bind="{ props }"
            @click="dialog = true"
            icon="mdi-account-group"
          >
          </v-btn>
        </template>
        <v-card style="overflow: scroll; height: 80vh">
          <v-card-title>
            <span class="text-h5"
              >Danh sách học viên {{ item.courseName }}</span
            >
          </v-card-title>
          <v-table>
            <thead>
              <tr>
                <th class="text-left">STT</th>
                <th class="text-left">Học viên</th>
                <th class="text-left">Tiến độ hiện tại</th>
                <th class="text-left">Tiến độ tổng</th>
                <th class="text-left">Action</th>
              </tr>
            </thead>
            <tbody>
              <!-- <tr v-for="(item, index) in data" :key="index">
                <td>{{ index + 1 }}</td>

                <td>{{ fixString(item.courseName) }}</td>
                <td>{{ item.chapterCount + " học phần" }}</td>
                <td>{{ item.lessonCount + " bài học" }}</td>
                <td>{{ item.courseStatus }}</td>
              </tr> -->
            </tbody>
          </v-table>
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
  name: "BtnListStudentOfCourse",
  props: {
    item: Object,
  },
  data: () => ({
    dialog: false,
    btnLoading: false,
    text: "",
    snackbar: false,
    opt: false,
  }),
};
</script>

<style lang="css" scoped></style>
