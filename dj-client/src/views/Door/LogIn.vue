<template>
  <div class="py-4" style="margin-top: 60px">
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
        placeholder="Tên đăng nhập."
        prepend-inner-icon="mdi-account"
        variant="outlined"
        :rules="[rules.minUser]"
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

      <v-checkbox
        v-model="isSave"
        label="Lưu thông tin đăng nhập."
      ></v-checkbox>
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
        @click="checkLogin()"
        :disabled="dialog"
        :loading="dialog"
      >
        Đăng nhập
      </v-btn>
      <div style="text-align: center" class="mb-4">
        <a
          class="text-caption text-decoration-none text-blue"
          href="#"
          rel="noopener noreferrer"
          target="_blank"
        >
          Quên mật khẩu?</a
        >
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
      <v-card-text class="text-center">
        <v-btn variant="text" @click="signIn()" color="#2196f3">
          Đăng ký thành viên <v-icon icon="mdi-chevron-right"></v-icon>
          <span>{{ getUserNameLogIn }}</span>
        </v-btn>
      </v-card-text>
    </v-card>
  </div>
</template>
<script>
import AuthApis from "../../apis/AuthApis/AuthApis.ts";
import { mapGetters } from "vuex";
import { mapMutations } from "vuex";
import { mapActions } from "vuex";
export default {
  data: () => ({
    visible: false,
    userName: "",
    password: "",
    isSave: false,
    dialog: false,
    isUnValidUser: false,
    rules: {
      minUser: (value) => value.length >= 8 || "Tài khoản lớn hơn 8 ký tự",
      minPass: (v) => v.length >= 8 || "Mật khẩu lớn hơn 8 ký tự",
    },
    loginStatus: "",
  }),
  computed: {},
  methods: {
    ...mapActions(["updateUserName"]),
    async checkLogin() {
      if (this.userName.trim().length < 8 || this.password.trim().length < 8) {
        this.loginStatus = "Tài khoản hoặc mật khẩu chưa đúng.";
        this.isUnValidUser = true;
        return;
      }
      this.dialog = true;
      this.isUnValidUser = false;
      const requestLogin = {
        UserName: this.userName,
        Password: this.password,
      };
      const login = await AuthApis.getLogin(requestLogin);
      if (login.success == 1) {
        this.loginStatus = "Tài khoản hoặc mật khẩu không chính xác.";
        this.dialog = false;
        this.isUnValidUser = true;
      }
      if (login.success == 2) {
        this.loginStatus = "Tài khoản chưa được kích hoạt.";
        this.dialog = false;
        this.isUnValidUser = true;
        localStorage.setItem("confirm", login.data.email);
        this.$router.push({ path: "/confirm" });
      }
      if (login.success === 0) {
        this.dialog = false;
        // const now = new Date();
        // now.setMonth(now.getMonth() + 3);
        // document.cookie = `token=${login.data.accessToken}; expires=${now}`;
        // document.cookie = `refreshToken=${login.data.refreshToken}; expires=${now}`;
        this.isUnValidUser = false;
        localStorage.setItem("token", login.data.token.accessToken);
        localStorage.setItem("refreshToken", login.data.token.refreshToken);
        localStorage.setItem("name", login.data.name);
        localStorage.setItem("avatar", login.data.avatar);
        localStorage.setItem("id", login.data.id);
        localStorage.setItem("nickName", login.data.nickName);
        localStorage.setItem("role", login.data.role);
        this.$router.push({ path: "/home/lobby" });
      }
    },
    signIn() {
      this.$router.push({ path: "/signin" });
    },
  },
};
</script>

<style lang="scss" scoped></style>
