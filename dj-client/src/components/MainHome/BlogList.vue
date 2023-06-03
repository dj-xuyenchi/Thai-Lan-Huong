<template>
  <div class="blog-list-container">
    <div style="display: flex; align-items: center; padding-left: 14px">
      <img
        :src="require(`../../assets/user-avatar/5.jpg`)"
        alt="Hình ảnh"
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
        Xuyên Chi Vlog
      </span>
      <a
        href="https://www.youtube.com/channel/UCeJJbBp9ZSYwFK-U0YBY1pw"
        class="showAll"
        target="_blank"
        >Xem tất cả
      </a>
    </div>
    <div class="blog-list">
      <BlogItem
        v-for="(item, index) in blogList"
        :key="index"
        :postImg="item.blogImg"
        :postTitle="item.title"
        :likeCount="item.viewCount"
        :cmtCount="item.cmtCount"
        :postLink="item.blogLink"
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
  props: {
    blogList: [],
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
.showAll {
  color: red;
  font-size: 14px;
  font-weight: 900;
  padding-left: 14px;
  float: right;
  font: system-ui, "Segoe UI", Roboto, Helvetica, Arial, sans-serif,
    "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol";
}
.showAll:hover {
  cursor: pointer;
  text-decoration: underline;
  color: #eb5353;
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
    /* width: 33.33% !important; */
  }
}
</style>
