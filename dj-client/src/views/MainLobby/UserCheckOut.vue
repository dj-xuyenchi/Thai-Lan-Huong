<template>
  <div class="user-check" v-if="showSignIn">
    <router-link to="/login" style="text-decoration: none; color: black">
      <v-btn width="100%" rounded="pill" color="#4FC3F7"> Đăng nhập </v-btn>
    </router-link>
  </div>
  <div v-else class="user-check">
    <v-menu
      transition="slide-y-transition"
      :close-on-content-click="false"
      v-model="menu"
    >
      <template v-slot:activator="{ props }">
        <font-awesome-icon
          v-bind="props"
          icon="fa-regular fa-bell"
          class="notification"
          @click="setShow()"
        />
      </template>
      <v-card width="400" class="notification-container">
        <v-card-text>
          <div
            class="font-weight-bold ms-1 mb-2"
            style="display: flex; justify-content: space-between"
          >
            <span style="font-size: 18px; font-weight: 400">Thông báo</span
            ><span
              style="font-size: 14px; font-weight: 400; color: #eb5353"
              id="notification-seen"
              @click="seenAll()"
              >Đánh dấu đã đọc</span
            >
          </div>
          <NotificationItem
            v-for="(item, index) in notifications"
            :key="index"
            :data="item"
            :setShowNotification="setShowNotification"
          />
        </v-card-text>
      </v-card>
    </v-menu>
    <v-menu>
      <template v-slot:activator="{ props }">
        <v-list-item
          :prepend-avatar="user.avatar"
          :title="user.name"
          :subtitle="user.nickName"
          :append-icon="iconStatus.normal"
          v-bind="props"
          ><img
            v-if="kyc"
            :src="require('../../assets/kyc.png')"
            alt="Hình ảnh"
            class="kyc"
            :style="`right:` + kycLeft + `px`"
        /></v-list-item>
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
import UserAPI from "../../apis/APIUser/UserAPI.ts";
import TokenModel from "@/entities/AuthEntities/TokenModel";
import { mapGetters } from "vuex";
import { mapMutations } from "vuex";
import NotificationItem from "./NotificationItem";
import { onUnmounted } from "vue";
import { ref } from "vue";
export default {
  name: "UserCheckOut",
  components: { NotificationItem },

  data() {
    return {
      isAdmin: false,
      notifications: [],
      showSignIn: true,
      show: false,
      menu: false,
      kycLeft: 0,
      kyc: false,
      user: {
        avatar: "",
        name: "",
        id: "",
        isKYC: false,
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
          this.$router.push({ path: "/admin/dashboard-content" });
        },
      },
      items: [
        {
          text: "Trang cá nhân",
          icon: "mdi-account",
          event: () => {
            const user = localStorage.getItem("id");
            this.$router.push({ path: `/profile/${user}` });
          },
        },
        {
          text: "Viết bài",
          icon: "mdi-pencil",
          event: async () => {
            const check = await UserAPI.isHaveWaitPost(
              localStorage.getItem("id"),
              localStorage.getItem("token")
            );
            if (check.data == 1) {
              this.$router.push({ path: "/home/review" });
            } else {
              this.$router.push({ path: "/home/create-post" });
            }
          },
        },

        {
          text: "Bài đăng",
          icon: "mdi-bookshelf",
          event: () => {
            this.$router.push({ path: "/home/my-post" });
          },
        },
        // {
        //   text: "Tạo CV",
        //   icon: "mdi-book-outline",
        //   event: async () => {
        //     //
        //   },
        // },
        {
          text: "Cài đặt tài khoản",
          icon: "mdi-cog",
          event: () => {
            this.$router.push({ path: "/home/user/inforcontact" });
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
            localStorage.removeItem("smg");
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
    this.kyc = localStorage.getItem("smg") !== "false";
    if (token || refreshToken) {
      this.showSignIn = false;
      this.user = {
        avatar: avatar,
        name: name,
        id: id,
        isKYC: this.kyc,
        nickName: nickName,
      };
    }
    if (role == 1 || role == 2) {
      this.isAdmin = true;
    }
    switch (this.user.name.length) {
      case 3:
        this.kycLeft = 164;
        break;
      case 4:
        this.kycLeft = 152;
        break;
      case 5:
        this.kycLeft = 144;
        break;
      case 6:
        this.kycLeft = 136;
        break;
      case 7:
        this.kycLeft = 130;
        break;
      case 8:
        this.kycLeft = 118;
        break;
      case 9:
        this.kycLeft = 108;
        break;
      case 10:
        this.kycLeft = 100;
        break;
      case 11:
        this.kycLeft = 90;
        break;
      case 12:
        this.kycLeft = 82;
        break;
      case 13:
        this.kycLeft = 74;
        break;
      case 14:
        this.kycLeft = 66;
        break;
      case 15:
        this.kycLeft = 54;
        break;
      case 16:
        this.kycLeft = 52;
        break;
      case 17:
        this.kycLeft = 50;
        break;
      case 18:
        this.kycLeft = 50;
        break;
      default:
        this.kycLeft = 50;
        break;
    }
  },
  methods: {
    ...mapGetters(["getIsKYC"]),
    ...mapMutations(["setIsLogIn"]),
    test() {
      alert(this.kyc);
    },
    async isLogin(tokenModel) {
      const loginStatus = await AuthApis.refreshToken(tokenModel);
    },
    setShowLogin() {
      this.kyc = false;
      this.showSignIn = true;
    },
    async setShowNotification() {
      var id = localStorage.getItem("id");
      var token = localStorage.getItem("token");
      const result = await UserAPI.getNotifi(id, token);
      this.notifications = result.data;
    },
    setShow() {
      this.setShowNotification();
    },
    async seenAll() {
      await UserAPI.seenAllNoti(
        localStorage.getItem("id"),
        localStorage.getItem("token")
      );
      this.setShowNotification();
    },
  },
};
</script>

<style lang="css" scoped>
.kyc {
  height: 16px;
  width: 16px;
  position: absolute;
  top: 7px;
}
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
  /* position: absolute; */
  /* top: 110%; */
  border-radius: 15px;
  max-height: 600px;
  /* z-index: 5; */
  overflow: scroll;
  /* left: -400px; */
}
#notification-seen:hover {
  cursor: pointer;
  color: #f5dcdc;
}
::-webkit-scrollbar {
  width: 0.5em;
}

@media screen and (max-width: 739px) {
}
@media screen and (max-width: 1023px) and (min-width: 740px) {
}
</style>
