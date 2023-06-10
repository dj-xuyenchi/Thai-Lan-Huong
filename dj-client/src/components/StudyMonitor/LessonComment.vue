<template>
  <div style="display: inline">
    <v-menu
      transition="slide-y-transition"
      :close-on-content-click="false"
      v-model="menu"
    >
      <template v-slot:activator="{ props }">
        <v-btn color="#4FC3F7" v-bind="props" @click="handleGetComment()">
          <font-awesome-icon
            icon="fa-regular fa-comments"
            color="black"
            style="font-size: 20px; margin-right: 4px"
          />
          Thảo luận
        </v-btn>
      </template>
      <v-card height="70vh" width="700" style="border-radius: 15px">
        <v-list>
          <v-list-item
            :prepend-avatar="getAIProfile.avatar"
            :title="commentCount + ` bình luận`"
            subtitle="Nếu phát hiện bình luận span hoặc vi phạm quy tắc report giúp tớ nha."
          >
          </v-list-item>
        </v-list>
        <v-divider></v-divider>
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
              style="width: 6%; height: 40px; float: left; border-radius: 50%"
              :src="avatar"
            />
            <v-text-field
              style="width: 90%; float: left; margin-left: 12px"
              color="primary"
              variant="underlined"
              v-model="comment"
              placeholder="Thắc mắc của bạn là gì."
              @keydown.enter="commentRequest()"
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
                @click="commentRequest()"
            /></v-text-field>
          </div>
        </div>
        <CommentItem
          v-for="(item, i) in commentList"
          :key="i"
          :data="item"
          :commentId="item.commentId"
          :reLoadComment="handleGetComment"
          :resetClicked="resetClicked"
          :handleDialog="handleDialog"
        />
      </v-card>
    </v-menu>
  </div>
</template>

<script>
import CommentItem from "./CommentItem";
import { mapGetters } from "vuex";
import StudyAPI from "../../apis/APIStudy/StudyAPI.ts";
import { mapMutations } from "vuex";
export default {
  name: "LessonComment",
  components: { CommentItem },
  data: () => ({
    fav: true,
    menu: false,
    message: false,
    comment: "",
    hints: true,
    commentList: [],
    commentCount: 0,
    isClicked: false,
    avatar: "",
  }),
  computed: {
    ...mapGetters(["getAIProfile"]),
  },
  created() {
    const token = localStorage.getItem("token");
    const refreshToken = localStorage.getItem("refreshToken");
    const avatar = localStorage.getItem("avatar");
    this.avatar = avatar;
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    async handleGetComment() {
      if (this.isClicked) {
        return;
      }
      const token = localStorage.getItem("token");
      const userId = localStorage.getItem("id");
      const refreshToken = localStorage.getItem("refreshToken");
      const data = await StudyAPI.getLobbyData(
        this.$route.params.id,
        userId,
        token
      );
      this.commentList = data.data.listComment;
      this.commentCount = data.data.commentCount;
      this.isClicked = true;
    },
    async commentRequest() {
      this.isClicked = false;
      const token = localStorage.getItem("token");
      const commentLesson = {
        UserId: localStorage.getItem("id"),
        LessonId: this.$route.params.id,
        CourseId: this.$route.params.idCourse,
        CommentContent: this.comment,
      };
      const data = await StudyAPI.commentLesson(commentLesson, token);
      this.comment = "";
      this.handleGetComment();
    },
    resetClicked() {
      this.isClicked = false;
    },
  },
  props: {
    handleDialog: Function,
  },
};
</script>

<style lang="css" scoped>
.comment-enter:hover {
  cursor: pointer;
  z-index: 1;
  color: #a8a8a8;
}
::-webkit-scrollbar {
  width: 0.5em;
}
</style>
