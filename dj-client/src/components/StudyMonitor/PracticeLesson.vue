<template>
  <div class="practice-container">
    <ProblemSolution />
    <CodeEditor />
  </div>
</template>

<script>
import CodeEditor from "./CodeEditor.vue";
import ProblemSolution from "./ProblemSolution.vue";
export default {
  name: "PracticeLesson",
  components: { CodeEditor, ProblemSolution },
};
</script>

<style lang="css" scoped>
.practice-container {
  margin-top: 52px;
}
</style>
