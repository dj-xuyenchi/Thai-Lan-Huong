<template>
  <h1 style="font-weight: 700; font-size: 30px">Bài viết công nghệ!</h1>
  <div style="min-height: 150vh; display: flex; justify-content: center">
    <div class="post-main-container">
      <router-link
        :to="
          `/home/post/` +
          postMainData.hotPost?.id +
          `/` +
          postMainData.hotPost?.title
        "
        style="text-decoration: none; color: black"
      >
        <div style="width: 60%; float: left">
          <img
            :src="postMainData.hotPost?.img"
            alt="Hình ảnh"
            style="width: 100%; height: 420px"
          />
          <h3 class="hot-title">
            {{ postMainData.hotPost?.title }}
          </h3>
        </div>
      </router-link>
      <div
        style="width: 40%; float: left"
        v-for="(item, index) in postMainData.postCreateOrderBy"
        :key="index"
      >
        <router-link
          :to="`/home/post/` + item.id + `/` + fixUrl(item.title)"
          style="text-decoration: none; color: black"
        >
          <div class="post-item">
            <div style="width: 50%; float: left">
              <img
                :src="item.img"
                alt="Hình ảnh"
                style="width: 100%; height: 110px"
              />
            </div>
            <div style="width: 50%; float: left">
              <h4 style="width: 90%; margin-left: 5%">{{ item.title }}</h4>
            </div>
          </div>
        </router-link>
        <div
          style="height: 155px; width: 100%"
          v-if="index == 0 || index == 1"
        ></div>
      </div>
    </div>
  </div>
</template>

<script>
import PostAPI from "../../apis/APIPost/PostAPI";
export default {
  name: "PostMain",
  data() {
    return {
      postMainData: {},
    };
  },
  methods: {
    async getPostMain() {
      const data = await PostAPI.getPostMain();
      this.postMainData = data.data;
    },
    fixUrl(input) {
      input = input.replaceAll(" ", "-").toLowerCase();
      while (input.includes("--")) {
        input = input.replace("--", "-");
      }
      input = input.replaceAll("đ", "d");
      return input.normalize("NFD").replace(/[\u0300-\u036f]/g, "");
    },
  },
  created() {
    this.getPostMain();
  },
};
</script>

<style lang="css" scoped>
.post-main-container {
  width: 1000px;
  height: 100px;
  margin-top: 18px;
}
.post-main-container .hot-title {
  position: absolute;
  top: 540px;
  z-index: 1;
  margin-left: 12px;
  color: white;
}

.post-main-container .hot-title:hover {
  cursor: pointer;
  color: violet;
}
.post-main-container .post-item {
  width: 90%;
  margin-left: 5%;
}
.post-main-container .post-item:hover {
  cursor: pointer;
  color: violet;
}
</style>
