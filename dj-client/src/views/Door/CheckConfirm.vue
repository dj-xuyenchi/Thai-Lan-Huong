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
      style="display: flex; justify-content: center; align-items: center"
    >
      <span v-if="isFailed">Xác nhận thất bại</span>
      <span v-if="isExpired">Link hết hạn</span>
      <span v-if="isOK">Xác nhận thành công!</span>
    </v-card>
  </div>
</template>

<script>
import AuthApis from "@/apis/AuthApis/AuthApis.ts";
export default {
  name: "CheckConfirm",
  data() {
    return {
      isFailed: false,
      isExpired: false,
      isOK: false,
    };
  },
  created() {
    this.confirm();
  },
  methods: {
    async confirm() {
      const data = await AuthApis.confirmAccount(this.$route.params.code);
      if (data.success == 0) {
        localStorage.setItem("token", data.data.token.accessToken);
        localStorage.setItem("refreshToken", data.data.token.refreshToken);
        localStorage.setItem("name", data.data.name);
        localStorage.setItem("avatar", data.data.avatar);
        localStorage.setItem("id", data.data.id);
        localStorage.setItem("nickName", data.data.nickName);
        localStorage.setItem("role", data.data.role);
        this.isOK = true;
        this.$router.push({ path: "/home/lobby" });
      }
      if (data.success == 1) {
        this.isFailed = true;
      }
      if (data.success == 3) {
        this.isFailed = true;
      }
    },
  },
};
</script>

<style lang="scss" scoped></style>
