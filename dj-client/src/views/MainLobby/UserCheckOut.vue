<template>
  <div class="user-check" v-if="!getIsLogIn">
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
      <v-card class="mx-auto" max-width="600">
        <v-list density="compact">
          <v-list-item
            v-for="(item, i) in items"
            :key="i"
            :value="item"
            active-color="primary"
            @click="item.event()"
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
import { mapMutations } from "vuex";
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
        {
          text: "Thông tin cá nhân",
          icon: "mdi-account",
          event: () => {
            this.$router.push({ path: "/user/1" });
          },
        },
        {
          text: "Khóa học đăng ký",
          icon: "mdi-bookshelf",
          event: () => {
            this.$router.push({ path: "/user/1" });
          },
        },
        {
          text: "Đăng xuất",
          icon: "mdi-logout",
          event: () => {
            document.cookie = "token=;expires=Thu, 01 Jan 1970 00:00:01 GMT;";
            document.cookie =
              "refreshToken=;expires=Thu, 01 Jan 1970 00:00:01 GMT;";
            this.setIsLogIn(false);
            this.$router.push({ path: "/home/lobby" });
          },
        },
      ],
    };
  },
  computed: {
    ...mapGetters(["getIsLogIn"]),
  },
  mounted() {
    const cookie = document.cookie;
    console.log(cookie);
    const listCookie = cookie.split(";");
    const tokenModel = {
      AccessToken: "",
      RefreshToken: "",
    };
    for (const cookie of listCookie) {
      if (cookie.includes("token=")) {
        tokenModel.AccessToken = cookie.split("=")[1];
      }
      if (cookie.includes("refreshToken=")) {
        tokenModel.RefreshToken = cookie.substring(14, cookie.length);
      }
    }
    this.isLogin(tokenModel);
  },
  methods: {
    ...mapMutations(["setIsLogIn"]),
    async isLogin(tokenModel) {
      const loginStatus = await AuthApis.refreshToken(tokenModel);
      console.log(loginStatus);
      if (loginStatus.success == 0) {
        console.log(123);
        this.setIsLogIn(true);
      }
    },
  },
};
</script>

<style lang="css" scoped>
.user-check {
  position: absolute;
  right: 2vw;
}
.v-list-item__overlay:focus-visible {
  opacity: 0;
}
.login:hover {
  cursor: pointer;
  color: rgba(0, 0, 0, 0.5);
}
</style>
