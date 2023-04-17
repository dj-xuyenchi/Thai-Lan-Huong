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
      <v-tabs v-model="tab" bg-color="transparent" color="basil" grow>
        <v-tab v-for="(item, index) in listTest" :key="item" :value="item">
          Case {{ index + 1 }}
        </v-tab>
      </v-tabs>
      <v-window v-model="tab" style="margin-bottom: 12px">
        <v-window-item v-for="item in listTest" :key="item" :value="item">
          <v-card
            :color="
              item.result === 1
                ? `green`
                : item.result === 2
                ? `red`
                : item.result === 3
                ? `red`
                : item.result === 4
                ? `white`
                : ``
            "
            flat
          >
            <v-card-text>Đầu vào: {{ item.input }}</v-card-text>
            <v-card-text>Đầu ra thực tế: {{ item.output }}</v-card-text>
            <v-card-text>Đầu ra mong muốn: {{ item.expectOutput }}</v-card-text>
          </v-card>
        </v-window-item>
      </v-window>
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
      >
        <font-awesome-icon
          icon="fa-solid fa-floppy-disk"
          color="black"
          style="font-size: 20px; margin-right: 4px"
        />
        Nộp bài
      </v-btn>
    </div>
  </div>
</template>

<script>
import { VAceEditor } from "vue3-ace-editor";
import StudyAPI from "../../apis/APIStudy/StudyAPI.ts";
import { mapMutations } from "vuex";
export default {
  name: "CodeEditor",
  components: { VAceEditor },
  data() {
    return {
      content: "",
      tab: 0,
      listTest: [],
    };
  },
  props: {
    testCase: [],
    beginCodeMethod: String,
    practiceLessonId: Number,
  },
  mounted() {
    this.content = this.beginCodeMethod;
    this.listTest = this.testCase;
  },
  setup(props) {
    return { props };
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    async tryTestCase() {
      this.setIsLoadedData(true);
      const token = localStorage.getItem("token");
      const data = await StudyAPI.tryTestCase(
        this.content,
        this.practiceLessonId,
        token
      );
      this.listTest = data.data.testCase;
      this.setIsLoadedData(false);
    },
  },
};
</script>
