<template>
  <div style="display: flex; justify-content: space-between">
    <ProblemSolution
      :practiceData="this.dataItem.practiceLesson"
      style="height: 65vh"
    />
    <div>
      <v-ace-editor
        v-model:value="userCode"
        :highlightActiveLine="true"
        :mode="'csharp'"
        :theme="'chrome'"
        readonly
        :options="option"
        style="height: 60vh; margin-top: 8px; width: 45vw"
      />
      <div style="margin-top: 12px">
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
                v-for="(item, index) in testCase"
                :key="index"
                :value="`option-` + index"
                :disabled="item.lockTestCase"
              >
                <span style="font-weight: 900; color: green">
                  <v-icon start v-if="item.lockTestCase == false">
                    mdi-book
                  </v-icon>
                  <v-icon start v-if="item.lockTestCase == true">
                    mdi-lock
                  </v-icon>
                </span>
                <span style="font-weight: 900; color: green">
                  Case {{ index + 1 }}</span
                >
              </v-tab>
            </v-tabs>
            <v-window v-model="tab" style="width: 90% !important">
              <v-window-item
                v-for="(item, index) in testCase"
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
                          item.expectOutput
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
                        <span class="test-case-result"> Đáp ứng </span></span
                      >
                    </div>
                  </v-card-text>
                </v-card>
              </v-window-item>
            </v-window>
          </div>
        </v-card>
      </div>
    </div>
  </div>
</template>

<script>
import { VAceEditor } from "vue3-ace-editor";
import ProblemSolution from "../../StudyMonitor/ProblemSolution";
export default {
  name: "PracDoneData",
  components: { VAceEditor, ProblemSolution },
  data() {
    return {
      userCode: "",
      tab: "option-0",
      testCase: [],
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
    dataItem: Object,
    doneTime: String,
  },
  created() {
    this.userCode = this.dataItem.doneData;
    this.testCase = this.dataItem.practiceLesson.testCases;
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
