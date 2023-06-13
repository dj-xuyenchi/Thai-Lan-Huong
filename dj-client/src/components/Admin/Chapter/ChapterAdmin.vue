<template>
  <div style="display: flex; justify-content: flex-end">
    <div style="width: 360px; margin-right: 12px">
      <v-text-field
        v-model="key"
        label="Tìm kiếm"
        prepend-inner-icon="mdi-magnify"
        hide-details="auto"
        density="compact"
        variant="outlined"
        @keydown.enter="findLessonByName()"
      ></v-text-field>
    </div>
    <AddChapter
      :getChapterDetail="getChapterDetail"
      style="margin-top: 12px; margin-left: 8px"
    />
  </div>
  <ChapterTable
    :data="tableData"
    :getChapterDetail="getChapterDetail"
    style="margin-top: 12px"
  />
  <div class="text-center" @click="getChapterDetail()">
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
import AddChapter from "./AddChapter";
import ChapterTable from "./ChapterTable";
export default {
  name: "ChapterAdmin",
  components: { AddChapter, ChapterTable },
  data: () => ({
    tableData: [],
    page: 1,
    maxPage: 1,
  }),
  created() {
    this.getChapterDetail();
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    async getChapterDetail() {
      this.setIsLoadedData(true);
      const token = localStorage.getItem("token");
      const data = await AdminAPI.getChapterPage(this.page, token);
      this.tableData = data.data.list;
      this.maxPage = data.data.maxPage;
      this.setIsLoadedData(false);
    },
  },
};
</script>

<style lang="css" scoped></style>
