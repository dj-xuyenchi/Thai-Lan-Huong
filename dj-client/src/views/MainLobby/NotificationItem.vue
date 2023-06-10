<template>
  <div class="noti-item" @click="seenNoti()">
    <div class="right-img">
      <img
        :src="data.avatar"
        alt="Hình ảnh"
        style="border-radius: 50%; height: 60px; width: 60px"
      />
    </div>
    <div class="left-content">
      <div class="content">
        <div style="margin-top: -10px" v-if="data.isKYC">
          <span style="font-weight: 600">
            {{ name }}
          </span>
          <div
            style="
              height: 24px;
              width: 20px;
              display: inline-block;
              position: relative;
            "
          >
            <img
              :src="require('../../assets/kyc.png')"
              alt="Hình ảnh"
              class="kyc"
            />
          </div>
          <span> {{ content }}</span>
        </div>
        <span v-if="!data.isKYC" style="margin-top: -10px">
          {{ data.content }}</span
        >
        <!-- <span style="font-weight: 500">DJ - CodeMaster.</span> -->
        <span class="timeline">{{ data.sendTime }}</span>
        <span class="isread" v-if="!data.isSeen"></span>
      </div>
    </div>
  </div>
</template>

<script>
import UserAPI from "../../apis/APIUser/UserAPI.ts";
export default {
  props: { data: Object, setShowNotification: Function },
  name: "NotificationItem",
  data() {
    return {
      name: "",
      content: "",
    };
  },
  methods: {
    async seenNoti() {
      await UserAPI.seenNoti(
        this.data.notificationId,
        localStorage.getItem("token")
      );
      this.setShowNotification();
    },
  },
  created() {
    const newContent = this.data.content.split("@KYC@");
    this.name = newContent[0];
    this.content = newContent[1];
  },
};
</script>

<style lang="css" scoped>
.kyc {
  height: 16px;
  position: absolute;
  top: 10px;
  width: 16px;
}
.noti-item {
  width: 98%;
  margin-left: 1%;
  height: 80px;
  border-radius: 15px;
}
.right-img {
  display: flex;
  justify-content: center;
  align-items: center;
  width: 20%;
  height: 80px;
  float: left;
}
.left-content {
  width: 80%;
  height: 80px;
  display: flex;
  align-items: center;
  float: left;
}

.left-content .content {
  height: 60px;
  position: relative;
  width: 90%;
  margin-left: 8px;
}

.left-content .content .timeline {
  color: #eb5353;
  position: absolute;
  bottom: 0;
  left: 0;
}
.left-content .content .isread {
  background-color: #eb5353;
  display: block;
  height: 10px;
  width: 10px;
  border-radius: 50%;
  position: absolute;
  bottom: 43%;
  right: -12px;
}
.left-content .content .weight {
  font-weight: bold;
}
.noti-item:hover {
  background-color: #dadde1;
  cursor: pointer;
}
</style>
