<template>
  <div class="practice-container">
    <ProblemSolution :practiceData="practiceData" />
    <CodeEditor
      :beginCodeMethod="practiceData.beginCodeMethod"
      :testCase="practiceData.testCase"
      :practiceLessonId="practiceData.practiceLessonId"
      :codeOk="practiceData.codeOk"
      :isSupportMultiLangue="practiceData.isSupportMultiLangue"
      :defaultLangue="practiceData.defaultLangue"
      :listLangue="practiceData.listLangue"
      :multiLangueDTOs="practiceData.multiLangueDTOs"
    />
  </div>
</template>

<script>
import CodeEditor from "./CodeEditor.vue";
import ProblemSolution from "./ProblemSolution.vue";
export default {
  name: "PracticeLesson",
  components: { ProblemSolution, CodeEditor },
  props: {
    practiceData: Object,
  },
};
</script>

<style lang="css" scoped>
.practice-container {
  margin-top: 52px;
}
::-webkit-scrollbar {
  width: 0.5em;
}
</style>
