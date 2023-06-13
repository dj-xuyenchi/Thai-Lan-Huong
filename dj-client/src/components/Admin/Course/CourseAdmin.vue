<template>
  <div style="display: flex; justify-content: flex-end">
    <div style="width: 360px; margin-right: 12px">
      <v-text-field
        v-model="key"
        label="Tìm kiếm"
        hide-details="auto"
        prepend-inner-icon="mdi-magnify"
        density="compact"
        variant="outlined"
        @keydown.enter="findLessonByName()"
      ></v-text-field>
    </div>
    <AddCourse
      :getCoursePage="getCoursePage"
      style="margin-top: 12px; margin-left: 8px"
    />
  </div>
  <CourseTable
    :data="tableData"
    style="margin-top: 12px"
    :getCoursePage="getCoursePage"
  />
  <div class="text-center" @click="getCoursePage()">
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
import AddChapterToCourse from "./AddChapterToCourse";
import AddCourse from "./AddCourse";
import CourseTable from "./CourseTable";
export default {
  name: "CourseAdmin",
  components: { AddCourse, CourseTable },
  data: () => ({
    tableData: [],
    page: 1,
    maxPage: 1,
  }),
  created() {
    this.getCoursePage();
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    async getCoursePage() {
      this.setIsLoadedData(true);
      const token = localStorage.getItem("token");
      const data = await AdminAPI.getCoursePage(this.page, token);
      this.tableData = data.data.list;
      this.maxPage = data.data.maxPage;
      this.setIsLoadedData(false);
    },
  },
};
</script>

<style lang="css" scoped></style>
