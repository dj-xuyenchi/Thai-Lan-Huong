<template>
  <div class="problem-solution-container">
    <TitlePractice />
  </div>
</template>

<script>
import TitlePractice from "./TitlePractice.vue";
export default {
  name: "ProblemSolution",
  components: { TitlePractice },
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
