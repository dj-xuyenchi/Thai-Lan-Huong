<template>
  <div class="video-container">
    <iframe
      width="100%"
      height="100%"
      src="https://www.youtube.com/embed/TGjhsX8A7OI"
      title="YouTube video player"
      frameborder="0"
      allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share"
      allowfullscreen
    ></iframe>
  </div>
</template>

<script>
export default {
  name: "VideoLesson",
  props: {
    videoPath: String,
  },
};
</script>

<style lang="css" scoped></style>
