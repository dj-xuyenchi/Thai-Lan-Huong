<template>
  <div class="py-4">
    <v-img
      class="mx-auto mb-10"
      max-width="300"
      :src="require('../../assets/logo-namngang.png')"
    ></v-img>
    <v-card
      class="mx-auto pa-12 pb-8"
      elevation="8"
      max-width="448"
      rounded="lg"
    >
      <div class="text-subtitle-1 text-medium-emphasis">Tên đăng nhập</div>
      <v-text-field
        v-model="userName"
        density="compact"
        placeholder="Tên đăng nhập"
        prepend-inner-icon="mdi-account"
        variant="outlined"
        :rules="[rules.minUser, rules.userName]"
      ></v-text-field>
      <div class="text-subtitle-1 text-medium-emphasis">Email</div>
      <v-text-field
        v-model="email"
        density="compact"
        placeholder="Email"
        prepend-inner-icon="mdi-email-outline"
        variant="outlined"
        :rules="[rules.email]"
      ></v-text-field>
      <div class="text-subtitle-1 text-medium-emphasis">Số điện thoại</div>
      <v-text-field
        v-model="sdt"
        density="compact"
        placeholder="Số điện thoại"
        prepend-inner-icon="mdi-phone"
        variant="outlined"
        :rules="[rules.sdt]"
      ></v-text-field>
      <div
        class="text-subtitle-1 text-medium-emphasis d-flex align-center justify-space-between"
      >
        Mật khẩu
      </div>
      <v-text-field
        v-model="password"
        :append-inner-icon="visible ? 'mdi-eye-off' : 'mdi-eye'"
        :type="visible ? 'text' : 'password'"
        density="compact"
        placeholder="Nhập mật khẩu"
        prepend-inner-icon="mdi-lock-outline"
        variant="outlined"
        @click:append-inner="visible = !visible"
        :rules="[rules.minPass]"
      ></v-text-field>
      <div
        class="text-subtitle-1 text-medium-emphasis d-flex align-center justify-space-between"
      >
        Xác nhận mật khẩu
      </div>
      <v-text-field
        v-model="confirmPass"
        :append-inner-icon="visible ? 'mdi-eye-off' : 'mdi-eye'"
        :type="visible ? 'text' : 'password'"
        density="compact"
        placeholder="Xác nhận mật khẩu"
        prepend-inner-icon="mdi-lock-outline"
        variant="outlined"
        @click:append-inner="visible = !visible"
        :rules="[rules.minPass]"
      ></v-text-field>
      <v-card
        class="mb-6"
        color="surface-variant"
        variant="tonal"
        style="text-align: center"
        v-if="isUnValidUser"
      >
        <v-card-text class="text-medium-emphasis text-caption">
          <span style="color: red">
            {{ loginStatus }}
          </span>
        </v-card-text>
      </v-card>
      <v-btn
        block
        class="mb-4"
        color="blue"
        size="large"
        variant="tonal"
        @click="signIn()"
        :disabled="dialog"
        :loading="dialog"
      >
        Đăng ký ngay
      </v-btn>
      <div style="text-align: center" class="mb-4">
        <v-btn
          block
          class="mb-4"
          color="blue"
          variant="text"
          @click="back2Login()"
        >
          Đã có tài khoản?
        </v-btn>
      </div>
      <div
        style="
          width: 100%;
          display: flex;
          justify-content: center;
          align-items: center;
        "
      >
        <!-- <v-img
          max-width="60"
          :src="require('../../assets/google.png')"
          style="padding: 0px 8px 0px 8px"
        ></v-img> -->
        <!-- <v-img
          max-width="60"
          :src="require('../../assets/fb.png')"
          style="padding: 0px 8px 0px 8px"
        ></v-img> -->
      </div>
      <!-- <v-card-text class="text-center">
        <a
          class="text-blue text-decoration-none"
          href="#"
          rel="noopener noreferrer"
          target="_blank"
        >
          Đăng ký thành viên <v-icon icon="mdi-chevron-right"></v-icon>
          <span>{{ getUserNameLogIn }}</span>
        </a>
      </v-card-text> -->
    </v-card>
  </div>
</template>
<script>
import AuthApis from "../../apis/AuthApis/AuthApis.ts";
import { mapGetters } from "vuex";
import { mapMutations } from "vuex";
import { mapActions } from "vuex";

