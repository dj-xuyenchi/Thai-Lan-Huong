<template>
  <div class="course-list-container">
    <span
      style="
        color: #242424;
        font-size: 24px;
        font-weight: 900;
        padding-left: 14px;
        font: system-ui, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif,
          'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol';
      "
      >Bài viết nổi bật
    </span>
    <div class="course-list">
      <PostItem
        postImg="https://vdoc.edu.vn/wp-content/uploads/2022/03/crush-la-gi.png"
        postTitle="Cách tán đổ Crush bằng HTML CSS"
        authorAvatar="@/assets/user-avatar/1.jpg"
        postAuthor="Bé Na"
        likeCount="112"
        cmtCount="200"
      />
      <PostItem
        postImg="https://vdoc.edu.vn/wp-content/uploads/2022/03/crush-la-gi.png"
        postTitle="Cách hack NASA bằng HTML CSS"
        authorAvatar="@/assets/user-avatar/2.jpg"
        postAuthor="Bé Chíp"
        likeCount="222"
        cmtCount="11"
      />
      <PostItem
        postImg="https://vdoc.edu.vn/wp-content/uploads/2022/03/crush-la-gi.png"
        postTitle="Trộm tiền mẹ nạp Tài Xỉu"
        authorAvatar="@/assets/user-avatar/3.jpg"
        postAuthor="Bé Mai"
        likeCount="231"
        cmtCount="12"
      />
    </div>
  </div>
</template>

<script>
import PostItem from "./PostItem.vue";
export default {
  name: "PostList",
  components: {
    PostItem,
  },
};
</script>

<style lang="css" scoped>
.course-list-container {
  margin-left: 3%;
  width: 92%;
  margin-bottom: 40px;
}
.course-list-container .course-list {
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
}

@media screen and (max-width: 739px) {
  .post-item {
    width: 100% !important;
  }

  .post-item .item-hover {
    height: 200px !important;
  }

  .post-item img {
    height: 200px !important;
  }
}
@media screen and (max-width: 1023px) and (min-width: 740px) {
  .post-item {
    width: 50% !important;
  }
}

@media screen and (max-width: 1370px) and (min-width: 1023px) {
  .post-item {
    /* width: 33.33% !important; */
  }
}
</style>
