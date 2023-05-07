<template>
  <div>
    <v-ace-editor
      v-model:value="content"
      :highlightActiveLine="true"
      :mode="'csharp'"
      :theme="'chrome'"
      :options="option"
      @input="onInput"
      style="height: 60vh"
    />
    <div style="margin-left: 45%; margin-top: 12px">
      <v-card style="margin-bottom: 12px">
        <v-toolbar color="#1b749b">
          <v-toolbar-title>Test Case</v-toolbar-title>
        </v-toolbar>
        <div class="d-flex flex-row">
          <v-tabs
            v-model="tab"
            direction="vertical"
            color="primary"
            style="width: 10% !important"
          >
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
          <v-window v-model="tab" style="width: 90% !important">
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
        color="#2c31cf"
        v-bind="props"
        style="width: 120px"
        @click="tryTestCase()"
      >
        <font-awesome-icon
          icon="fa-solid fa-caret-right"
          color="white"
          style="font-size: 20px; margin-right: 4px"
        />
        <span style="color: white"> Chạy thử </span>
      </v-btn>
      <v-btn
        color="#36ae7c"
        v-bind="props"
        style="width: 120px; margin-left: 12px"
        @click="sendCodeOk()"
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
        style="width: 128px; margin-left: 12px"
        @click="content = beginCodeMethod"
      >
        <font-awesome-icon
          icon="fa-solid fa-rotate-right"
          color="black"
          style="font-size: 20px; margin-right: 4px"
        />
        Reset Code
      </v-btn>
      <!-- <v-btn
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
      </v-btn> -->
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
      <!-- <div style="margin-left: 12px">
        <ChatGPT :listChat="listGPTResponse" />
      </div> -->
    </v-card>
    <v-snackbar v-model="snackbarNotOk" multi-line>
      {{ snackBarContent }}
      <template v-slot:actions>
        <v-btn color="red" variant="text" @click="snackbarNotOk = false">
          Đóng
        </v-btn>
      </template>
    </v-snackbar>
    <v-snackbar v-model="snackbarOk" multi-line>
      {{ snackBarContent }}
      <template v-slot:actions>
        <v-btn color="green" variant="text" @click="snackbarOk = false">
          Đóng
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
import "brace/mode/csharp";
import "brace/theme/chrome";
import "ace-builds/src-noconflict/mode-csharp";
import "ace-builds/src-noconflict/theme-chrome";
export default {
  name: "CodeEditor",
  components: {
    VAceEditor,
    //  ChatGPT
  },
  data() {
    return {
      content: "",
      tab: "option-0",
      listTest: [],
      listGPTResponse: [],
      showChat: false,
      thinking: false,
      snackbarNotOk: false,
      snackBarContent: "",
      snackbarOk: false,
      isOk: false,
      option: {
        theme: "ace/theme/chrome",
        mode: "ace/mode/csharp",
        fontSize: "16px",
        showGutter: true,
        wrap: true,
        highlightActiveLine: true,
        enableBasicAutocompletion: true,
        enableLiveAutocompletion: true,
        enableSnippets: true,
      },
    };
  },
  props: {
    testCase: [],
    beginCodeMethod: String,
    practiceLessonId: Number,
    codeOk: String,
  },
  mounted() {
    if (this.codeOk) {
      this.content = this.codeOk;
    } else {
      this.content = this.beginCodeMethod ? this.beginCodeMethod : " ";
    }
    this.listTest = this.testCase;
  },
  setup(props) {
    return { props };
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    async tryTestCase() {
      if (this.content.trim().length === 0) {
        this.snackBarContent = "Bạn chưa code gì hết!";
        this.snackbarNotOk = true;
        return;
      }
      this.setIsLoadedData(true);
      const token = localStorage.getItem("token");
      var code = this.fixCode(this.content);
      const codeRequest = {
        Code: code,
        PracticeLessonId: this.practiceLessonId,
      };
      const data = await StudyAPI.tryTestCase(codeRequest, token);
      this.listTest = data.data.testCase;
      this.isOk = true;
      for (var item of this.listTest) {
        if (item.result != 1) {
          this.isOk = false;
          break;
        }
      }
      this.setIsLoadedData(false);
    },
    fixCode(code) {
      code = code
        .replaceAll("\n", "")
        .replaceAll("\r", "")
        .replaceAll("\t", "");
      while (code.includes("do ")) {
        code = code.replace("do ", "do");
      }
      while (code.includes(") ")) {
        code = code.replace(") ", ")");
      }
      code = code.replaceAll(
        "do{",
        'do{timeSpan = stopwatch.Elapsed;if (timeSpan.TotalMilliseconds > 3000) { Console.WriteLine("ERROR###");break;}'
      );
      for (var i = 0; i < code.length - 5; i++) {
        if (
          code[i] == "w" &&
          code[i + 1] == "h" &&
          code[i + 2] == "i" &&
          code[i + 3] == "l" &&
          code[i + 4] == "e"
        ) {
          for (var j = i + 5; j < code.length - 5; j++) {
            if (code[j] == ")" && code[j + 1] == "{") {
              code =
                code.substring(0, j + 2) +
                `timeSpan = stopwatch.Elapsed;if (timeSpan.TotalMilliseconds > 3000) { Console.WriteLine("ERROR###");break;}` +
                code.substring(j + 2);
              break;
            }
          }
        }
      }
      for (var e = 0; e < code.length - 3; e++) {
        if (code[e] == "f" && code[e + 1] == "o" && code[e + 2] == "r") {
          for (var r = e + 3; r < code.length - 3; r++) {
            if (code[r] == ")" && code[r + 1] == "{") {
              code =
                code.substring(0, r + 2) +
                `timeSpan = stopwatch.Elapsed;if (timeSpan.TotalMilliseconds > 3000) { Console.WriteLine("ERROR###");break;}` +
                code.substring(r + 2);
              break;
            }
          }
        }
      }
      for (var f = 0; f < code.length - 6; f++) {
        if (
          code[f] == "f" &&
          code[f + 1] == "o" &&
          code[f + 2] == "r" &&
          code[f + 3] == "e" &&
          code[f + 4] == "a" &&
          code[f + 5] == "c" &&
          code[f + 6] == "h"
        ) {
          for (var g = i + 6; g < code.length - 6; g++) {
            if (code[g] == ")" && code[g + 1] == "{") {
              code =
                code.substring(0, g + 2) +
                `timeSpan = stopwatch.Elapsed;if (timeSpan.TotalMilliseconds > 3000) { Console.WriteLine("ERROR###");break;}` +
                code.substring(g + 2);
              break;
            }
          }
        }
      }
      return code;
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
          content.output
        );
        this.listGPTResponse.push(respon.choices[0].message.content);
        this.thinking = false;
      }
    },
    onInput(code) {
      this.$emit("input", code);
    },
    async sendCodeOk() {
      this.setIsLoadedData(true);
      if (!this.isOk) {
        this.snackBarContent = "Chưa hoàn thành đủ Test Case!";
        this.snackbarNotOk = true;
        this.setIsLoadedData(false);
        return;
      }
      const userId = localStorage.getItem("id");
      const senData = {
        UserId: userId,
        LessonId: this.$route.params.id,
        ChapterId: this.$route.params.idChapter,
        Code: this.content,
      };
      const token = localStorage.getItem("token");
      const data = await StudyAPI.sendCodeOk(senData, token);
      console.log(data);
      if (data.data == 1) {
        this.snackBarContent = "Thành công! Đã mở khóa bài học mới";
        this.snackbarOk = true;
      }
      if (data.data == 5) {
        this.snackBarContent = "Thành công!";
        this.snackbarOk = true;
      }
      this.setIsLoadedData(false);
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