import { SHA512 } from "crypto-js";
export default {
  name: "SignIn",
  data: () => ({
    visible: false,
    userName: "",
    email: "",
    sdt: "",
    password: "",
    confirmPass: "",
    dialog: false,
    isUnValidUser: false,
    rules: {
      userName: (value) =>
        !/[@#$%^&+=! ]/.test(value) || "Tên đăng nhập chứa ký tự không hợp lệ",
      email: (value) => value.includes("@") || "Email chưa đúng",
      sdt: (value) => /^\+?\d{1,3}\s?\d{9,}$/.test(value) || "SDT chưa đúng",
      minUser: (value) => value.length >= 8 || "Tài khoản lớn hơn 8 ký tự",
      minPass: (v) => v.length >= 8 || "Mật khẩu lớn hơn 8 ký tự",
    },
    loginStatus: "",
  }),
  computed: {},
  methods: {
    ...mapActions(["updateUserName"]),
    back2Login() {
      this.$router.push({ path: "/login" });
    },
    async signIn() {
      this.dialog = true;
      this.isUnValidUser = false;
      if (this.userName.trim().length < 8) {
        this.loginStatus = "Tài khoản chưa đúng.";
        this.isUnValidUser = true;
        this.dialog = false;
        this.isUnValidUser = true;
        return;
      }
      if (/[@#$%^&+=! ]/.test(this.userName)) {
        this.loginStatus = "Tên đăng nhập chứa ký tự không hợp lệ!";
        this.isUnValidUser = true;
        this.dialog = false;
        this.isUnValidUser = true;
        return;
      }
      if (this.email.trim().length < 8) {
        this.loginStatus = "Email chưa đúng.";
        this.isUnValidUser = true;
        this.dialog = false;
        this.isUnValidUser = true;
        return;
      }
      if (!this.email.includes("@")) {
        this.loginStatus = "Email chưa đúng định dạng.";
        this.isUnValidUser = true;
        this.dialog = false;
        this.isUnValidUser = true;
        return;
      }
      if (!/^\+?\d{1,3}\s?\d{9,}$/.test(this.sdt.trim())) {
        this.loginStatus = "SDT chưa đúng định dạng.";
        this.isUnValidUser = true;
        this.dialog = false;
        this.isUnValidUser = true;
        return;
      }
      if (this.password.trim().length < 8) {
        this.loginStatus = "Mật khẩu chưa đúng.";
        this.isUnValidUser = true;
        this.dialog = false;
        this.isUnValidUser = true;
        return;
      }
      if (this.confirmPass.trim().length < 8) {
        this.loginStatus = "Mật khẩu chưa đúng.";
        this.isUnValidUser = true;
        this.dialog = false;
        this.isUnValidUser = true;
        return;
      }
      if (this.confirmPass.localeCompare(this.password) !== 0) {
        this.loginStatus = "Mật khẩu chưa xác nhận sai.";
        this.isUnValidUser = true;
        this.dialog = false;
        this.isUnValidUser = true;
        return;
      }
      const newAccount = {
        userName: this.userName,
        email: this.email,
        sdt: this.sdt,
        password: SHA512(this.password).toString(),
      };
      const result = await AuthApis.signIn(newAccount);
      if (result.data.status == 1) {
        this.dialog = false;
        this.isUnValidUser = true;
        localStorage.setItem("confirm", this.email);
        this.$router.push({ path: "/confirm" });
      }
      if (result.data.status == 5) {
        this.loginStatus = "SDT đã tồn tại!";
        this.dialog = false;
        this.isUnValidUser = true;
      }
      if (result.data.status == 4) {
        this.loginStatus = "Email đã tồn tại!";
        this.dialog = false;
        this.isUnValidUser = true;
      }
      if (result.data.status == 2) {
        this.loginStatus = "Đăng ký thất bại!";
        this.dialog = false;
        this.isUnValidUser = true;
      }
      if (result.data.status == 3) {
        this.loginStatus = "Tên tài khoản đã tồn tại!";
        this.dialog = false;
        this.isUnValidUser = true;
      }
      if (result.data.status == 3) {
        this.loginStatus = "Tên tài khoản đã tồn tại!";
        this.dialog = false;
        this.isUnValidUser = true;
      }
      this.dialog = false;
      this.isUnValidUser = true;
    },
  },
};
</script>

<style lang="scss" scoped></style>
