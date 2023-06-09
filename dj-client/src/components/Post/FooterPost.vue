<template>
  <div class="footerpost-container">
    <h4 style="margin-bottom: 24px">Bình luận!</h4>
    <v-text-field
      placeholder="Ý kiến của bạn."
      variant="underlined"
      density="compact"
      v-model="content"
      @keydown.enter="commentRequest()"
      style="height: 40px; width: 100%; margin-bottom: 40px"
    >
      <font-awesome-icon
        icon="fa-solid fa-chevron-right"
        color="black"
        class="comment-enter"
        style="font-size: 20px; margin-right: 4px; position: absolute; right: 0"
        @click="commentRequest()"
    /></v-text-field>
    <CommentPost
      v-for="(item, i) in commentList"
      :key="i"
      :data="item"
      :commentId="item.commentId"
      :reLoadComment="handleGetComment"
      :resetClicked="resetClicked"
      :handleDialog="handleDialog"
    />
    <v-snackbar v-model="snackbar">
      {{ text }}
      <template v-slot:actions>
        <v-btn color="green" variant="text" @click="snackbar = false">
          Đóng
        </v-btn>
      </template>
    </v-snackbar>
  </div>
</template>
<script>
import PostAPI from "../../apis/APIPost/PostAPI";
import CommentPost from "./CommentPost";
export default {
  name: "FooterPost",
  components: { CommentPost },
  data() {
    return {
      commentList: [],
      commentCount: 0,
      content: "",
      snackbar: false,
      text: "",
    };
  },
  created() {
    this.handleGetComment();
  },
  methods: {
    async handleGetComment() {
      const token = localStorage.getItem("token");
      const userId = localStorage.getItem("id");
      const refreshToken = localStorage.getItem("refreshToken");
      const data = await PostAPI.commentOfPost(
        this.$route.params.id,
        userId ? userId : -1
      );
      this.commentList = data.data.listComment;
      this.commentCount = data.data.commentCount;
    },
    async commentRequest() {
      if (!localStorage.getItem("id")) {
        this.text = "Bạn chưa đăng nhập!";
        this.snackbar = true;
        return;
      }
      const token = localStorage.getItem("token");
      const data = await PostAPI.commmentPost(
        this.$route.params.id,
        localStorage.getItem("id"),
        this.content,
        token
      );
      this.content = "";
      this.handleGetComment();
    },
  },
  props: {
    handleDialog: Function,
  },
};
</script>

<style lang="css" scoped>
.footerpost-container {
  display: inline-block;
  width: 100%;
}
</style>
