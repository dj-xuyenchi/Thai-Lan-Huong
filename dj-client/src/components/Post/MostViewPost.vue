<template>
  <div class="mostviewpost-container">
    <div style="width: 120px">
      <img
        style="width: 120px; height: 72px"
        src="https://gaixinh.photo/wp-content/uploads/2021/10/anh-hot-girl-6.jpg"
        alt=""
      />
    </div>
    <router-link
      to="event"
      style="text-decoration: none; color: black; margin-left: 8px"
    >
      <span
        style="
          font-family: `Merriweather`, serif;
          font-size: 14px;
          line-height: 160%;
        "
        class="mostviewpost-title"
        >Hot Girl Hoàng Công Chất lộ clip cùng bạn trai 90 múi.<v-icon
          size="small"
          color="#93908a"
          icon="mdi-message-text"
          style="margin-left: 8px"
        ></v-icon
        ><span style="margin-left: 4px; color: #29b6f6">81</span></span
      >
    </router-link>
  </div>
</template>
<script>
export default {
  name: "MostViewPost",
};
</script>

<style lang="css" scoped>
.mostviewpost-container {
  margin: 12px 0 8px 0;
  display: flex;
  width: 40%;
}
.mostviewpost-container .mostviewpost-title:hover {
  cursor: pointer;
  color: blue;
}
</style>
