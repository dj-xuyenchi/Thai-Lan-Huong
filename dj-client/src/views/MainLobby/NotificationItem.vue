<template>
  <div class="noti-item">
    <div class="right-img">
      <img
        src="https://demoda.vn/wp-content/uploads/2022/04/hinh-cute-anh-cute.jpg"
        alt=""
        style="border-radius: 50%; height: 60px; width: 60px"
      />
    </div>
    <div class="left-content"></div>
  </div>
</template>

<script>
export default {
  name: "NotificationItem",
};
</script>

<style lang="css" scoped>
.noti-item {
  width: 98%;
  margin-left: 1%;
  height: 80px;
  border-radius: 15px;
}
.noti-item:hover {
  background-color: #dadde1;
  cursor: pointer;
}
</style>
