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
    <span class="showAll" @click="redirect()">Xem tất cả </span>
    <div class="course-list">
      <PostItem
        v-for="(item, index) in postList"
        :key="index"
        :postImg="item.postImg"
        :postTitle="item.postTitle"
        :authorAvatar="item.createrAvatar"
        :postAuthor="item.createrFullName"
        :likeCount="item.likeCount"
        :cmtCount="item.cmtCount"
        :isKYC="item.isCreaterKYC"
        :id="item.id"
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
  props: {
    postList: [],
  },
  methods: {
    redirect() {
      this.$router.push({ path: "/home/post" });
    },
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
