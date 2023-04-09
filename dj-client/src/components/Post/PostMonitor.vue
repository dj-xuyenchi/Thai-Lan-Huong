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
        >{{ now }}</span
      >
    </div>
    <div style="margin-left: 14px; margin-top: 20px">
      <div class="post-action">s</div>
      <div class="post-content">
        <ContentHeader />
        <PostContentBody />
      </div>
      <div class="post-shortlink">d</div>
    </div>
  </div>
</template>

<script>
import ContentHeader from "./ContentHeader.vue";
import PostContentBody from "./PostContentBody.vue";
export default {
  name: "PostMonitor",
  components: { ContentHeader, PostContentBody },
  props: {
    title: String,
  },
  data() {
    return {
      now: "",
    };
  },
  created() {
    const now = new Date();
    switch (now.getDay()) {
      case 0:
        this.now = "Chủ nhật, ";
        break;
      case 1:
        this.now = "Thứ hai, ";
        break;
      case 2:
        this.now = "Thứ ba, ";
        break;
      case 3:
        this.now = "Thứ tư, ";
        break;
      case 4:
        this.now = "Thứ năm, ";
        break;
      case 5:
        this.now = "Thứ sáu, ";
        break;
      case 6:
        this.now = "Thứ bảy, ";
        break;
      default:
        break;
    }
    this.now =
      this.now +
      now.getDate() +
      "/" +
      Number(now.getMonth() + 1) +
      "/" +
      now.getFullYear() +
      ", " +
      now.getHours() +
      ":" +
      now.getMinutes() +
      "  (GMT+7)";
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
