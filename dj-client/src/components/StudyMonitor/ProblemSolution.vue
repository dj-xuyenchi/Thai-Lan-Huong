<template>
  <div class="problem-solution-container">
    <TitlePractice
      :problem="practiceData.problem"
      :problemDetail="practiceData.problemDetail"
    />
    <BodyPractice
      :explain="practiceData.explain"
      :input="practiceData.input"
      :expectOutput="practiceData.expectOutput"
      :suggest="practiceData.suggest"
    />
  </div>
</template>

<script>
import TitlePractice from "./TitlePractice.vue";
import BodyPractice from "./BodyPractice.vue";
export default {
  name: "ProblemSolution",
  components: { TitlePractice, BodyPractice },
  props: {
    practiceData: Object,
  },
};
</script>

<style lang="css" scoped>
.problem-solution-container {
  width: 45%;
  float: left;
  height: 92vh;
  overflow: scroll;
}
</style>
