<template>
  <div class="content-container">
    <h1>{{ post.title }}</h1>

    <img
      :src="`data:image/png;base64,` + post.createrImg"
      alt=""
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
      alt=""
      class="kyc"
    />
    <div style="float: right">
      <v-btn
        variant="text"
        :class="fav ? 'text-red' : ''"
        icon="mdi-heart"
        @click="fav = !fav"
      >
      </v-btn>
      <span>{{ post.likeCount }}</span>
    </div>
  </div>
  <br />
  <br />
</template>

<script>
export default {
  name: "ContentHeader",
  data: () => ({
    fav: true,
    menu: false,
    message: false,
    hints: true,
  }),
  props: {
    post: Object,
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
