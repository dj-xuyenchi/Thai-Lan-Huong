<template>
  <div class="imageitem-container">
    <img
      src="https://icdn.dantri.com.vn/thumb_w/640/2021/03/14/hot-girl-9-x-dep-goi-camdocx-1615737535134.jpeg"
      alt="Hình ảnh"
    />
    <span>{{ imageTitle }}</span>
  </div>
</template>

<script>
export default {
  name: "ImageItem",
  props: {
    imageTitle: String,
    imageData: String,
  },
};
</script>

<style lang="css" scoped>
.imageitem-container {
  display: flex;
  justify-content: center;
  flex-direction: column;
  align-items: center;
  margin: 12px 0 12px 0;
}
.imageitem-container img {
  height: 600px;
  margin-bottom: 12px;
}
</style>
