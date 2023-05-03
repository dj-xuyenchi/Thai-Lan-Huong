<template>
  <div>
    <v-row>
      <v-dialog v-model="dialog" persistent width="1024">
        <template v-slot:activator="{ props }">
          <v-btn
            color="green"
            v-bind="props"
            density="compact"
            icon="mdi-pencil"
          >
          </v-btn>
        </template>
        <v-form @submit.prevent="submit()" ref="form">
          <v-card style="overflow: scroll">
            <v-card-title>
              <span class="text-h5">Cập nhật thứ tự bài học</span>
            </v-card-title>
            <v-card-text>
              <v-container>
                <v-row>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Thứ tự mới*"
                      hint="Thứ tự của test case"
                      :rules="rules"
                      v-model="sortNumber"
                      type="number"
                    ></v-text-field>
                  </v-col>
                </v-row>
              </v-container>
              <small>* là trường là bắt buộc!</small>
            </v-card-text>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn
                color="blue-darken-1"
                variant="text"
                @click="dialog = false"
              >
                Hủy
              </v-btn>
              <v-btn
                color="blue-darken-1"
                :loading="btnLoading"
                variant="text"
                type="submit"
              >
                Cập nhật
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-form>
      </v-dialog>
    </v-row>
  </div>
  <v-snackbar v-model="snackbar">
    {{ text }}
    <template v-slot:actions>
      <v-btn color="green" variant="text" @click="snackbar = false">
        Đóng
      </v-btn>
    </template>
  </v-snackbar>
</template>

<script>
import AdminAPI from "../../../apis/APIAdmin/AdminAPI.ts";
import { mapMutations } from "vuex";
export default {
  name: "BtnUpdateLesson",
  data() {
    return {
      text: "",
      snackbar: false,
      sortNumber: 0,
      btnLoading: false,
      dialog: false,
      rules: [
        (value) => {
          if (value) return true;
          return "Không được để trống!";
        },
      ],
    };
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),

    async submit() {
      this.btnLoading = true;
      if (this.sortNumber <= 0) {
        this.text = "Sort Number phải lớn hơn 0";
        this.snackbar = true;
        this.dialog = false;
        this.btnLoading = false;
        return;
      }
      const form = Object.assign({}, this.$refs.form);
      for (const item of form.items) {
        if (!item.isValid) {
          this.btnLoading = false;
          return;
        }
      }
      const token = localStorage.getItem("token");
      const result = await AdminAPI.updateSortNumberLesson(
        {
          Id: this.item.chapterLessonId,
          SortNumber: this.sortNumber,
        },
        token
      );
      if (result.status == 1) {
        this.text = "Cập nhật thành công";
        this.dialog = false;
        this.snackbar = true;
        this.getLessonOfChapter();
      }
      if (result.status == 2) {
        this.text = "Cập nhật thất bại";
        this.snackbar = true;
      }
      this.btnLoading = false;
    },
  },
  mounted() {
    this.isLock = false;
    this.inputDetail = this.item.testCaseDetail;
    this.input = this.item.input;
    this.output = this.item.output;
    this.sortNumber = this.item.sortNumber;
  },
  props: {
    getLessonOfChapter: Function,
    testCaseId: Number,
    item: Object,
  },
};
</script>

<style lang="css" scoped></style>
