<template>
  <div>
    <h4
      style="
        color: #4d96ff;
        font-size: 24px;
        font-weight: bold;
        margin-bottom: 14px;
        letter-spacing: 1px;
      "
    >
      Khóa học đã đăng ký
    </h4>

    <div class="form-changepass">Coming Soon!</div>
    <div style="height: 40px"></div>
    <v-snackbar v-model="snackbarOk" multi-line>
      {{ snackBarContent }}
      <template v-slot:actions>
        <v-btn color="green" variant="text" @click="snackbarOk = false">
          Đóng
        </v-btn>
      </template>
    </v-snackbar>
  </div>
</template>

<script>
import UserAPI from "../../apis/APIUser/UserAPI.ts";
import { mapMutations } from "vuex";
export default {
  name: "CourseResisted",
  components: {},
  data() {
    return {
      password: "",
      newPassword: "",
      confirmPass: "",
      dialogTitle: false,
      context: "",
      dialog: false,
      snackbarOk: false,
      snackBarContent: "",
    };
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    async changPass() {
      this.setIsLoadedData(true);
      if (this.password.trim().length == 0) {
        this.dialogTitle = true;
        this.context = "Nhập mật khẩu cũ!";
        this.setIsLoadedData(false);
        return;
      }
      if (this.newPassword != this.confirmPass) {
        this.dialogTitle = true;
        this.context = "Mật khẩu xác nhận không đúng!";
        this.setIsLoadedData(false);
        return;
      }
      if (this.newPassword.trim().length < 8) {
        this.dialogTitle = true;
        this.context = "Mật khẩu quá ngắn!";
        this.setIsLoadedData(false);
        return;
      }
      const token = localStorage.getItem("token");
      const userId = localStorage.getItem("id");
      const data = await UserAPI.changePass(
        {
          Id: localStorage.getItem("id"),
          OldPass: this.password,
          NewPass: this.newPassword,
        },
        token
      );
      if (data.data == 4) {
        this.dialogTitle = true;
        this.context = "Lỗi không tìm thấy tài khoản!";
        this.setIsLoadedData(false);
        return;
      }
      if (data.data == 6) {
        this.dialogTitle = true;
        this.context = "Mật khẩu cũ không chính xác!";
        this.setIsLoadedData(false);
        return;
      }
      if (data.data == 2) {
        this.dialogTitle = true;
        this.context = "Thay đổi mật khẩu thất bại!";
        this.setIsLoadedData(false);
        return;
      }
      if (data.data == 1) {
        this.dialogTitle = true;
        this.context = "Thay đổi mật khẩu thành công!";
        this.password = "";
        this.newPassword = "";
        this.confirmPass = "";
        this.setIsLoadedData(false);
        return;
      }
      this.setIsLoadedData(false);
    },
  },
};
</script>

<style lang="css" scoped>
.form-changepass {
  width: 40%;
}
</style>
