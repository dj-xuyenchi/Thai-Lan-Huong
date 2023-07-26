<template>
  <div class="code-home">
    <h4
      style="
        color: #242424;
        font-size: 24px;
        font-weight: 900;
        margin-bottom: 12px;
        padding-left: 14px;
        font: system-ui, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif,
          'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol';
      "
    >
      Học lập trình trực tuyến thực hành với các bài tập test case!
    </h4>
    <v-col style="width: 160px">
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
    <v-btn variant="text" color="green" @click="tryCode"> Run </v-btn>
    <v-btn variant="text" color="blue" @click="changeLangue">
      Reset Code
    </v-btn>
    <div style="width: 100%">
      <v-ace-editor
        v-model:value="content"
        :highlightActiveLine="true"
        :mode="'csharp'"
        :theme="'chrome'"
        :options="option"
        @input="onInput"
        style="
          height: 400px;
          margin-top: 24px;
          width: 40vw;
          float: left;
          z-index: 0;
        "
      />
      <div style="float: left; width: 50vw; height: 400px">
        <v-textarea
          variant="outlined"
          :loading="loading"
          readonly
          :style="
            result.error == 0
              ? `color:black`
              : result.error == 1
              ? `color:green`
              : `color:red`
          "
          style="width: 90%; margin-left: 12px"
          rows="15"
          v-model="result.result"
        ></v-textarea>
      </div>
    </div>
  </div>
</template>

<script>
import { VAceEditor } from "vue3-ace-editor";
import HomeAPI from "../../apis/APIHome/HomeAPI";
import { fixCodeCSharp } from "../StudyMonitor/CompileOption/CSharp.ts";
import { fixCodeJS, runCode } from "../StudyMonitor/CompileOption/JS.ts";
export default {
  name: "CodeHome",
  components: { VAceEditor },
  data() {
    return {
      content: `Console.WriteLine("DJ - CodeMaster | Lập trình không khó!");`,
      listLangueActive: [
        { id: 1, langueName: "C#" },
        { id: 2, langueName: "Javascript" },
      ],
      langue: { id: 1, langueName: "C#" },
      result: {
        error: 0,
        result: "c://",
      },
      defaultCode: {
        csharp: `Console.WriteLine("DJ - CodeMaster | Lập trình không khó!");`,
        js: `console.log("DJ - CodeMaster | Lập trình không khó!");`,
      },
      loading: false,
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
  methods: {
    onInput(code) {
      this.$emit("input", code);
    },
    changeLangue() {
      switch (this.langue.id) {
        case 1:
          this.content = this.defaultCode.csharp;
          break;
        case 2:
          this.content = this.defaultCode.js;
          break;
      }
    },
    async tryCode() {
      this.loading = true;
      var code = this.content;
      switch (this.langue.id) {
        case 1:
          code = fixCodeCSharp(this.content);
          break;
        case 2:
          code = fixCodeJS(this.content, ";");
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
      switch (this.langue.id) {
        case 1:
          var result = await HomeAPI.tryCodeHome({
            Code: code,
          });
          this.result = result;
          break;
        case 2:
          var resultJS = runCode(code, "");
          if (resultJS.includes("ERROR###")) {
            this.result = {
              error: 0,
              result: "Error expected something",
            };
          } else {
            var resultJSSes = resultJS.split("RESULT###");
            this.result = {
              error: 0,
              result: resultJSSes[0],
            };
          }
          break;
      }
      this.loading = false;
    },
  },
};
</script>

<style lang="css" scoped>
.code-home {
  margin: 0 0 40px 3%;
  width: 100%;
  height: 580px;
}
@media screen and (max-width: 739px) {
  .code-home {
    display: none !important;
  }
}
@media screen and (max-width: 1023px) and (min-width: 740px) {
  .code-home {
    display: none !important;
  }
}
</style>
