<template>
  <div class="post-container">
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
    <div style="margin-left: 14px">
      <div class="post-action">s</div>
      <div class="post-content">
        <ContentHeader />
      </div>
      <div class="post-shortlink">d</div>
    </div>
  </div>
</template>

<script>
import ContentHeader from "./ContentHeader";
export default {
  name: "PostMonitor",
  components: { ContentHeader },
  props: {
    title: String,
  },
};
</script>

<style lang="css" scoped>
.post-container {
}
.post-container .post-action {
  float: left;
  width: 5%;
}
.post-container .post-content {
  width: 55%;
  float: left;
}
.post-container .post-shortlink {
  width: 40%;
  float: left;
}
</style>
