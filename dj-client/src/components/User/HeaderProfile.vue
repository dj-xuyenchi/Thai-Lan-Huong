<template>
  <div class="header-profile">
    <div class="icon-back-logo" @click="back2Home()">
      <img class="logo-header" :src="require('../../assets/logo-web.png')" />
      <font-awesome-icon
        icon="fa-solid fa-chevron-left"
        class="icon-back"
        style="margin-right: 12px"
      />
      <span style="font-size: 14px; color: #808990"> Quay lại </span>
    </div>
    <div class="user-logo">
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
            @click="setShowNotification()"
          />
        </template>
        <v-card width="400" class="notification-container">
          <v-card-text>
            <div
              class="font-weight-bold ms-1 mb-2"
              style="display: flex; justify-content: space-between"
            >
              <h6 style="font-size: 18px; font-weight: 400">Thông báo</h6>
              <span
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
    </div>
  </div>
</template>

<script>
import UserAPI from "../../apis/APIUser/UserAPI.ts";
import NotificationItem from "../../views/MainLobby/NotificationItem.vue";
export default {
  components: { NotificationItem },
  data() {
    return {
      notifications: null,
      menu: false,
    };
  },
  methods: {
    back2Home() {
      this.$router.push({ path: "/home/lobby" });
    },
    async setShowNotification() {
      var id = localStorage.getItem("id");
      var token = localStorage.getItem("token");
      const result = await UserAPI.getNotifi(id, token);
      this.notifications = result.data;
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
.header-profile {
  width: 100%;
  height: 80px;
}
.header-profile .icon-back-logo {
  height: 80px;
  display: inline-flex;
  justify-content: center;
  align-items: center;
  margin-left: 36px;
}

.header-profile .icon-back-logo:hover {
  cursor: pointer;
  color: black !important;
}
.header-profile .icon-back-logo .logo-header {
  height: 56px;
  width: 56px;
}
.header-profile .icon-back-logo .icon-back {
  margin-left: 12px;
  font-size: 12px;
  color: #808990;
}
.header-profile .user-logo {
  position: absolute;
  right: 0;
  width: 60px;
  height: 60px;
  display: flex;
  justify-content: center;
  align-items: center;
  top: 0;
}
.header-profile .user-logo .notification {
  font-size: 24px;
}

.header-profile .user-logo .notification:hover {
  cursor: pointer;
}
::-webkit-scrollbar {
  width: 0.5em;
}
</style>
