<template>
  <div style="display: flex; justify-content: space-between">
    <AddPractice :getLessonDetail="getLessonDetail" />
    <AddPractice />
    <AddTheory />
  </div>
  <LessonTable :data="tableData" style="margin-top: 12px" />
  <div class="text-center" @click="getLessonDetail()">
    <v-container>
      <v-row justify="center">
        <v-col cols="4">
          <v-container class="max-width">
            <v-pagination
              v-model="page"
              class="my-4"
              :length="maxPage"
              rounded="circle"
            ></v-pagination>
          </v-container>
        </v-col>
      </v-row>
    </v-container>
  </div>
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
    page: 1,
    maxPage: 1,
  }),
  created() {
    this.getLessonDetail();
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    async getLessonDetail() {
      this.setIsLoadedData(true);
      const token = localStorage.getItem("token");
      const data = await AdminAPI.getLessonPage(this.page, token);
      this.tableData = data.data.list;
      this.maxPage = data.data.maxPage;
      this.setIsLoadedData(false);
    },
  },
};
</script>

<style lang="css" scoped></style>
