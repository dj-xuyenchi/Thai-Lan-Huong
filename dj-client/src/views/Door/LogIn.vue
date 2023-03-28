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
        placeholder="Email, Sdt hoặc tên đăng nhập."
        prepend-inner-icon="mdi-email-outline"
        variant="outlined"
      ></v-text-field>
      <div
        class="text-subtitle-1 text-medium-emphasis d-flex align-center justify-space-between"
      >
        Mật khẩu
        <a
          class="text-caption text-decoration-none text-blue"
          href="#"
          rel="noopener noreferrer"
          target="_blank"
        >
          Quên mật khẩu?</a
        >
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
      ></v-text-field>
      <v-checkbox label="Lưu thông tin đăng nhập."></v-checkbox>
      <v-card
        class="mb-6"
        color="surface-variant"
        variant="tonal"
        style="text-align: center"
        v-if="isValidUser"
      >
        <v-card-text class="text-medium-emphasis text-caption">
          <span style="color: red">
            Tên tài khoản hoặc mật khẩu không chính xác.
          </span>
        </v-card-text>
      </v-card>
      <v-btn
        block
        class="mb-8"
        color="blue"
        size="large"
        variant="tonal"
        @click="checkLogin()"
        :disabled="dialog"
        :loading="dialog"
      >
        Đăng nhập
      </v-btn>

      <div
        style="
          width: 100%;
          display: flex;
          justify-content: center;
          align-items: center;
        "
      >
        <v-img
          max-width="60"
          :src="require('../../assets/google.png')"
          style="padding: 0px 8px 0px 8px"
        ></v-img>
        <v-img
          max-width="60"
          :src="require('../../assets/fb.png')"
          style="padding: 0px 8px 0px 8px"
        ></v-img>
      </div>
      <v-card-text class="text-center">
        <a
          class="text-blue text-decoration-none"
          href="#"
          rel="noopener noreferrer"
          target="_blank"
        >
          Đăng ký thành viên <v-icon icon="mdi-chevron-right"></v-icon>
        </a>
      </v-card-text>
    </v-card>
  </div>
</template>
<script>
import AuthApis from "../../apis/AuthApis/AuthApis.ts";
export default {
  data: () => ({
    visible: false,
    userName: "",
    password: "",
    dialog: false,
    isUnValidUser: false,
  }),
  methods: {
    async checkLogin() {
      this.dialog = true;
      const login = await AuthApis.getLogin(this.userName, this.password);
      console.log(login);

      if (login.success === true) {
        console.log(login);
        document.cookie = `token=${login.data.accessToken}`;
        document.cookie = `refreshToken=${login.data.refreshToken}`;
        const cok = document.cookie;
        console.log(cok);
      }
      this.isUnValidUser = true;
    },
  },
  watch: {
    dialog(val) {
      if (!val) return;

      setTimeout(() => (this.dialog = false), 4000);
    },
  },
};
</script>

<style lang="scss" scoped></style>
