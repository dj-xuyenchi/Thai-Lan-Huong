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
      <div
        class="text-subtitle-1 text-medium-emphasis d-flex align-center justify-space-between"
      >
        Mật khẩu mới
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
        placeholder="Nhập mật khẩu"
        prepend-inner-icon="mdi-lock-outline"
        variant="outlined"
        @click:append-inner="visible = !visible"
        :rules="[rules.minPass]"
      ></v-text-field>

      <v-btn
        block
        class="mb-4"
        color="blue"
        size="large"
        variant="tonal"
        @click="sendRequest()"
        :disabled="dialog"
        :loading="dialog"
      >
        Xác nhận
      </v-btn>
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
  name: "ChangePass",
  data: () => ({
    visible: false,
    password: "",
    confirmPass: "",
    dialog: false,
    rules: {
      minPass: (v) => v.length >= 8 || "Mật khẩu lớn hơn 8 ký tự",
    },
  }),
  methods: {
    ...mapActions(["updateUserName"]),
    async sendRequest() {
      this.dialog = true;
      const request = {
        Code: localStorage.getItem("codePass"),
        NewPass: SHA512(this.password).toString(),
      };
      const result = await AuthApis.confirmPass(request);
      if (result.success === 0) {
        this.dialog = false;
        this.isUnValidUser = false;
        localStorage.setItem("token", result.data.token.accessToken);
        localStorage.setItem("refreshToken", result.data.token.refreshToken);
        localStorage.setItem("name", result.data.name);
        localStorage.setItem("avatar", result.data.avatar);
        localStorage.setItem("id", result.data.id);
        localStorage.setItem("nickName", result.data.nickName);
        localStorage.setItem("role", result.data.role);
        localStorage.removeItem("codePass");
        this.$router.push({ path: "/home/lobby" });
      }
      this.dialog = false;
    },
  },
};
</script>

<style lang="scss" scoped></style>
