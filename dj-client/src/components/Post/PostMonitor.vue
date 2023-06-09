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
        <div style="white-space: pre-line" v-html="renderedHTML"></div>
        <FooterPost :handleDialog="handleDialog" />
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
  <div class="text-center">
    <v-dialog v-model="dialog" activator="parent" width="800">
      <v-card>
        <v-card-text>
          Bạn cảm thấy bình luận này không an toàn hoặc không phù hợp?
          <v-col cols="4" sm="4" md="4">
            <v-select
              v-model="type"
              label="Loại vi phạm"
              :items="listDenounce"
              item-title="denounceName"
              persistent-hint
              return-object
              item-value="id"
              variant="outlined"
            ></v-select>
          </v-col>
          <v-col cols="12" sm="12" md="12">
            <v-textarea
              v-model="note"
              density="compact"
              label="Ghi chú của bạn"
              hint="Ghi chú của bạn về bình luận"
              variant="outlined"
              max-rows="5"
            ></v-textarea>
          </v-col>
        </v-card-text>
        <v-spacer></v-spacer>
        <v-btn color="blue-darken-1" variant="text" @click="createDenounce()">
          Gửi báo cáo
        </v-btn>
        <v-btn color="blue-darken-1" variant="text" @click="dialog = false">
          Hủy
        </v-btn>
      </v-card>
    </v-dialog>
  </div>
</template>

<script>
import ContentHeader from "./ContentHeader.vue";
import FooterPost from "./FooterPost.vue";
import MostViewPost from "./MostViewPost.vue";
import { mapMutations } from "vuex";
import PostAPI from "../../apis/APIPost/PostAPI";
import { SeoTool } from "../../plugins/seometa.ts";
import MarkdownIt from "markdown-it";
import StudyAPI from "../../apis/APIStudy/StudyAPI.ts";
export default {
  name: "PostMonitor",
  components: { ContentHeader, FooterPost, MostViewPost },
  data() {
    return {
      post: {},
      dialog: false,
      renderedHTML: "",
      cmtId: 0,
    };
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    handleDialog(id) {
      this.dialog = true;
      this.cmtId = id;
    },
    async getPostDetail() {
      this.setIsLoadedData(true);
      const id = localStorage.getItem("id");
      const data = await PostAPI.getPostDetail(
        this.$route.params.id,
        this.id ? this.id : -1
      );
      this.post = data.data;
      const md = new MarkdownIt();
      var htmlContent = md.render(this.post.content);
      htmlContent = htmlContent.replaceAll(
        "<img ",
        "<img style=max-width:100% "
      );
      this.renderedHTML = htmlContent;
      this.setIsLoadedData(false);
    },
    async getDenounce(token) {
      const data = await StudyAPI.getDenounce(token);
      this.listDenounce = data;
      this.type = data[0];
    },
  },
  created() {
    this.getPostDetail();
    SeoTool(
      this.post.title,
      this.post.des,
      this.post.imgLink,
      "https://dj-xuyenchi.edu.vn/#/home/post/" +
        this.post.id +
        "/" +
        this.$route.params.name
    );
    if (localStorage.getItem("id")) {
      this.getDenounce(localStorage.getItem("token"));
    }
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
