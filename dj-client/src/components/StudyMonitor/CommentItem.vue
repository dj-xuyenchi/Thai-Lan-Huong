<template>
  <div style="margin: 2% 5% 2% 5%">
    <img
      style="width: 6%; height: 40px; float: left; border-radius: 50%"
      :src="require('../../assets/user-avatar/2.jpg')"
    />
    <div
      style="
        border-radius: 15px;
        display: inline-block;
        color: black;
        background-color: #f2f3f5;
        margin: 0px 4px 4px 8px;
      "
    >
      <span
        style="
          padding: 6px 12px 8px 12px;
          font-weight: 450;
          font-size: 16px;
          display: block;
        "
        >Thái Lan Hương.</span
      >
      <span style="padding: 0px 12px 8px 12px; font-size: 16px; display: block"
        >Tuyệt vời ông mặt trời</span
      >
    </div>
    <div class="comment-option-container">
      <ul class="comment-option">
        <li class="more-option-content">Thích</li>
        <li class="more-option-content">Phản hồi</li>
        <li style="font-weight: 400">4 Ngày trước</li>
        <li>
          <v-menu :close-on-content-click="false">
            <template v-slot:activator="{ props }">
              <font-awesome-icon
                v-bind="props"
                icon="fa-solid fa-ellipsis"
                color="#e7e7e7"
                class="more-option-content"
              />
            </template>
            <v-list style="border-radius: 15px">
              <v-list-item
                class="option-more-item"
                v-for="(item, i) in items"
                :key="i"
              >
                <v-list-item-title>{{ item.title }}</v-list-item-title>
              </v-list-item>
            </v-list>
          </v-menu>
        </li>
      </ul>
    </div>
    <span class="show-comment-child"
      >Xem thêm 2 câu trả lời
      <font-awesome-icon icon="fa-solid fa-chevron-down" />
    </span>
  </div>
</template>

<script>
export default {
  name: "CommentItem",
  data: () => ({
    items: [{ title: "Báo cáo bình luận" }, { title: "Ẩn bình luận." }],
    commentChild: [
      {
        id: 1,
        likeCount: 20,
        userName: "Mộc Quế Anh",
        commentContent: "Hí hí hí",
      },
    ],
  }),
};
</script>

<style lang="css" scoped>
.comment-option-container .comment-option li {
  display: inline;
  font-size: 12px;
  margin-right: 12px;
  font-weight: 500;
}
.comment-option-container .more-option-icon:hover {
  color: black;
}
.comment-option-container .comment-option {
  margin-left: 8px;
}
.comment-option-container {
  margin-left: 6%;
}
.option-more-item:hover {
  background-color: #e7e7e7;
  cursor: pointer;
}
.more-option-content:hover {
  color: black;
  cursor: pointer;
}
.show-comment-child {
  font-size: 12px;
  font-weight: bold;
  margin-left: 8%;
}
.show-comment-child:hover {
  cursor: pointer;
  color: black;
}
</style>
