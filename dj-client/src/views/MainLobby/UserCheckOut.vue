<template>
  <div class="user-check" v-if="!showSignIn">
    <router-link to="/login" style="text-decoration: none; color: black">
      <v-btn width="100%" rounded="pill" color="#4FC3F7"> Đăng nhập </v-btn>
    </router-link>
  </div>
</template>

<script>
import AuthApis from "../../apis/AuthApis/AuthApis.ts";
import TokenModel from "@/entities/AuthEntities/TokenModel";
export default {
  name: "UserCheckOut",
  data() {
    return {
      showSignIn: false,
    };
  },
  created() {
    const cookie = document.cookie;
    console.log(cookie);
    const listCookie = cookie.split(";");
    const tokenModel = {};
    for (const cookie of listCookie) {
      console.log(cookie);
      if (cookie.includes("token=")) {
        tokenModel.AccessToken = cookie.split("=")[1];
      }
      if (cookie.includes("refreshToken=")) {
        tokenModel.RefreshToken = cookie.split("=")[1];
      }
    }
    this.isLogin(tokenModel);
    this.isLogin = true;
  },
  methods: {
    async isLogin(tokenModel) {
      const refreshToken = await AuthApis.refreshToken(tokenModel);
    },
  },
};
</script>

<style lang="css" scoped>
div {
  position: absolute;
  right: 2vw;
}
</style>
