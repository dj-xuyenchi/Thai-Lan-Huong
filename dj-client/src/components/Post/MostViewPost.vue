<template>
  <div class="mostviewpost-container">
    <router-link
      :to="`/home/post/` + item.id"
      style="text-decoration: none; color: black"
    >
      <div style="width: 120px">
        <img
          style="width: 120px; height: 72px"
          :src="`data:image/png;base64,` + item.postImg"
          alt=""
        />
      </div>
      <div style="width: 160px; margin-left: 8px">
        <span
          style="
            font-family: `Merriweather`, serif;
            font-size: 14px;
            line-height: 160%;
          "
          class="mostviewpost-title"
          >{{ item.title
          }}<v-icon
            size="small"
            color="#93908a"
            icon="mdi-message-text"
            style="margin-left: 8px"
          ></v-icon
          ><span style="margin-left: 4px; color: #29b6f6">{{
            item.cmtCount
          }}</span></span
        >
      </div>
    </router-link>
  </div>
</template>
<script>
export default {
  name: "MostViewPost",
  props: {
    item: Object,
  },
};
</script>

<style lang="css" scoped>
.mostviewpost-container {
  margin: 12px 0 8px 0;
  display: flex;
  width: 100%;
}
.mostviewpost-container .mostviewpost-title:hover {
  cursor: pointer;
  color: blue;
}
</style>
