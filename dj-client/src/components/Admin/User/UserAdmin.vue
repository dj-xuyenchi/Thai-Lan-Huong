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
        @keydown.enter="findUser(1)"
      ></v-text-field>
    </div>
    <AddUser style="margin-top: 12px" :getUserPage="getUserPage" />
  </div>
  <UserTable :tableData="tableData" :getUserPage="getUserPage" />
  <div class="text-center" @click="pageOpt()">
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
import RootAPI from "../../../apis/APIAdmin/RootAPI.ts";
import UserTable from "./UserTable";
import AddUser from "./AddUser";
export default {
  name: "UserAdmin",
  components: {
    UserTable,
    AddUser,
    // AddTheory,
    // AddQuestion,
    // AddModel,
    // CustomGen,
    // GenPracticeGPT,
  },
  data: () => ({
    tableData: [],
    snackbar: false,
    text: "",
    page: 1,
    context: "",
    maxPage: 10,
    opt: 1,
    key: "",
    show: false,
  }),
  created() {
    this.getUserPage();
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    async findUser(page) {
      this.setIsLoadedData(true);
      if (this.key.trim().length == 0) {
        this.text = "Hãy nhập từ khóa";
        this.snackbar = true;
        this.page = 1;
        this.setIsLoadedData(false);
        return;
      }
      const token = localStorage.getItem("token");
      const data = await RootAPI.findUser(this.key, page, token);
      this.tableData = data;
      this.opt = 2;
      this.setIsLoadedData(false);
    },
    async getUserPage() {
      this.setIsLoadedData(true);
      const token = localStorage.getItem("token");
      const data = await RootAPI.getUserPage(this.page, token);
      this.tableData = data;
      this.opt = 1;
      this.setIsLoadedData(false);
    },
    async pageOpt() {
      if (this.opt == 1) {
        this.getUserPage();
      }
      if (this.opt == 2) {
        this.findUser(this.page);
      }
    },
    setContext(context) {
      this.context = context;
      this.show = true;
    },
    setShow(show) {
      this.show = show;
    },
  },
  watch: {
    tableData: {
      immediate: true,
      handler(newData) {
        this.tableData = newData;
      },
    },
  },
};
</script>

<style lang="css" scoped></style>
