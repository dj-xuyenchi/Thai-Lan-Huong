<template>
  <div style="min-height: 80vh">
    <h4
      style="
        color: #4d96ff;
        font-size: 24px;
        font-weight: bold;
        margin-bottom: 14px;
        letter-spacing: 1px;
      "
    >
      Đổi mật khẩu
    </h4>

    <div class="form-changepass">
      <v-text-field
        v-model="password"
        :type="'password'"
        density="compact"
        placeholder="Mật khẩu cũ"
        variant="outlined"
      ></v-text-field>
      <v-text-field
        v-model="newPassword"
        :type="'password'"
        density="compact"
        placeholder="Mật khẩu mới"
        variant="outlined"
      ></v-text-field>
      <v-text-field
        v-model="confirmPass"
        :type="'password'"
        density="compact"
        placeholder="Xác nhận"
        variant="outlined"
      ></v-text-field>
      <v-card
        class="mb-6"
        color="surface-variant"
        variant="tonal"
        style="text-align: center"
        v-if="dialogTitle"
      >
        <v-card-text class="text-medium-emphasis text-caption">
          <span style="color: red">
            {{ context }}
          </span>
        </v-card-text>
      </v-card>
      <v-btn
        block
        class="mb-4"
        color="blue"
        size="large"
        variant="tonal"
        @click="changPass()"
        :disabled="dialog"
        :loading="dialog"
      >
        Đổi mật khẩu
      </v-btn>
    </div>
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
import { SHA512 } from "crypto-js";
import UserAPI from "../../apis/APIUser/UserAPI.ts";
import { mapMutations } from "vuex";
export default {
  name: "ChangPassUser",
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
          OldPass: SHA512(this.password).toString(),
          NewPass: SHA512(this.newPassword).toString(),
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
