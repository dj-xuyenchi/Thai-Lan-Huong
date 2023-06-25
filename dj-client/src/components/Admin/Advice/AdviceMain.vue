<template>
  <div style="display: flex; justify-content: flex-end">
    <div style="width: 360px; margin-right: 12px">
      <v-text-field
        v-model="key"
        label="Tìm kiếm"
        hide-details="auto"
        density="compact"
        variant="outlined"
        prepend-inner-icon="mdi-magnify"
        @keydown.enter="findBlog()"
      ></v-text-field>
    </div>
  </div>
  <AdviceTable :tableData="tableData" :page="page" :getBlogPage="getBlogPage" />
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
    <v-snackbar v-model="snackbar">
      {{ text }}
      <template v-slot:actions>
        <v-btn color="green" variant="text" @click="snackbar = false">
          Đóng
        </v-btn>
      </template>
    </v-snackbar>
  </div>
</template>

<script>
import { mapMutations } from "vuex";
import AdminAPI from "../../../apis/APIAdmin/AdminAPI.ts";
import AdviceTable from "./AdviceTable";
export default {
  name: "AdviceMain",
  components: {
    AdviceTable,
  },
  data: () => ({
    tableData: [],
    snackbar: false,
    text: "",
    page: 1,
    context: "",
    maxPage: 1,
    key: "",
    show: false,
  }),
  created() {
    this.getBlogPage();
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    async findBlog() {
      this.setIsLoadedData(true);
      if (this.key.trim().length == 0) {
        this.text = "Hãy nhập từ khóa";
        this.snackbar = true;
        this.setIsLoadedData(false);
        return;
      }
      const token = localStorage.getItem("token");
      const data = await AdminAPI.findBlog(this.key, token);
      this.tableData = data.data;
      this.setIsLoadedData(false);
    },
    async getBlogPage() {
      this.setIsLoadedData(true);
      const token = localStorage.getItem("token");
      const data = await AdminAPI.getAdviceContact(this.page, token);
      this.tableData = data;
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
