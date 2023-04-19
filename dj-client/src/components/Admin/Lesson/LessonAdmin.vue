<template>
  <div style="display: flex; justify-content: space-between">
    <AddPractice />
    <AddPractice />
    <AddTheory />
  </div>
  <LessonTable :data="tableData" style="margin-top: 12px" />
</template>

<script>
import AdminAPI from "../../../apis/APIAdmin/AdminAPI.ts";
import { mapMutations } from "vuex";
import AddPractice from "./AddPractice";
import LessonTable from "./LessonTable";
import AddTheory from "./AddTheory";
export default {
  name: "LessonAdmin",
  components: { AddPractice, LessonTable, AddTheory },
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
