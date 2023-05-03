<template>
  <div></div>
</template>

<script>
export default {
  name: "ForwardLesson",
  created() {
    const lessonId = localStorage.getItem("lessonIdFW");
    const idCourse = localStorage.getItem("idCourseFW");
    const chapterId = localStorage.getItem("chapterIdFW");
    localStorage.removeItem("lessonIdFW");
    localStorage.removeItem("idCourseFW");
    localStorage.removeItem("chapterIdFW");
    this.$router.push({
      path: "/study/" + lessonId + "/" + idCourse + "/" + chapterId,
    });
  },
};
</script>

<style lang="scss" scoped></style>
