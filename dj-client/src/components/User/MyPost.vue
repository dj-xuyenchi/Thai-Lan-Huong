<template>
  <div style="min-height: 100vh">
    <h1 style="font-weight: 700; font-size: 30px">Bài viết của tôi</h1>
    <v-tabs v-model="tab" color="deep-purple-accent-4" align-tabs="start">
      <v-tab :value="1">Chờ duyệt</v-tab>
      <v-tab :value="2">Đã duyệt</v-tab>
      <v-tab :value="3">Không hiển thị</v-tab>
    </v-tabs>
    <v-window v-model="tab">
      <v-window-item :value="1">
        <v-container fluid>
          <v-row>
            <h4 v-if="waitPost.length == 0">Không có bài viết nào!</h4>
            <v-col
              v-for="(item, index) in waitPost"
              :key="index"
              cols="12"
              md="4"
            >
              <PostItem
                :postImg="item.postImg"
                :postTitle="item.title"
                authorAvatar=" "
                postAuthor=" "
                :likeCount="item.likeCount"
                :cmtCount="item.cmtCount"
                :isKYC="false"
                :id="item.id"
              />
            </v-col>
          </v-row>
        </v-container>
      </v-window-item>
      <v-window-item :value="2">
        <v-container fluid>
          <v-row>
            <h4 v-if="activePost.length == 0">Không có bài viết nào!</h4>
            <v-col
              v-for="(item, index) in activePost"
              :key="index"
              cols="12"
              md="4"
            >
              <PostItem
                :postImg="item.postImg"
                :postTitle="item.title"
                authorAvatar=" "
                postAuthor=" "
                :likeCount="item.likeCount"
                :cmtCount="item.cmtCount"
                :isKYC="false"
                :id="item.id"
              />
            </v-col>
          </v-row>
        </v-container>
      </v-window-item>
      <v-window-item :value="3">
        <v-container fluid>
          <v-row>
            <h4 v-if="unActivePost.length == 0">Không có bài viết nào!</h4>
            <v-col
              v-for="(item, index) in unActivePost"
              :key="index"
              cols="12"
              md="4"
            >
              <PostItem
                :postImg="item.postImg"
                :postTitle="item.title"
                authorAvatar=" "
                postAuthor=" "
                :likeCount="item.likeCount"
                :cmtCount="item.cmtCount"
                :isKYC="false"
                :id="item.id"
              />
            </v-col>
          </v-row>
        </v-container>
      </v-window-item>
    </v-window>
  </div>
</template>

<script>
import PostItem from "../MainHome/PostItem.vue";
import UserAPI from "../../apis/APIUser/UserAPI.ts";
import { mapMutations } from "vuex";
export default {
  components: { PostItem },
  data: () => ({
    tab: null,
    waitPost: [],
    activePost: [],
    unActivePost: [],
  }),
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    async getMyPost() {
      this.setIsLoadedData(true);
      const data = await UserAPI.getMyPost(
        localStorage.getItem("id"),
        localStorage.getItem("token")
      );
      if (data == null) {
        this.setIsLoadedData(false);
        return;
      }
      this.waitPost = data.data.waitPost;
      this.activePost = data.data.activePost;
      this.unActivePost = data.data.unactivePost;
      this.setIsLoadedData(false);
    },
  },
  created() {
    this.getMyPost();
  },
};
</script>

<style lang="scss" scoped></style>
