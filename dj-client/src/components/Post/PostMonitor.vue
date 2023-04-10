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
        <ContentHeader />
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
          Xem nhiều
        </h4>
        <div style="border-bottom: 1px solid red; width: 12%"></div>
        <MostViewPost />
        <MostViewPost />
        <MostViewPost />
        <MostViewPost />
        <MostViewPost />
      </div>
    </div>
  </div>
</template>

<script>
import ContentHeader from "./ContentHeader.vue";
import PostContentBody from "./PostContentBody.vue";
import MostViewPost from "./MostViewPost.vue";
export default {
  name: "PostMonitor",
  components: { ContentHeader, PostContentBody, MostViewPost },
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
