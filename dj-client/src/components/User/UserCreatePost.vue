<template>
  <div class="user-craete-post">
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
  </div>
</template>

<script>
import { mapMutations } from "vuex";
import { mapGetters } from "vuex";

import VMdEditor from "@kangc/v-md-editor";
export default {
  name: "UserCreatePost",
  components: {},
  data() {
    return {
      dialog: false,
      btnLoading: false,
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
  computed: {},
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    async createPost() {
      this.$router.push({ path: "/home/create-post/review" });
    },
  },
};
</script>

<style lang="css" scoped>
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
