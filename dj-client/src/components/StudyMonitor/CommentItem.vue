<template>
  <div style="margin: 2% 5% 2% 5%">
    <img
      style="width: 6%; height: 40px; float: left; border-radius: 50%"
      :src="data.userAvatar"
    />
    <div
      style="
        border-radius: 15px;
        display: inline-block;
        color: black;
        background-color: #f2f3f5;
        margin: 0px 4px 4px 8px;
        position: relative;
        width: 92%;
      "
    >
      <span
        style="
          padding: 6px 12px 8px 12px;
          font-weight: 450;
          font-size: 16px;
          display: block;
        "
        >{{ data.userName
        }}<img
          v-if="data.isKYC"
          :src="require('../../assets/kyc.png')"
          alt="Hình ảnh"
          class="kyc"
      /></span>

      <span
        style="padding: 0px 12px 8px 12px; font-size: 16px; display: block"
        >{{ data.comment }}</span
      >
      <div
        style="position: absolute; right: 0; bottom: -12px"
        v-if="data.likeCount > 0"
      >
        <font-awesome-icon
          icon="fa-solid fa-heart"
          color="black"
          style="margin-right: 5px; color: #f44336"
        />
        <span style="font-size: 14px">{{ data.likeCount }}</span>
      </div>
    </div>
    <div class="comment-option-container">
      <ul class="comment-option">
        <li
          class="more-option-content"
          v-if="data.isLike"
          @click="likeComment(data.commentId)"
          style="color: #2078f4"
        >
          Bỏ thích
        </li>
        <li
          class="more-option-content"
          v-if="!data.isLike"
          @click="likeComment(data.commentId)"
        >
          Thích
        </li>
        <li class="more-option-content" @click="showResponComment()">
          Phản hồi
        </li>
        <li style="font-weight: 400">{{ data.commentDate }}</li>
        <li>
          <v-menu :close-on-content-click="false">
            <template v-slot:activator="{ props }">
              <font-awesome-icon
                v-bind="props"
                icon="fa-solid fa-ellipsis"
                color="#808990"
                class="more-option-content"
              />
            </template>
            <v-list style="border-radius: 15px">
              <v-list-item
                v-for="(item, i) in items"
                :key="i"
                class="option-more-item"
                @click="handleDialog(data.commentId)"
              >
                <v-list-item-title>{{ item.title }}</v-list-item-title>
              </v-list-item>
            </v-list>
          </v-menu>
        </li>
      </ul>
    </div>
    <span
      class="show-comment-child"
      @click="showResponComment"
      v-if="data.subComment.length > 0"
    >
      <span v-if="commentRespon == false"
        >Xem thêm {{ data.subComment.length }} câu trả lời
        <font-awesome-icon
          icon="fa-solid fa-chevron-down"
          style="margin-left: 4px"
      /></span>
      <span v-else
        >Ẩn câu trả lời
        <font-awesome-icon
          icon="fa-solid fa-chevron-up"
          style="margin-left: 4px"
      /></span>
    </span>
    <v-list style="border-radius: 15px" v-if="commentRespon == true">
      <v-list-item
        class="option-more-item"
        v-for="(item, i) in data.subComment"
        :key="i"
      >
        <div style="margin-left: 6%; margin-top: 1%">
          <img
            style="width: 40px; height: 40px; float: left; border-radius: 50%"
            :src="item.userAvatar"
          />
          <div
            style="
              border-radius: 15px;
              display: inline-block;
              color: black;
              background-color: #f2f3f5;
              margin: 0px 4px 4px 8px;
              position: relative;
              width: 88%;
            "
          >
            <span
              style="
                padding: 6px 12px 8px 12px;
                font-weight: 450;
                font-size: 16px;
                display: block;
              "
              >{{ item.userName
              }}<img
                v-if="item.isKYC"
                :src="require('../../assets/kyc.png')"
                alt="Hình ảnh"
                class="kyc"
            /></span>
            <span
              style="
                padding: 0px 12px 8px 12px;
                font-size: 16px;
                display: block;
              "
              >{{ item.comment }}</span
            >
            <div
              style="position: absolute; right: 0; bottom: -12px"
              v-if="item.likeCount > 0"
            >
              <font-awesome-icon
                icon="fa-solid fa-heart"
                color="black"
                style="margin-right: 5px; color: #f44336"
              />
              <span style="font-size: 14px">{{ item.likeCount }}</span>
            </div>
          </div>
          <div class="comment-option-container">
            <ul class="comment-option">
              <li
                class="more-option-content"
                v-if="item.isLike"
                @click="likeComment(item.commentId)"
                style="color: #2078f4"
              >
                Bỏ thích
              </li>
              <li
                class="more-option-content"
                v-if="!item.isLike"
                @click="likeComment(item.commentId)"
              >
                Thích
              </li>

              <li class="more-option-content">Phản hồi</li>
              <li style="font-weight: 400">
                {{ item.commentDate }}
              </li>
              <li>
                <v-menu :close-on-content-click="false">
                  <template v-slot:activator="{ props }">
                    <font-awesome-icon
                      v-bind="props"
                      icon="fa-solid fa-ellipsis"
                      color="#808990"
                      class="more-option-content"
                    />
                  </template>
                  <v-list style="border-radius: 15px">
                    <v-list-item
                      v-for="(item2, index) in items"
                      :key="index"
                      @click="handleDialog(item.commentId)"
                      class="option-more-item"
                    >
                      <v-list-item-title>{{ item2.title }}</v-list-item-title>
                    </v-list-item>
                  </v-list>
                </v-menu>
              </li>
            </ul>
          </div>
        </div>
      </v-list-item>
      <div style="display: flex; justify-content: center">
        <div
          style="
            width: 90%;
            margin-top: 8px;
            display: flex;
            align-items: center;
          "
        >
          <img
            style="width: 40px; height: 40px; float: left; border-radius: 50%"
            :src="avatar"
          />
          <v-text-field
            style="width: 90%; float: left; margin-left: 12px"
            color="primary"
            variant="underlined"
            placeholder="Ý kiến của bạn."
            v-model="comment"
            @keydown.enter="subcommentResquest()"
          >
            <font-awesome-icon
              icon="fa-solid fa-chevron-right"
              color="black"
              class="comment-enter"
              style="
                font-size: 20px;
                margin-right: 4px;
                position: absolute;
                right: 0;
              "
              @click="subcommentResquest()"
          /></v-text-field>
        </div>
      </div>
    </v-list>
  </div>
