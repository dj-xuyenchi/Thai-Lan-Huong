<template>
  <div style="width: 60%; margin-left: 5%">
    <div style="white-space: pre-line" v-html="renderedHTML"></div>
  </div>
</template>

<script>
import MarkdownIt from "markdown-it";

import VMdEditor from "@kangc/v-md-editor";
import UserAPI from "../../apis/APIUser/UserAPI.ts";
export default {
  data() {
    return {
      renderedHTML: "",
    };
  },
  methods: {
    async getWaitPost() {
      const data = await UserAPI.getWaitPost(
        localStorage.getItem("id"),
        localStorage.getItem("token")
      );
      if (data.data == null) {
        return;
      }
      this.renderedHTML = data.data;
      const md = new MarkdownIt();
      const htmlContent = md.render(this.renderedHTML);
      this.renderedHTML = htmlContent;
    },
  },
  created() {
    this.getWaitPost();
  },
};
</script>

<style lang="css" scoped></style>
