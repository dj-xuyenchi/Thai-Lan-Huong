<template>
  <div
    style="
      width: 20%;
      height: 1200px;
      border: 1px solid rgba(var(--v-border-color), var(--v-border-opacity));
      float: left;
      border-radius: 10px;
    "
  >
    <div style="margin-left: 28px; margin-top: 20px">
      <ul>
        <router-link to="/home/user/infocontact" style="text-decoration: none">
          <li class="active" @click="changBread(`Thông tin & liên hệ`)">
            Thông tin & liên hệ
          </li>
        </router-link>
        <li class="unactive" @click="changBread(`Kinh nghiệm & Học vấn`)">
          Kinh nghiệm & Học vấn
        </li>
        <li class="unactive" @click="changBread(`Đổi mật khẩu`)">
          Đổi mật khẩu
        </li>
      </ul>
    </div>
  </div>
</template>

<script>
export default {
  name: "UserInfoNavs",
  props: {
    changBread: Function,
  },
};
</script>

<style lang="css" scoped>
ul .unactive {
  margin-bottom: 14px;
  font-family: "Muli", sans-serif;
  font-weight: 400;
  font-size: 14px;
  line-height: 16px;
  color: #333;
}
ul .active {
  margin-bottom: 14px;
  font-family: "Muli", sans-serif;
  font-size: 14px;
  line-height: 16px;
  font-weight: bold;
  color: #4d96ff;
}
ul .unactive:hover {
  cursor: pointer;
  font-size: 15px;
  color: #4d96ff;
  font-weight: bold;
}
</style>
