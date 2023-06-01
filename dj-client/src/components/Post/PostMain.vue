<template>
  <h1 style="font-weight: 700; font-size: 30px">Bài viết công nghệ!</h1>
  <div style="min-height: 100vh; display: flex; justify-content: center">
    <div class="post-main-container"></div>
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
  border: 1px solid red;
}
</style>
