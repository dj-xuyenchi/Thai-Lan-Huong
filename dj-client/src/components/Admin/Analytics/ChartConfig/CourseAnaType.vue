<template>
  <div>
    <v-row>
      <v-dialog v-model="dialog" persistent width="1024" height="70vh">
        <template v-slot:activator="{ props }">
          <v-btn
            color="green-darken-1"
            v-bind="props"
            variant="text"
            @click="dialog = true"
          >
            {{ coursename }}
          </v-btn>
        </template>
        <v-card style="overflow: scroll">
          <v-card-title>
            <span class="text-h5">{{ coursename }}</span>
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
              <tr v-for="(element, index) in list" :key="index">
                <td>{{ index + 1 }}</td>
                <td
                  style="display: flex; align-items: center; height: 74px"
                  class="user-detail"
                >
                  <UserDetail
                    :userId="element.studentId"
                    :avatar="element.studentAvatar"
                    :isKYC="element.isKYC"
                    :name="element.studentName"
                  />
                </td>
                <td>{{ element.thisProcess }}</td>
                <td>{{ element.evalute }}</td>
                <td>
                  <ProgressBtn :item="element" :courseId="courseId" />
                </td>
              </tr>
            </tbody>
          </v-table>
          <div class="text-center" @click="getData(page)">
            <v-container>
              <v-row justify="center">
                <v-col cols="4">
                  <v-container class="max-width">
                    <v-pagination
                      v-model="page"
                      class="my-2"
                      length="10"
                      rounded="circle"
                    ></v-pagination>
                  </v-container>
                </v-col>
              </v-row>
            </v-container>
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
import AdminAPI from "../../../../apis/APIAdmin/AdminAPI.ts";
import ProgressBtn from "../../Course/ProgressBtn.vue";
import UserDetail from "../../CommonComponent/UserDetail.vue";
export default {
  name: "BtnListStudentOfCourse",
  components: { ProgressBtn, UserDetail },
  props: {
    courseId: Number,
    opt: Number,
    coursename: String,
  },
  data: () => ({
    dialog: false,
    btnLoading: false,
    page: 1,
    text: "",
    list: [],
    snackbar: false,
  }),
  methods: {
    async getData(page) {
      const data = await AdminAPI.getCourseAnaType(
        this.courseId,
        page,
        this.opt,
        localStorage.getItem("token")
      );
      this.list = data;
    },
  },
  created() {
    this.getData(1, 1, this.opt);
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
.user-detail:hover {
  cursor: pointer;
}
</style>
