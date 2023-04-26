<template>
  <div class="quiz-container">
    <div style="width: 40%; float: left">
      <h4 style="font-size: 24px; font-family: inherit; font-weight: 700">
        {{ question }}
      </h4>
      <v-radio-group>
        <v-radio color="primary" :label="a" value="1"></v-radio>
        <v-radio color="primary" :label="b" value="2"></v-radio>
        <v-radio color="primary" :label="c" value="3"></v-radio>
        <v-radio color="primary" :label="d" value="4"></v-radio>
      </v-radio-group>
    </div>
    <div style="width: 60%; float: left" v-if="openai">
      <ChatGPT :listChat="listChat" />
    </div>
    <div style="width: 100%">
      <v-btn
        color="#36ae7c"
        v-bind="props"
        style="width: 120px"
        @click="callTest()"
      >
        <font-awesome-icon
          icon="fa-solid fa-paper-plane"
          color="black"
          style="font-size: 20px; margin-right: 4px"
        />
        Trả lời
      </v-btn>
    </div>
  </div>
</template>

<script>
import ChatGPT from "./ChatGPT";
export default {
  name: "QuizLesson",
  components: { ChatGPT },
  data: () => ({
    a: "",
    b: "",
    c: "",
    d: "",
    question: "",
    answer: 0,
    openai: true,
    listChat: ["asa", "xin chào mình có thể giúp gì cho bạn."],
  }),
};
</script>

<style lang="css" scoped>
.quiz-container {
  margin-top: 60px;
  width: 90%;
  margin-left: 5%;
}
</style>
