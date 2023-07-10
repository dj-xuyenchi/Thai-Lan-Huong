<template>
  <div class="mostviewpost-container">
    <a
      :href="
        `https://dj-xuyenchi.edu.vn/#/home/post/` +
        item.id +
        `/` +
        fixUrl(item.title)
      "
      style="text-decoration: none; color: black"
      target="_blank"
    >
      <div style="width: 120px; float: left">
        <img
          style="width: 120px; height: 72px"
          :src="item.postImg"
          alt="Hình ảnh"
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
    </a>
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
  },
  created() {
    if (this.item.title.length > 45) {
      this.titleFix = this.item.title.substring(0, 45) + "...";
    } else {
      this.titleFix = this.item.title;
    }
  },
  methods: {
    fixUrl(input) {
      input = input.replaceAll(" ", "-").toLowerCase();
      while (input.includes("--")) {
        input = input.replace("--", "-");
      }
      input = input.replaceAll("đ", "d");
      return input.normalize("NFD").replace(/[\u0300-\u036f]/g, "");
    },
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
