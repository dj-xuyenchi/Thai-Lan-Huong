<template>
  <div>
    <v-row style="margin-top: 12px">
      <v-col cols="2" sm="2" md="2">
        <v-select
          label="Ngôn ngữ"
          :items="listLangueActive"
          hide-details="true"
          variant="outlined"
          v-model="langue"
          density="compact"
          return-object
          item-value="id"
          item-title="langueName"
          @update:modelValue="changeLangue()"
        ></v-select>
      </v-col>
      <v-col cols="4" sm="4" md="4">
        <v-btn
          color="#36ae7c"
          v-bind="props"
          style="width: 140px; margin-left: 12px"
          @click="content = defaultCode"
        >
          <font-awesome-icon
            icon="fa-solid fa-rotate-right"
            color="black"
            style="font-size: 20px; margin-right: 4px"
          />
          Reset Code
        </v-btn>
      </v-col>
    </v-row>
    <v-ace-editor
      v-model:value="content"
      :highlightActiveLine="true"
      :mode="'csharp'"
      :theme="'chrome'"
      :options="option"
      @input="onInput"
      style="height: 60vh; margin-top: 8px"
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
            style="min-width: 100px !important"
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
                  <!-- <v-btn
                    v-if="item.result == 2 || item.result == 3"
                    outlined
                    @click="
                      callTest(item.result == 2 ? 1 : 2, item);
                      showChat = true;
                    "
                  >
                    Giải thích lỗi
                  </v-btn> -->
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
// import HeyGPT from "../../apis/OpenAI";
// import ChatGPT from "./ChatGPT";
import { fixCodeCSharp } from "./CompileOption/CSharp.ts";
import { fixCodeJS, runCode } from "./CompileOption/JS.ts";
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
      langue: null,
      defaultCode: "",
      tab: "option-0",
      listTest: [],
      listLangueActive: [],
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
    codeOk: Object,
    isSupportMultiLangue: Boolean,
    defaultLangue: Object,
    listLangue: [],
    multiLangueDTOs: [],
  },
  mounted() {
    if (this.codeOk.langue) {
      this.content = this.codeOk.codeOk;
      this.langue = this.codeOk.langue;
    } else {
      this.content = this.beginCodeMethod ? this.beginCodeMethod : " ";
      this.langue = this.defaultLangue;
    }
    this.listTest = this.testCase;
    this.defaultCode = this.beginCodeMethod;
    if (this.isSupportMultiLangue) {
      this.listLangueActive = this.listLangue;
    } else {
      this.listLangueActive.push(this.defaultLangue);
    }
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
      this.listTest = this.testCase;
      this.setIsLoadedData(true);
      const token = localStorage.getItem("token");
      var code = "";
      switch (this.langue.id) {
        case 1:
          code = fixCodeCSharp(this.content);
          break;
        case 2:
          code = fixCodeCSharp(this.content);
          break;
        case 3:
          var multi = this.multiLangueDTOs.find((x) => x.langueId == 3);
          code = fixCodeJS(this.content, multi.callTestCode);
          break;
        case 4:
          code = fixCodeJS(this.content);
          break;
        default:
          break;
      }
      const codeRequest = {
        Code: code,
        PracticeLessonId: this.practiceLessonId,
      };
      var data = null;
      switch (this.langue.id) {
        case 1:
          break;
        case 2:
          data = await StudyAPI.tryTestCase(codeRequest, token);
          this.listTest = data.data.testCase;
          this.isOk = true;
          for (var itemCSharp of this.listTest) {
            if (itemCSharp.result != 1) {
              this.isOk = false;
              break;
            }
          }
          break;
        case 3:
          var listResult = [];
          for (const testCase of this.listTest) {
            const result = runCode(code, testCase.input);
            if (result.includes("ERROR###")) {
              listResult.push({
                result: 3,
                runTimeTotal: "Không tính được",
                input: testCase.input,
                output: "Error expected something",
                expectOutput: testCase.expectOutput,
              });
              continue;
            }
            var resultJS = result.split("RESULT###");
            if (resultJS[0] === testCase.expectOutput) {
              listResult.push({
                result: 1,
                runTimeTotal: resultJS[1] + " ms",
                input: testCase.input,
                output: resultJS[0],
                expectOutput: testCase.expectOutput,
              });
            } else {
              listResult.push({
                result: 2,
                runTimeTotal: resultJS[1] + " ms",
                input: testCase.input,
                output: resultJS[0],
                expectOutput: testCase.expectOutput,
              });
            }
          }
          this.listTest = listResult;
          this.isOk = true;
          for (var itemJS of listResult) {
            if (itemJS.result != 1) {
              this.isOk = false;
              break;
            }
          }
          break;
        case 4:
          code = fixCodeJS(this.content);
          break;
        default:
          break;
      }
      this.setIsLoadedData(false);
    },
    changeLangue() {
      if (!this.isSupportMultiLangue) {
        return;
      }
      const newLangue = this.multiLangueDTOs.find(
        (x) => x.langueId == this.langue.id
      );
      this.content = newLangue.beginCodeMethod;
      this.defaultCode = newLangue.beginCodeMethod;
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
        langueId: this.langue.id,
      };
      const token = localStorage.getItem("token");
      const data = await StudyAPI.sendCodeOk(senData, token);
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
::-webkit-scrollbar {
  width: 0.5em;
}
</style>
