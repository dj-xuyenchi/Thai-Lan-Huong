<template>
  <div style="margin-top: 120px">
    <div>saP</div>
    <v-ace-editor
      v-model:value="content"
      @init="editorInit"
      lang="html"
      theme="chrome"
      style="height: 300px"
    />
  </div>
</template>

<script>
import { VAceEditor } from "vue3-ace-editor";

export default {
  name: "CodeEditor",
  components: { VAceEditor },
  data() {
    return {
      code: "",
    };
  },
};
</script>
