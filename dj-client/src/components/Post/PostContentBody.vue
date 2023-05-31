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
  props: {
    dataHTML: String,
  },
  mounted() {
    const md = new MarkdownIt();
    const htmlContent = md.render(this.dataHTML);
    this.renderedHTML = htmlContent;
    const listImg = document.querySelectorAll("img");
    for (var item of listImg) {
      item.classList.add("fixImg");
    }
  },
};
</script>

<style lang="css" scoped></style>
