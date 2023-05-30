<template>
  <div class="user-create-post">
    <div style="margin-bottom: 12px">
      <span
        style="
          color: #242424;
          font-size: 24px;
          font-weight: 900;
          padding-left: 14px;
          font: system-ui, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif,
            'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol';
        "
        >Viết bài
      </span>
    </div>
    <v-btn
      @click="createPost()"
      variant="text"
      style="margin-bottom: 8px"
      color="red"
    >
      Tạo
    </v-btn>
    <v-md-editor v-model="content" height="80vh"></v-md-editor>
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
import { mapMutations } from "vuex";
import { mapGetters } from "vuex";
import UserAPI from "../../apis/APIUser/UserAPI.ts";
import VMdEditor from "@kangc/v-md-editor";
export default {
  name: "UserCreatePost",
  components: {},
  data() {
    return {
      dialog: false,
      btnLoading: false,
      text: "",
      snackbar: false,
      postTitle: "",
      content: "",
      rules: [
        (value) => {
          if (value) return true;
          return "Không được để trống!";
        },
      ],
    };
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    async createPost() {
      if (this.content.length == 0) {
        this.text = "Không được để trống nội dung bài viết!";
        this.snackbar = true;
        return;
      }
      this.setIsLoadedData(true);
      const data = await UserAPI.createWaitPost(
        { Data: this.content, UserId: localStorage.getItem("id") },
        localStorage.getItem("token")
      );
      if (data.data == 1) {
        this.$router.push({ path: `/home/review` });
        this.setIsLoadedData(false);
        return;
      }
      if (data.data == 4) {
        this.text = "Không tồn tại bài đăng";
        this.snackbar = true;
        this.setIsLoadedData(false);
        return;
      }
      this.setIsLoadedData(false);
    },
  },
  created() {
    const data = localStorage.getItem("post_data");
    if (data) {
      this.content = data;
    }
  },
};
</script>

<style lang="css" scoped>
.user-create-post {
  min-height: 80vh;
}
@media screen and (max-width: 739px) {
  .require-profit .require-profit-detail {
    width: 100% !important;
  }
  .course-detail-container .course-detail-right {
    display: none !important;
  }
  .course-detail-container .course-detail-left {
    width: 100% !important;
  }
}
@media screen and (max-width: 1360px) and (min-width: 740px) {
  .require-profit .require-profit-detail {
    width: 100% !important;
  }
  .course-detail-container .course-detail-left {
    width: 100% !important;
  }
  .course-detail-container .course-detail-right {
    display: none !important;
  }
}
</style>
