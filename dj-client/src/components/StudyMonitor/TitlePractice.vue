<template>
  <div style="margin-left: 2.5%">
    <div style="margin-top: 20px">
      <h4 style="font-size: 24px; font-family: inherit; font-weight: 700">
        Bài tập {{ problem }}
      </h4>
      <span
        style="font-family: inherit; font-weight: 350"
        v-html="problemDetail"
      ></span>
    </div>
  </div>
</template>

<script>
export default {
  name: "TitlePractice",
  props: {
    problem: String,
    problemDetail: String,
  },
};
</script>

<style lang="css" scoped>
.infor-lesson .fix-middle {
  padding: 12px 12px 12px 4%;
}
</style>
