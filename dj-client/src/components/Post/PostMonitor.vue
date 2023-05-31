<template>
  <div class="post-container">
    <div
      style="
        display: flex;
        justify-content: space-between;
        width: 60%;
        align-items: center;
      "
    >
      <span
        style="
          color: #242424;
          font-size: 24px;
          font-weight: 600;
          padding-left: 14px;
          font: system-ui, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif,
            'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol';
        "
        >Bài viết
      </span>
      <span
        style="
          color: #242424;
          font-weight: 350;
          font: system-ui, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif,
            'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol';
        "
        >{{ post.createPostTime }}</span
      >
    </div>
    <div style="margin-left: 14px; margin-top: 20px">
      <div class="post-action">
        <div style="margin-top: 180px">
          <font-awesome-icon icon="fa-brands fa-facebook" class="react-icon" />
        </div>
        <div>
          <font-awesome-icon icon="fa-brands fa-tiktok" class="react-icon" />
        </div>
        <div>
          <font-awesome-icon icon="fa-brands fa-youtube" class="react-icon" />
        </div>
        <v-tooltip text="Trở lại danh sách bài viết.">
          <template v-slot:activator="{ props }">
            <div style="margin-top: 12px" v-bind="props">
              <font-awesome-icon
                icon="fa-solid fa-chevron-left"
                class="react-icon"
              />
            </div>
          </template>
        </v-tooltip>
      </div>
      <div class="post-content">
        <ContentHeader :post="post" :getPostDetail="getPostDetail" />
        <PostContentBody />
      </div>
      <div class="post-shortlink">
        <h4
          style="
            font-size: 18px;
            line-height: 1.6;
            font-family: `Merriweather`, serif;
            color: #222;
            font-weight: bold;
          "
        >
          Bài viết mới
        </h4>
        <div style="border-bottom: 1px solid red; width: 12%"></div>
        <MostViewPost
          v-for="(item, index) in post.suggestPost"
          :key="index"
          :item="item"
        />
      </div>
    </div>
  </div>
</template>

<script>
import ContentHeader from "./ContentHeader.vue";
import PostContentBody from "./PostContentBody.vue";
import MostViewPost from "./MostViewPost.vue";
import { mapMutations } from "vuex";
import PostAPI from "../../apis/APIPost/PostAPI";
export default {
  name: "PostMonitor",
  components: { ContentHeader, PostContentBody, MostViewPost },
  data() {
    return {
      post: {},
      id: 0,
    };
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    async getPostDetail() {
      this.setIsLoadedData(true);
      this.id = localStorage.getItem("id");
      const data = await PostAPI.getPostDetail(
        this.$route.params.id,
        this.id ? this.id : -1
      );
      this.post = data.data;
      localStorage.setItem("postData", this.post.content);
      this.setIsLoadedData(false);
    },
  },
  created() {
    this.getPostDetail();
  },
};
</script>

<style lang="css" scoped>
.post-container {
}
.post-container .post-action {
  width: 5%;
  display: flex;
  justify-content: center;
  align-items: center;
  float: left;
  flex-direction: column;
}
.post-container .post-content {
  width: 55%;
  float: left;
}
.post-container .post-action div {
  width: 40px;
  height: 40px;
  display: flex;
  border-radius: 50%;
  justify-content: center;
  align-items: center;
  margin-bottom: 12px;
  color: black;
}

.post-container .post-action div:hover {
  cursor: pointer;
  background-color: #e8ebed;
}
.post-container .post-action .react-icon {
  font-size: 26px;
  color: #93908a;
}
.post-container .post-shortlink {
  width: 38%;
  margin-left: 2%;
  float: left;
}
</style>
