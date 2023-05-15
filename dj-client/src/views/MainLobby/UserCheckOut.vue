<template>
  <div class="user-check" v-if="showSignIn">
    <router-link to="/login" style="text-decoration: none; color: black">
      <v-btn width="100%" rounded="pill" color="#4FC3F7"> Đăng nhập </v-btn>
    </router-link>
  </div>
  <div v-else class="user-check">
    <font-awesome-icon
      icon="fa-regular fa-bell"
      class="notification"
      @click="setShowNotification()"
    />
    <v-card width="400" v-if="show" class="notification-container">
      <v-card-text>
        <div
          class="font-weight-bold ms-1 mb-2"
          style="display: flex; justify-content: space-between"
        >
          <span style="font-size: 18px; font-weight: 400">Thông báo</span
          ><span
            style="font-size: 14px; font-weight: 400; color: #eb5353"
            id="notification-seen"
            >Đánh dấu đã đọc</span
          >
        </div>
        <NotificationItem />
      </v-card-text>
    </v-card>
    <v-menu>
      <template v-slot:activator="{ props }">
        <v-list-item
          :prepend-avatar="`data:image/jpeg;base64,` + user.avatar"
          :title="user.name"
          :subtitle="user.nickName"
          :append-icon="iconStatus.normal"
          v-bind="props"
        ></v-list-item>
      </template>
      <v-card class="mx-auto" max-width="600">
        <v-list density="compact">
          <v-list-item
            v-if="isAdmin"
            active-color="primary"
            @click="admin.event()"
          >
            <template v-slot:prepend>
              <v-icon :icon="admin.icon"></v-icon>
            </template>
            <v-list-item-title v-text="admin.text"></v-list-item-title>
          </v-list-item>
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
import NotificationItem from "./NotificationItem";
export default {
  name: "UserCheckOut",
  components: { NotificationItem },
  data() {
    return {
      isAdmin: false,
      showSignIn: true,
      show: true,
      user: {
        avatar: "",
        name: "",
        id: "",
        nickName: "",
      },
      iconStatus: {
        normal: "mdi-chevron-right",
        click: "mdi-chevron-down",
      },
      admin: {
        text: "Quản trị hệ thống",
        icon: "mdi-desktop-mac",
        event: () => {
          this.$router.push({ path: "/admin/dashboard" });
        },
      },
      items: [
        {
          text: "Thông tin cá nhân",
          icon: "mdi-account",
          event: () => {
            this.$router.push({ path: "/home/user/inforcontact" });
          },
        },
        {
          text: "Bài đăng",
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
            localStorage.removeItem("token");
            localStorage.removeItem("refreshToken");
            localStorage.removeItem("avatar");
            localStorage.removeItem("name");
            localStorage.removeItem("id");
            localStorage.removeItem("nickName");
            localStorage.removeItem("role");
            this.setShowLogin();
            this.$router.push({ path: "/home/lobby" });
          },
        },
      ],
    };
  },
  mounted() {
    const token = localStorage.getItem("token");
    const refreshToken = localStorage.getItem("refreshToken");
    const avatar = localStorage.getItem("avatar");
    const id = localStorage.getItem("id");
    const name = localStorage.getItem("name");
    const nickName = localStorage.getItem("nickName");
    const role = localStorage.getItem("role");
    if (token || refreshToken) {
      this.showSignIn = false;
      this.user = {
        avatar: avatar,
        name: name,
        id: id,
        nickName: nickName,
      };
    }
    if (role == 1) {
      this.isAdmin = true;
    }
  },
  methods: {
    ...mapMutations(["setIsLogIn"]),
    async isLogin(tokenModel) {
      const loginStatus = await AuthApis.refreshToken(tokenModel);
      console.log(loginStatus);
    },
    setShowLogin() {
      this.showSignIn = true;
    },
    setShowNotification() {
      this.show = !this.show;
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
.notification:hover {
  cursor: pointer;
  color: rgba(0, 0, 0, 0.5);
}
.notification {
  position: absolute;
  top: 25%;
  font-size: 24px;
  left: -30px;
}
.notification-container {
  position: absolute;
  top: 110%;
  left: -400px;
}
#notification-seen:hover {
  cursor: pointer;
  color: #f5dcdc;
}
</style>
