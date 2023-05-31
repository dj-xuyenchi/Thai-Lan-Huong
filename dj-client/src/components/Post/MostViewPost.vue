<template>
  <div class="mostviewpost-container">
    <router-link
      :to="`/home/post/` + item.id + `/` + titleFix"
      style="text-decoration: none; color: black"
      @click="setId(item.id)"
    >
      <div style="width: 120px; float: left">
        <img
          style="width: 120px; height: 72px"
          :src="`data:image/png;base64,` + item.postImg"
          alt=""
        />
      </div>
      <div style="width: 160px; margin-left: 8px; float: left">
        <span
          style="
            font-family: `Merriweather`, serif;
            font-size: 14px;
            line-height: 160%;
          "
          class="mostviewpost-title"
          >{{ titleFix
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
  data() {
    return {
      titleFix: "",
    };
  },
  props: {
    item: Object,
    setId: Function,
  },
  created() {
    if (this.item.title.length > 45) {
      this.titleFix = this.item.title.substring(0, 45) + "...";
    } else {
      this.titleFix = this.item.title;
    }
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
