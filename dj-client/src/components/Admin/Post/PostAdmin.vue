<template>
  <div style="display: flex; justify-content: flex-end">
    <div style="width: 360px; margin-right: 12px">
      <v-text-field
        v-model="key"
        label="Tìm kiếm"
        hide-details="auto"
        density="compact"
        prepend-inner-icon="mdi-magnify"
        variant="outlined"
        @keydown.enter="findLessonByName()"
      ></v-text-field>
    </div>
    <!-- <AddBlog style="margin-top: 12px" :getBlogPage="getBlogPage" /> -->
  </div>
  <PostTable :tableData="tableData" />
  <div class="text-center" @click="getLessonDetail()">
    <v-container>
      <v-row justify="center">
        <v-col cols="4">
          <v-container class="max-width">
            <v-pagination
              v-model="page"
              class="my-2"
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
import { mapMutations } from "vuex";
import AdminAPI from "../../../apis/APIAdmin/AdminAPI.ts";
import PostTable from "./PostTable";
export default {
  name: "PostAdmin",
  components: {
    PostTable,
    // AddTheory,
    // AddQuestion,
    // AddModel,
    // CustomGen,
    // GenPracticeGPT,
  },
  data: () => ({
    tableData: [],
    page: 1,
    context: "",
    maxPage: 1,
    key: null,
    show: false,
  }),
  created() {
    this.getBlogPage();
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    async findLessonByName() {
      this.setIsLoadedData(true);
      if (!this.key) {
        this.setIsLoadedData(false);
        return;
      }
      const token = localStorage.getItem("token");
      const data = await AdminAPI.findLessonByName(this.key, token);
      this.tableData = data.data;
      this.setIsLoadedData(false);
    },
    async getBlogPage() {
      this.setIsLoadedData(true);
      const token = localStorage.getItem("token");
      const data = await AdminAPI.getBlogPage(this.page, token);
      this.tableData = data.data;
      this.maxPage = data.data.maxPage;
      this.setIsLoadedData(false);
    },
    setContext(context) {
      this.context = context;
      this.show = true;
    },
    setShow(show) {
      this.show = show;
    },
  },
};
</script>

<style lang="css" scoped></style>
