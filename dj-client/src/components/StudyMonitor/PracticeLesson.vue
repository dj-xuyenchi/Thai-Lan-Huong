<template>
  <div class="practice-container">
    <ProblemSolution :practiceData="practiceData" />
    <CodeEditor
      :beginCodeMethod="practiceData.beginCodeMethod"
      :testCase="practiceData.testCase"
      :practiceLessonId="practiceData.practiceLessonId"
    />
  </div>
</template>

<script>
import CodeEditor from "./CodeEditor.vue";
import ProblemSolution from "./ProblemSolution.vue";
export default {
  name: "PracticeLesson",
  components: { CodeEditor, ProblemSolution },
  props: {
    practiceData: Object,
  },
};
</script>

<style lang="css" scoped>
.practice-container {
  margin-top: 52px;
}
</style>
