<template>
  <div class="post-item">
    <v-hover v-slot="{ isHovering, props }">
      <v-card
        ref="gg"
        class="mx-auto rounded-xl item-hover"
        v-bind="props"
        variant="none"
        width="380px"
        height="220px"
      >
        <img :src="postImg" alt="" />
        <v-overlay
          :model-value="isHovering"
          contained
          scrim="#036358"
          class="align-center justify-center"
        >
          <router-link :to="`/home/post/` + 1" style="text-decoration: none">
            <v-btn variant="flat rounded-xl">Xem bài viết</v-btn>
          </router-link>
        </v-overlay>
      </v-card>
    </v-hover>
    <div class="post-detail">
      <div style="width: 100%">
        <span
          style="
            color: #242424;
            font-size: 16px;
            font-weight: 500;
            font: system-ui, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif,
              'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol';
          "
          >{{ postTitle }}</span
        >
      </div>
      <div class="author-info">
        <img :src="require(`../../assets/user-avatar/1.jpg`)" alt="" />
        <span>{{ postAuthor }}</span>
        <div class="react-info">
          <font-awesome-icon icon="fa-solid fa-heart" class="react-icon" />
          <span style="margin-right: 18px">{{ likeCount }}</span>
          <font-awesome-icon icon="fa-regular fa-comment" class="react-icon" />
          <span>{{ cmtCount }}</span>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "CourseItem",
  data: () => ({
    // v-card--variant-elevated
    overlay: false,
  }),
  props: {
    postImg: String,
    postTitle: String,
    authorAvatar: String,
    postAuthor: String,
    likeCount: String,
    cmtCount: String,
  },
  mounted() {
    const g = this.$refs.gg;
    console.log(g);
  },
};
</script>

<style lang="css" scoped>
.post-item {
  margin-top: 14px;
  width: 380px;
  height: 220px;
  margin-bottom: 36px;
  padding: 0 14px 0 14px;
  margin-left: 1%;
  margin-bottom: 60px;
}

.post-item img {
  width: 380px;
  height: 220px;
}
.post-item .post-detail {
  width: 100%;
  margin-top: 14px;
}
.item-hover:hover {
  cursor: pointer;
}
.post-detail span:hover {
  cursor: pointer;
}
.author-info {
  width: 100%;
  margin-top: 8px;
  display: flex;
  align-items: center;
  position: relative;
}
.author-info img {
  width: 32px;
  height: 32px;
  border-radius: 50%;
}
.author-info span {
  margin: 0 8px 0 8px;
  color: #242424;
  font-size: 14px;
  font-weight: 500;
  font: system-ui, "Segoe UI", Roboto, Helvetica, Arial, sans-serif,
    "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol";
}
.react-info {
  display: flex;
  position: absolute;
  width: 100%;
  justify-content: flex-end;
  height: 32px;
  align-items: center;
}

.react-info .react-icon {
  font-size: 16px;
}
</style>
