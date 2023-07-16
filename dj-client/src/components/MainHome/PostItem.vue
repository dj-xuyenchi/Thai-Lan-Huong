<template>
  <div class="post-item">
    <v-hover v-slot="{ isHovering, props }">
      <v-card
        ref="gg"
        class="mx-auto rounded-xl item-hover"
        v-bind="props"
        variant="none"
        width="380px"
        height="240px"
      >
        <img :src="postImg" alt="" />
        <v-overlay
          :model-value="isHovering"
          contained
          scrim="#036358"
          class="align-center justify-center"
        >
          <router-link
            :to="`/home/post/` + id + `/` + fixUrl(postTitle)"
            style="text-decoration: none"
          >
            <v-btn variant="flat rounded-xl">Xem bài viết</v-btn>
          </router-link>
        </v-overlay>
      </v-card>
    </v-hover>
    <div class="post-detail">
      <div style="width: 100%">
        <h5
          style="
            color: #242424;
            font-size: 16px;
            font-weight: 500;
            font: system-ui, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif,
              'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol';
          "
        >
          {{ titleFix }}
        </h5>
      </div>
      <div class="author-info">
        <img :src="authorAvatar" alt="Hình ảnh" v-if="authorAvatar != ` `" />
        <span>{{ postAuthor }}</span>
        <img
          v-if="isKYC"
          :src="require('../../assets/kyc.png')"
          alt="Hình ảnh"
          class="kyc"
        />
        <div class="react-info">
          <font-awesome-icon icon="fa-solid fa-heart" class="react-icon" />
          <span style="margin-right: 18px">{{ likeCount }}</span>
          <font-awesome-icon icon="fa-regular fa-comment" class="react-icon" />
          <span>{{ cmtCount }}</span>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "CourseItem",
  data: () => ({
    titleFix: "",
    overlay: false,
  }),
  props: {
    postImg: String,
    postTitle: String,
    authorAvatar: String,
    postAuthor: String,
    likeCount: String,
    cmtCount: String,
    isKYC: Boolean,
    id: Number,
  },
  mounted() {
    if (this.postTitle.length > 40) {
      this.titleFix = this.postTitle.substring(0, 40) + "...";
    } else {
      this.titleFix = this.postTitle;
    }
  },
  methods: {
    fixUrl(input) {
      input = input.replaceAll(" ", "-").toLowerCase();
      while (input.includes("--")) {
        input = input.replace("--", "-");
      }
      input = input.replaceAll("đ", "d");
      return input.normalize("NFD").replace(/[\u0300-\u036f]/g, "");
    },
  },
};
</script>

<style lang="css" scoped>
.post-item {
  margin-top: 14px;
  width: 380px;
  height: 240px;
  margin-bottom: 36px;
  padding: 0 14px 0 14px;
  margin-left: 1%;
  margin-bottom: 80px;
}

.post-item img {
  width: 380px;
  height: 240px;
}
.post-item .post-detail {
  width: 100%;
  margin-top: 14px;
}
.item-hover:hover {
  cursor: pointer;
}
.post-detail span:hover {
  cursor: pointer;
}
.author-info {
  width: 100%;
  margin-top: 8px;
  display: flex;
  align-items: center;
  position: relative;
}
.author-info .kyc {
  height: 16px;
  width: 16px;
  margin-left: -4px;
}
.author-info img {
  width: 32px;
  height: 32px;
  border-radius: 50%;
}
.author-info span {
  margin: 0 8px 0 8px;
  color: #242424;
  font-size: 14px;
  font-weight: 500;
  font: system-ui, "Segoe UI", Roboto, Helvetica, Arial, sans-serif,
    "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol";
}
.react-info {
  display: flex;
  position: absolute;
  width: 100%;
  justify-content: flex-end;
  height: 32px;
  align-items: center;
}

.react-info .react-icon {
  font-size: 16px;
}
@media screen and (max-width: 739px) {
  .post-item {
    height: 260px;
  }
  .post-item img {
    height: 260px;
  }
  .author-info {
    width: 100%;
    margin-top: 8px;
    display: flex;
    align-items: center;
    position: relative;
  }
  .author-info .kyc {
    height: 16px;
    width: 16px;
    margin-left: -4px;
  }
  .author-info img {
    width: 32px;
    height: 32px;
    border-radius: 50%;
  }
  .author-info span {
    margin: 0 8px 0 8px;
    color: #242424;
    font-size: 14px;
    font-weight: 500;
    font: system-ui, "Segoe UI", Roboto, Helvetica, Arial, sans-serif,
      "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol";
  }
  .react-info {
    display: flex;
    position: absolute;
    width: 100%;
    justify-content: flex-end;
    height: 32px;
    align-items: center;
  }
}
@media screen and (max-width: 1023px) and (min-width: 740px) {
  .post-item {
    height: 260px;
  }
  .post-item img {
    height: 260px;
  }
  .author-info {
    width: 100%;
    margin-top: 8px;
    display: flex;
    align-items: center;
    position: relative;
  }
  .author-info .kyc {
    height: 16px;
    width: 16px;
    margin-left: -4px;
  }
  .author-info img {
    width: 32px;
    height: 32px;
    border-radius: 50%;
  }
  .author-info span {
    margin: 0 8px 0 8px;
    color: #242424;
    font-size: 14px;
    font-weight: 500;
    font: system-ui, "Segoe UI", Roboto, Helvetica, Arial, sans-serif,
      "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol";
  }
  .react-info {
    display: flex;
    position: absolute;
    width: 100%;
    justify-content: flex-end;
    height: 32px;
    align-items: center;
  }
}
</style>
