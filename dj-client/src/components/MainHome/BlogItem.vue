<template>
  <div class="blog-item">
    <v-hover v-slot="{ isHovering, props }">
      <v-card
        ref="gg"
        class="mx-auto rounded-xl item-hover"
        v-bind="props"
        variant="none"
        width="380px"
        height="240px"
      >
        <img :src="postImg" alt="Hình ảnh" />
        <v-overlay
          :model-value="isHovering"
          contained
          scrim="#036358"
          class="align-center justify-center"
        >
          <a
            :href="`https://youtu.be/` + postLink"
            style="text-decoration: none"
            target="_blank"
          >
            <v-btn variant="flat rounded-xl">Xem Vlog</v-btn>
          </a>
        </v-overlay>
      </v-card>
    </v-hover>
    <div class="blog-detail">
      <div style="width: 100%">
        <h5
          style="
            color: #242424;
            font-size: 16px;
            font-weight: 500;
            font: system-ui, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif,
              'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol';
          "
        >
          {{ postTitle }}
        </h5>
      </div>
      <div class="blog-info">
        <div>
          <font-awesome-icon icon="fa-solid fa-eye" class="react-icon" />
          <span style="margin-right: 18px">{{ likeCount }}</span>
        </div>
        <div>
          <font-awesome-icon icon="fa-regular fa-comment" class="react-icon" />
          <span>{{ cmtCount }}</span>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "BlogItem",
  data: () => ({
    // v-card--variant-elevated
    overlay: false,
  }),
  props: {
    postImg: String,
    postTitle: String,
    likeCount: String,
    cmtCount: String,
    postLink: String,
  },
};
</script>

<style lang="css" scoped>
.blog-item {
  margin-top: 14px;
  width: 380px;
  height: 240px;
  margin-bottom: 36px;
  padding: 0 14px 0 14px;
  margin-left: 1%;
  margin-bottom: 80px;
}

.blog-item img {
  width: 380px;
  height: 240px;
}
.blog-item .blog-detail {
  width: 100%;
  margin-top: 14px;
}
.item-hover:hover {
  cursor: pointer;
}
.blog-detail span:hover {
  cursor: pointer;
}
.blog-info {
  width: 100%;
  margin-top: 8px;
  display: flex;
  align-items: center;
  justify-content: space-between;
}

.blog-info .react-icon {
  font-size: 16px;
  margin-right: 8px;
}
</style>
