<template>
  <div style="margin-left: 12%">
    <div style="margin-bottom: 16px">
      <span class="bread">Thông tin cá nhân</span
      ><span style="font-size: 13px"> > </span>
      <span class="bread">{{ infoNav }}</span>
    </div>
    <UserInfoNavs :changBread="changBread" />
    <UserInfoDetail />
  </div>
</template>

<script>
import UserInfoNavs from "./UserInfoNavs.vue";
import UserInfoDetail from "./UserInfoDetail.vue";
export default {
  name: "UserMain",
  components: { UserInfoNavs, UserInfoDetail },
  data() {
    return {
      infoNav: "Thông tin & Liên hệ",
    };
  },
  methods: {
    changBread(newBread) {
      this.infoNav = newBread;
    },
  },
};
</script>

<style lang="css" scoped>
.bread {
  color: #2c31cf;
  font-size: 13px;
}
.bread:hover {
  cursor: pointer;
  text-decoration: underline;
}
</style>
