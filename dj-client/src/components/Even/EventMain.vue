<template>
  <h1 style="font-weight: 700; font-size: 30px">Sự kiện!</h1>
  <div style="min-height: 100vh; display: flex; justify-content: center">
    <div class="post-main-container">
      <h4>Coming soon</h4>
    </div>
  </div>
</template>

<script>
import PostAPI from "../../apis/APIPost/PostAPI";
export default {
  name: "EventMain",
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
