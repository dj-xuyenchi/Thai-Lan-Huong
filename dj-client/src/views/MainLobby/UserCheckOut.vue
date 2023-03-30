<template>
  <div class="user-check" v-if="showSignIn">
    <router-link to="/login" style="text-decoration: none; color: black">
      <v-btn width="100%" rounded="pill" color="#4FC3F7"> Đăng nhập </v-btn>
    </router-link>
  </div>
  <div v-else class="user-check login">
    <v-menu>
      <template v-slot:activator="{ props }">
        <v-list-item
          prepend-avatar="https://randomuser.me/api/portraits/women/81.jpg"
          title="Dương Diệu Phương"
          subtitle="Chiến thần FE"
          :append-icon="iconStatus.normal"
          v-bind="props"
        ></v-list-item>
      </template>
      <v-card class="mx-auto" max-width="300">
        <v-list density="compact">
          <v-list-item
            v-for="(item, i) in items"
            :key="i"
            :value="item"
            active-color="primary"
          >
            <template v-slot:prepend>
              <v-icon :icon="item.icon"></v-icon>
            </template>

            <v-list-item-title v-text="item.text"></v-list-item-title>
          </v-list-item>
        </v-list>
      </v-card>
    </v-menu>
  </div>
</template>

<script>
import AuthApis from "../../apis/AuthApis/AuthApis.ts";
import TokenModel from "@/entities/AuthEntities/TokenModel";
import { mapGetters } from "vuex";
export default {
  name: "UserCheckOut",
  data() {
    return {
      showSignIn: true,
      iconStatus: {
        normal: "mdi-chevron-right",
        click: "mdi-chevron-down",
      },
      items: [
        { text: "Real-Time", icon: "mdi-clock" },
        { text: "Audience", icon: "mdi-account" },
        { text: "Conversions", icon: "mdi-flag" },
      ],
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
  computed: {
    ...mapGetters(["getUserNameLogIn"]),
  },
  methods: {
    async isLogin(tokenModel) {
      const refreshToken = await AuthApis.refreshToken(tokenModel);
    },
  },
};
</script>

<style lang="css" scoped>
.user-check {
  position: absolute;
  right: 2vw;
}
.login:hover {
  cursor: pointer;
  color: rgba(0, 0, 0, 0.5);
}
</style>
