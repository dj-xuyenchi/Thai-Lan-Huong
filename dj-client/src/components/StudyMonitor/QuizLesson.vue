<template>
  <div class="quiz-container">
    <div
      style="width: 40%; float: left; min-height: 240px; display: inline-block"
    >
      <h4 style="font-size: 24px; font-family: inherit; font-weight: 700">
        {{ data.question }}
      </h4>
      <v-radio-group>
        <v-radio color="primary" :label="data.answerA" value="1"></v-radio>
        <v-radio color="primary" :label="data.answerB" value="2"></v-radio>
        <v-radio color="primary" :label="data.answerC" value="3"></v-radio>
        <v-radio color="primary" :label="data.answerD" value="4"></v-radio>
      </v-radio-group>
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
      <v-btn
        color="#36ae7c"
        v-bind="props"
        style="width: 120px; margin-left: 12px"
        @click="showChat = !showChat"
      >
        <font-awesome-icon
          icon="fa-solid fa-user-doctor"
          color="black"
          style="font-size: 20px; margin-right: 4px"
        />
        ChatGPT
      </v-btn>
    </div>
    <v-card
      style="
        position: absolute;
        bottom: 5vh;
        left: 12px;
        width: 600px;
        height: 600px;
        overflow: scroll;
        z-index: 1;
      "
      v-if="showChat"
    >
      <v-toolbar color="rgba(0, 0, 0, 0)" theme="dark">
        <v-toolbar-title class="text-h6" style="color: green">
          ChatGPT
        </v-toolbar-title>
        <v-progress-circular
          :size="20"
          color="primary"
          indeterminate
          v-if="thinking"
        ></v-progress-circular>
        <span v-if="thinking" style="color: black; margin-left: 12px"
          >Đang phân tích vấn đề của bạn</span
        >
        <template v-slot:append>
          <v-btn
            icon="mdi-close"
            style="color: black"
            @click="showChat = !showChat"
          ></v-btn>
        </template>
      </v-toolbar>
      <div style="margin-left: 12px">
        <ChatGPT :listChat="listGPTResponse" />
      </div>
    </v-card>
  </div>
</template>

<script>
import HeyGPT from "../../apis/OpenAI";
import ChatGPT from "./ChatGPT";
export default {
  name: "QuizLesson",
  components: { ChatGPT },
  data: () => ({
    question: "",
    answer: 0,
    openai: true,
    showChat: false,
    thinking: false,
    listGPTResponse: ["asa", "xin chào mình có thể giúp gì cho bạn."],
  }),
  props: {
    data: Object,
  },
  methods: {
    async callTest(option, content) {
      if (option == 1) {
        this.thinking = true;
        const respon = await HeyGPT.sayToGPTWrong(
          this.content,
          content.expectOutput,
          content.output
        );
        this.listGPTResponse.push(respon.choices[0].message.content);
        this.thinking = false;
      }
      if (option == 2) {
        this.thinking = true;
        const respon = await HeyGPT.sayToGPTExeption(
          this.content,
          content.expectOutput,
          content.output
        );
        this.listGPTResponse.push(respon.choices[0].message.content);
        this.thinking = false;
      }
    },
  },
};
</script>

<style lang="css" scoped>
.quiz-container {
  margin-top: 60px;
  width: 90%;
  margin-left: 5%;
}
</style>
