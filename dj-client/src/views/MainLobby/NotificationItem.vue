<template>
  <div class="noti-item">
    <div class="right-img">
      <img
        src="https://demoda.vn/wp-content/uploads/2022/04/hinh-cute-anh-cute.jpg"
        alt=""
        style="border-radius: 50%; height: 60px; width: 60px"
      />
    </div>
    <div class="left-content">
      <div class="content">
        <span>Chào mừng bạn đến với website học lập trình </span>
        <span style="font-weight: 500">DJ - CodeMaster.</span>
        <span class="timeline">4 ngày trước</span>
        <span class="isread"></span>
      </div>
    </div>
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
.noti-item:hover {
  background-color: #dadde1;
  cursor: pointer;
}
</style>
