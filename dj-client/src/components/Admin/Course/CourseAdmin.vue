<template>
  <div style="display: flex; justify-content: space-between">
    <AddCourse />
  </div>
  <CourseTable :data="tableData" style="margin-top: 12px" />
</template>

<script>
import AdminAPI from "../../../apis/APIAdmin/AdminAPI.ts";
import { mapMutations } from "vuex";
import CourseTable from "./CourseTable";
import AddCourse from "./AddCourse";
export default {
  name: "CourseAdmin",
  components: { AddCourse, CourseTable },
  data: () => ({
    tableData: [],
  }),
  created() {
    this.getLessonDetail();
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    async getLessonDetail() {
      this.setIsLoadedData(true);
      const token = localStorage.getItem("token");
      const data = await AdminAPI.getLesson(token);
      this.tableData = data.data;
      this.setIsLoadedData(false);
    },
  },
};
</script>

<style lang="css" scoped></style>
