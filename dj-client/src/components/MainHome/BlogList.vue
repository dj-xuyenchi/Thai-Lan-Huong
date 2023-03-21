<template>
  <div class="blog-list-container">
    <div style="display: flex; align-items: center; padding-left: 14px">
      <img
        :src="require(`../../assets/user-avatar/5.jpg`)"
        alt=""
        style="width: 40px; border-radius: 50%"
      />
      <span
        style="
          color: #242424;
          font-size: 24px;
          font-weight: 900;
          padding-left: 14px;
          font: system-ui, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif,
            'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol';
        "
      >
        Xuyên Chi Blog
      </span>
    </div>
    <div class="blog-list">
      <BlogItem
        postImg="https://vdoc.edu.vn/wp-content/uploads/2022/03/crush-la-gi.png"
        postTitle="Cách tán đổ Crush bằng HTML CSS"
        likeCount="112"
        cmtCount="200"
      />
      <BlogItem
        postImg="https://vdoc.edu.vn/wp-content/uploads/2022/03/crush-la-gi.png"
        postTitle="Cách tán đổ Crush bằng HTML CSS"
        likeCount="112"
        cmtCount="200"
      />
      <BlogItem
        postImg="https://vdoc.edu.vn/wp-content/uploads/2022/03/crush-la-gi.png"
        postTitle="Cách tán đổ Crush bằng HTML CSS"
        likeCount="112"
        cmtCount="200"
      />
      <BlogItem
        postImg="https://vdoc.edu.vn/wp-content/uploads/2022/03/crush-la-gi.png"
        postTitle="Cách tán đổ Crush bằng HTML CSS"
        likeCount="112"
        cmtCount="200"
      />
      <BlogItem
        postImg="https://vdoc.edu.vn/wp-content/uploads/2022/03/crush-la-gi.png"
        postTitle="Cách tán đổ Crush bằng HTML CSS"
        likeCount="112"
        cmtCount="200"
      />
      <BlogItem
        postImg="https://vdoc.edu.vn/wp-content/uploads/2022/03/crush-la-gi.png"
        postTitle="Cách tán đổ Crush bằng HTML CSS"
        likeCount="112"
        cmtCount="200"
      />
      <BlogItem
        postImg="https://vdoc.edu.vn/wp-content/uploads/2022/03/crush-la-gi.png"
        postTitle="Cách tán đổ Crush bằng HTML CSS"
        likeCount="112"
        cmtCount="200"
      />
    </div>
  </div>
</template>

<script>
import BlogItem from "./BlogItem.vue";
export default {
  name: "BlogList",
  components: {
    BlogItem,
  },
};
</script>

<style lang="css" scoped>
.blog-list-container {
  margin-left: 3%;
  width: 92%;
}
.blog-list-container .blog-list {
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
}

@media screen and (max-width: 739px) {
  .blog-item {
    width: 100% !important;
  }

  .blog-item .item-hover {
    height: 200px !important;
  }

  .blog-item img {
    height: 200px !important;
  }
}
@media screen and (max-width: 1023px) and (min-width: 740px) {
  .blog-item {
    width: 50% !important;
  }
}

@media screen and (max-width: 1370px) and (min-width: 1023px) {
  .blog-item {
    width: 33.33% !important;
  }
}
</style>
