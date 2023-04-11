<template>
  <div style="display: inline">
    <v-menu
      transition="slide-y-transition"
      :close-on-content-click="false"
      v-model="menu"
    >
      <template v-slot:activator="{ props }">
        <v-btn color="#4FC3F7" v-bind="props">
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
            subtitle="Nếu phát hiện bình luận span hoặc vi phạm quy tác report giúp tớ nha."
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
              style="width: 6%; height: 40px; float: left"
              :src="require('../../assets/logo-web.png')"
            />
            <v-text-field
              style="width: 90%; float: left; margin-left: 12px"
              color="primary"
              variant="underlined"
              placeholder="Thắc mắc của bạn là gì."
            ></v-text-field>
          </div>
        </div>
        <CommentItem v-for="(item, i) in commentList" :key="i" :data="item" />
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
    hints: true,
    commentList: [],
    commentCount: 0,
  }),
  computed: {
    ...mapGetters(["getAIProfile"]),
  },
  mounted() {
    const token = localStorage.getItem("token");
    const refreshToken = localStorage.getItem("refreshToken");
    this.getComment(this.$route.params.id, token);
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    async getComment(lessonId, token) {
      const data = await StudyAPI.getLobbyData(lessonId, token);
      this.commentList = data.data.listComment;
      this.commentCount = data.data.commentCount;
    },
  },
};
</script>

<style lang="scss" scoped></style>
