<template>
  <div style="display: flex; justify-content: space-between">
    <AddChapter />
  </div>
  <ChapterTable :data="tableData" style="margin-top: 12px" />
</template>

<script>
import AdminAPI from "../../../apis/APIAdmin/AdminAPI.ts";
import { mapMutations } from "vuex";
import ChapterTable from "./ChapterTable";
import AddChapter from "./AddChapter";
export default {
  name: "ChapterAdmin",
  components: { ChapterTable, AddChapter },
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
