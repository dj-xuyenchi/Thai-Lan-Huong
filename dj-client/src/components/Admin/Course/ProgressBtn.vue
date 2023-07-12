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
              >Tiến độ học
              <span style="font-size: 24px; font-weight: 550"> {{}}</span></span
            >
          </v-card-title>
          <v-table>
            <thead>
              <tr>
                <th class="text-left">STT</th>
                <th class="text-left">Học viên</th>
                <th class="text-left">Tiến độ hiện tại</th>
                <th class="text-left">Tiến độ tổng</th>
                <th class="text-center">Action</th>
              </tr>
            </thead>
            <tbody>
              <!-- <tr v-for="(item, index) in list" :key="index">
                <td>{{ index + 1 }}</td>

                <td style="display: flex; align-items: center">
                  <img
                    :src="item.studentAvatar"
                    alt="Hình ảnh"
                    style="height: 40px; width: 40px; border-radius: 50%"
                  />
                  <span style="margin-left: 8px">
                    {{ item.studentName
                    }}<img
                      v-if="item.isKYC"
                      :src="require('../../../assets/kyc.png')"
                      alt="Hình ảnh"
                      class="kyc"
                  /></span>
                </td>
                <td>{{ item.thisProcess }}</td>
                <td>{{ item.evalute }}</td>
                <td>{{}}</td>
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
    opt: false,
  }),
  methods: {
    async getCourseProgress() {
      const data = await AdminAPI.getCourseProgress(
        this.courseId,
        this.item.studentId,
        localStorage.getItem("token")
      );
    },
  },
  created() {
    this.getCourseProgress();
  },
};
</script>

<style lang="css" scoped></style>
