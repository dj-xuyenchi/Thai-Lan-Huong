<template>
  <div class="chat-container">
    <div v-for="(item, index) in listChat" :key="index">
      <div class="chat-item">
        <span>{{ item }}</span>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "ChatGPT",
  props: {
    listChat: [],
  },
};
</script>

<style lang="css" scoped>
.chat-container {
  width: 400px;
  display: inline-block;
}
.chat-container .chat-item {
  border-top-left-radius: 5px;
  border: 1px solid rgb(218, 220, 224);
  border-top-right-radius: 5px;
  border-bottom-right-radius: 5px;
  min-height: 30px;
  min-width: 80px;
  display: inline-flex;
  margin-top: 4px;
  margin-bottom: 4px;
  align-items: center;
  padding-left: 8px;
  padding-bottom: 4px;
  padding-right: 8px;
  padding-top: 4px;
}
</style>
