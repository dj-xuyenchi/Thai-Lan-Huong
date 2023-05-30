<template>
  <div class="content-body-container">
    <div style="white-space: pre-line" v-html="renderedHTML"></div>
    <FooterPost />
  </div>
</template>

<script>
import FooterPost from "./FooterPost.vue";

import MarkdownIt from "markdown-it";
export default {
  name: "PostContentBody",
  components: { FooterPost },
  data() {
    return {
      renderedHTML: "",
    };
  },
  created() {
    const md = new MarkdownIt();
    const htmlContent = md.render(localStorage.getItem("postData"));
    this.renderedHTML = htmlContent;
  },
};
</script>

<style lang="css" scoped>
.content-body-container img {
  max-width: 600px !important;
}
</style>
