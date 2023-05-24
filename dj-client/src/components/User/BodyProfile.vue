<template>
  <div class="body-profile">
    <img
      :src="require('../../assets/banner.png')"
      alt=""
      style="border-bottom-right-radius: 15px; border-bottom-left-radius: 15px"
    />
    <div class="backgound-avatar">
      <img :src="`data:image/jpeg;base64,` + avatar" alt="" class="avatar" />
    </div>
    <div class="user-name">
      <span
        >Đỗ Quang Anh
        <img :src="require('../../assets/kyc.png')" alt="" class="kyc" />
      </span>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      avatar: "",
    };
  },
  mounted() {
    this.avatar = localStorage.getItem(`avatar`);
  },
};
</script>

<style lang="css" scoped>
.body-profile {
  position: absolute;
  width: 70%;
  left: 15%;
  top: 0;
}
.body-profile img {
  width: 100%;
  height: 360px;
}
.body-profile .backgound-avatar {
  height: 170px;
  width: 170px;
  position: absolute;
  left: 5%;
  bottom: -15%;
  display: flex;
  justify-content: center;
  align-items: center;
  border-radius: 50%;
  background-color: white;
}
.body-profile .avatar {
  height: 160px;
  width: 160px;
  border-radius: 50%;
}

.body-profile .user-name {
  font-size: 24px;
  font-weight: bold;
  position: absolute;
  left: 23%;
  bottom: -12%;
}

.body-profile .user-name .kyc {
  height: 20px;
  width: 20px;
  margin-bottom: -2px;
}
</style>