</template>

<script>
import StudyAPI from "../../apis/APIStudy/StudyAPI.ts";
export default {
  name: "CommentItem",
  data: () => ({
    dialog: false,
    items: [
      {
        title: "Báo cáo bình luận",
        // event: () => {
        //   this.handleDialog();
        // },
      },
      // { title: "Ẩn bình luận." }
    ],
    commentChild: [
      {
        id: 1,
        likeCount: 20,
        userName: "Mộc Quế Anh",
        commentContent: "Hí hí hí",
      },
    ],
    comment: "",
    commentRespon: false,
    avatar: "",
  }),
  methods: {
    showResponComment() {
      this.commentRespon = !this.commentRespon;
    },
    async subcommentResquest() {
      const token = localStorage.getItem("token");
      const commentLesson = {
        UserId: localStorage.getItem("id"),
        LessonId: this.$route.params.id,
        CourseId: this.$route.params.idCourse,
        CommentContent: this.comment,
        CommentParentId: this.commentId,
      };
      const data = await StudyAPI.subCommentLesson(commentLesson, token);
      this.comment = "";
      this.resetClicked();
      this.reLoadComment();
    },
    async likeComment(commentId) {
      const token = localStorage.getItem("token");
      const userId = localStorage.getItem("id");
      const likeComment = {
        UserId: userId,
        CommentId: commentId,
      };
      const data = await StudyAPI.likeComment(likeComment, token);
      this.resetClicked();
      this.reLoadComment();
    },
  },
  created() {
    const avatar = localStorage.getItem("avatar");
    this.avatar = avatar;
  },
  props: {
    data: Object,
    commentId: Number,
    reLoadComment: Function,
    resetClicked: Function,
    handleDialog: Function,
  },
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
  margin-left: 18px;
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
  margin-left: 10%;
}
.show-comment-child:hover {
  cursor: pointer;
  color: black;
}
.comment-enter:hover {
  cursor: pointer;
  z-index: 1;
  color: #a8a8a8;
}
.kyc {
  height: 16px;
  width: 16px;
  margin-bottom: -2px;
  margin-left: 4px;
}
</style>
