<template>
  <div class="sentenceitem-container">
    <span>{{ sentence }}</span>
  </div>
</template>

<script>
export default {
  name: "SentenceItem",
  props: {
    sentence: String,
  },
};
</script>

<style lang="css" scoped>
.sentenceitem-container {
  margin-bottom: 15px;
}
.sentenceitem-container span {
  font-size: 18px;
  line-height: 160%;
  font-weight: 400;
  font-family: Arial;
}
</style>
