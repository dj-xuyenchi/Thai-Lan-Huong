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
        <v-tab v-for="item in items" :key="item" :value="item">
          {{ item }}
        </v-tab>
      </v-tabs>
      <v-window v-model="tab" style="margin-bottom: 12px">
        <v-window-item v-for="(item, index) in items" :key="item" :value="item">
          <v-card
            :color="
              caseInfo[index].isFalse === 1
                ? `white`
                : caseInfo[index].isFalse === 2
                ? `green`
                : `red`
            "
            flat
          >
            <v-card-text>Đầu vào: {{ caseInfo[index].input }}</v-card-text>
            <v-card-text
              >Đầu ra thực tế: {{ caseInfo[index].realOutput }}</v-card-text
            >
            <v-card-text
              >Đầu ra mong muốn:
              {{ caseInfo[index].expectedOutput }}</v-card-text
            >
          </v-card>
        </v-window-item>
      </v-window>
      <v-btn color="#1b749b" v-bind="props" style="width: 120px">
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
export default {
  name: "CodeEditor",
  components: { VAceEditor },
  data() {
    return {
      content: "",
      tab: "TestCase",
      items: ["Case 1", "Case 2"],
      caseInfo: [
        {
          input: "1,2",
          realOutput: "43",
          expectedOutput: "77",
          isFalse: 1,
        },
        {
          input: "1,2",
          realOutput: "43",
          expectedOutput: "27",
          isFalse: 2,
        },
      ],
    };
  },
};
</script>
