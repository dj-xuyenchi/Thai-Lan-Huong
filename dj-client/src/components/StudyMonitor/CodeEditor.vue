<template>
  <div>
    <v-ace-editor
      v-model:value="content"
      @init="editorInit"
      theme="Terminal"
      minLines:30
      mode="html"
      style="
        background-color: #1e1f26;
        color: white;
        font-size: 16px;
        height: 60vh;
        caret-color: white;
      "
    />
    <div style="margin-left: 45%; margin-top: 12px">
      <v-card style="margin-bottom: 12px">
        <v-toolbar color="#1b749b">
          <v-toolbar-title>Test Case</v-toolbar-title>
        </v-toolbar>
        <div class="d-flex flex-row">
          <v-tabs v-model="tab" direction="vertical" color="primary">
            <v-tab
              v-for="(item, index) in listTest"
              :key="index"
              :value="`option-` + index"
              :disabled="item.lockTestCase"
            >
              <span
                style="font-weight: 900; color: black"
                v-if="item.result == 4"
              >
                <v-icon start v-if="item.lockTestCase == false">
                  mdi-book
                </v-icon>
                <v-icon start v-if="item.lockTestCase == true">
                  mdi-lock
                </v-icon>
              </span>
              <span
                style="font-weight: 900; color: red"
                v-if="item.result == 3"
              >
                <v-icon start v-if="item.lockTestCase == false">
                  mdi-book
                </v-icon>
                <v-icon start v-if="item.lockTestCase == true">
                  mdi-lock
                </v-icon>
              </span>
              <span
                style="font-weight: 900; color: red"
                v-if="item.result == 2"
              >
                <v-icon start v-if="item.lockTestCase == false">
                  mdi-book
                </v-icon>
                <v-icon start v-if="item.lockTestCase == true">
                  mdi-lock
                </v-icon>
              </span>
              <span
                style="font-weight: 900; color: green"
                v-if="item.result == 1"
              >
                <v-icon start v-if="item.lockTestCase == false">
                  mdi-book
                </v-icon>
                <v-icon start v-if="item.lockTestCase == true">
                  mdi-lock
                </v-icon>
              </span>
              <span
                style="font-weight: 900; color: black"
                v-if="item.result == 4"
              >
                Case {{ index + 1 }}</span
              >
              <span
                style="font-weight: 900; color: red"
                v-if="item.result == 3"
              >
                Case {{ index + 1 }}</span
              >
              <span
                style="font-weight: 900; color: red"
                v-if="item.result == 2"
              >
                Case {{ index + 1 }}</span
              >
              <span
                style="font-weight: 900; color: green"
                v-if="item.result == 1"
              >
                Case {{ index + 1 }}</span
              >
            </v-tab>
          </v-tabs>
          <v-window v-model="tab">
            <v-window-item
              v-for="(item, index) in listTest"
              :key="index"
              :value="`option-` + index"
            >
              <v-card flat>
                <v-card-text>
                  <div class="test-case-info">
                    <span
                      >Đầu vào:
                      <span class="test-case-result">{{
                        item.input
                      }}</span></span
                    >
                  </div>
                  <div class="test-case-info">
                    <span
                      >Đầu ra thực tế:
                      <span class="test-case-result">{{
                        item.output
                      }}</span></span
                    >
                  </div>
                  <div class="test-case-info">
                    <span
                      >Đầu ra mong muốn:
                      <span class="test-case-result">{{
                        item.expectOutput
                      }}</span></span
                    >
                  </div>
                  <div class="test-case-info">
                    <span
                      >Thời gian chạy:
                      <span class="test-case-result">{{
                        item.runTimeTotal
                      }}</span></span
                    >
                  </div>
                  <v-btn
                    v-if="item.result == 2 || item.result == 3"
                    outlined
                    @click="
                      callTest(item.result == 2 ? 1 : 2, item);
                      showChat = true;
                    "
                  >
                    Giải thích lỗi
                  </v-btn>
                </v-card-text>
              </v-card>
            </v-window-item>
          </v-window>
        </div>
      </v-card>
      <v-btn
        color="#1b749b"
        v-bind="props"
        style="width: 120px"
        @click="tryTestCase()"
      >
        <font-awesome-icon
          icon="fa-solid fa-caret-right"
          color="black"
          style="font-size: 20px; margin-right: 4px"
        />
        Chạy thử
      </v-btn>
      <v-btn
        color="#36ae7c"
        v-bind="props"
        style="width: 120px; margin-left: 12px"
        @click="callTest()"
      >
        <font-awesome-icon
          icon="fa-solid fa-floppy-disk"
          color="black"
          style="font-size: 20px; margin-right: 4px"
        />
        Nộp bài
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
    <v-snackbar v-model="snackbar" multi-line>
      Bạn chưa code gì hết!
      <template v-slot:actions>
        <v-btn color="red" variant="text" @click="snackbar = false">
          Close
        </v-btn>
      </template>
    </v-snackbar>
  </div>
</template>

<script>
import { VAceEditor } from "vue3-ace-editor";
import StudyAPI from "../../apis/APIStudy/StudyAPI.ts";
import HeyGPT from "../../apis/OpenAI";
import ChatGPT from "./ChatGPT";
import { mapMutations } from "vuex";
export default {
  name: "CodeEditor",
  components: { VAceEditor, ChatGPT },
  data() {
    return {
      content: "",
      tab: "option-0",
      listTest: [],
      listGPTResponse: [],
      showChat: false,
      thinking: false,
      snackbar: false,
    };
  },
  props: {
    testCase: [],
    beginCodeMethod: String,
    practiceLessonId: Number,
  },
  mounted() {
    this.content = this.beginCodeMethod ? " " : " ";
    this.listTest = this.testCase;
  },
  setup(props) {
    return { props };
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    async tryTestCase() {
      if (this.content.trim().length === 0) {
        this.snackbar = true;
        return;
      }
      this.setIsLoadedData(true);
      const token = localStorage.getItem("token");
      const codeRequest = {
        Code: this.content,
        PracticeLessonId: this.practiceLessonId,
      };
      const data = await StudyAPI.tryTestCase(codeRequest, token);
      this.listTest = data.data.testCase;
      this.setIsLoadedData(false);
    },
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
.test-case-info {
  font-size: 16px;
  font-weight: 600;
  padding: 4px 4px 4px 4px;
}
.test-case-info .test-case-result {
  font-weight: 400;
}
</style>
