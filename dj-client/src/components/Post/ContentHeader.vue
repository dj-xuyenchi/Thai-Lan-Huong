<template>
  <div class="content-container">
    <h1>{{ post.title }}</h1>
    <v-list-item
      lines="one"
      :prepend-avatar="`data:image/png;base64,` + post.createrImg"
      :title="post.createrFullName"
      style="padding: unset; position: relative; margin-bottom: 20px"
      append-avatar="require('../../assets/kyc.png')"
    >
      <!-- <img
        v-if="post.isCreaterKYC"
        :src="require('../../assets/kyc.png')"
        alt=""
        class="kyc"
      /> -->
      <template v-slot:append>
        <v-btn
          variant="text"
          :class="fav ? 'text-red' : ''"
          icon="mdi-heart"
          @click="fav = !fav"
        ></v-btn>
        <span>{{ post.likeCount }}</span>
      </template>
    </v-list-item>
  </div>
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
  height: 16px;
  width: 16px;
}
</style>
