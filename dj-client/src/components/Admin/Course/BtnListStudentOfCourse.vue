<template>
  <div>
    <v-row>
      <v-dialog v-model="dialog" persistent width="1024" height=" 70vh">
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
        <v-card style="overflow: scroll">
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
                <th class="text-center">Action</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="(item, index) in list" :key="index">
                <td>{{ index + 1 }}</td>
                <td style="display: flex; align-items: center; height: 74px">
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
                <td
                  style="
                    display: flex;
                    align-items: center;
                    justify-content: center;
                  "
                >
                  <ProgressBtn :item="item" :courseId="courseId" />
                </td>
              </tr>
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
import ProgressBtn from "./ProgressBtn.vue";
export default {
  name: "BtnListStudentOfCourse",
  components: { ProgressBtn },
  props: {
    item: Object,
  },
  data: () => ({
    dialog: false,
    btnLoading: false,
    text: "",
    list: [],
    courseId: 0,
    snackbar: false,
    opt: false,
  }),
  methods: {
    async getData(page) {
      const data = await AdminAPI.getStudentOfCourse(
        this.item.courseId,
        page,
        localStorage.getItem("token")
      );
      this.list = data;
    },
  },
  created() {
    this.courseId = this.item.courseId;
    this.getData(1);
  },
};
</script>

<style lang="css" scoped>
.kyc {
  height: 20px;
  width: 20px;
  position: relative;
  top: 4px;
  left: 4px;
}
</style>
