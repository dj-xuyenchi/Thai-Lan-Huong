<template>
  <div class="body-profile">
    <img
      :src="require('../../assets/banner.png')"
      alt="Hình ảnh"
      style="border-bottom-right-radius: 15px; border-bottom-left-radius: 15px"
    />
    <div class="backgound-avatar">
      <img :src="item.avatar" alt="Hình ảnh" class="avatar" />
    </div>
    <div class="user-name">
      <span
        >{{ item.fullName }}
        <img
          :src="require('../../assets/kyc.png')"
          alt="Hình ảnh"
          class="kyc"
          v-if="item.isKYC"
        />
      </span>
    </div>
  </div>
</template>
<script>
export default {
  data() {
    return {};
  },
  props: {
    item: Object,
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
  left: 5%;
  margin-left: 180px;
  bottom: -12%;
}

.body-profile .user-name .kyc {
  height: 20px;
  width: 20px;
  margin-bottom: -2px;
}
.body-profile .information {
  width: 100%;
  position: absolute;
}

.body-profile .information .left {
  width: 30%;
  margin-left: 2%;
}

.body-profile .information .left .introduce {
  height: 120px;
  width: 100%;
  border-radius: 10px;
  box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
}
</style>
