<template>
  <AddPractice />
  <LessonTable :data="tableData" />
</template>

<script>
import AdminAPI from "../../../apis/APIAdmin/AdminAPI.ts";
import { mapMutations } from "vuex";
import AddPractice from "./AddPractice";
import LessonTable from "./LessonTable";
export default {
  name: "LessonAdmin",
  components: { AddPractice, LessonTable },
  data: () => ({
    dialog1: false,
    dialog2: false,
    dialog3: false,
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
