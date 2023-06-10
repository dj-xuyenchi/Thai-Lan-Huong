<template>
  <div class="content-container">
    <h1>{{ post.title }}</h1>

    <img
      :src="post.createrImg"
      alt="Hình ảnh"
      style="height: 40px; width: 40px; border-radius: 50%; float: left"
    />
    <span
      style="
        height: 40px;
        float: left;
        display: inline-flex;
        align-items: center;
        margin-left: 8px;
      "
      >{{ post.createrFullName }}</span
    >
    <img
      v-if="post.isCreaterKYC"
      :src="require('../../assets/kyc.png')"
      alt="Hình ảnh"
      class="kyc"
    />
    <div style="float: right">
      <v-btn
        variant="text"
        :class="fav ? 'text-red' : ''"
        icon="mdi-heart"
        @click="userLikePost()"
      >
      </v-btn>
      <span>{{ post.likeCount }}</span>
    </div>
  </div>
  <br />
  <br />
</template>

<script>
import UserAPI from "../../apis/APIUser/UserAPI.ts";
export default {
  name: "ContentHeader",
  data: () => ({
    fav: false,
    menu: false,
    message: false,
    hints: true,
  }),
  methods: {
    async userLikePost() {
      if (!localStorage.getItem("id")) {
        this.$router.push({ path: "/login" });
        return;
      }
      const data = await UserAPI.userLikePost(
        localStorage.getItem("id"),
        this.$route.params.id,
        localStorage.getItem("token")
      );
      if (data.data == 1) {
        this.fav = true;
        this.getPostDetail();
      }
    },
  },
  props: {
    post: Object,
    getPostDetail: Function,
  },
  created() {
    if (this.post.isLiked) {
      this.fav = true;
    } else {
      this.fav = false;
    }
  },
};
</script>

<style lang="css" scoped>
.content-container {
}
.content-container h1 {
  font-size: 32px;
  line-height: 150%;
  font-family: serif;
  font-weight: bold;
  margin-bottom: 15px;
  font-family: Arial;
}
.content-container .kyc {
  height: 18px;
  width: 18px;
  float: left;
  margin-top: 10px;
  margin-left: 4px;
}
</style>
