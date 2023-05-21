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
              <span class="text-h5">Cập nhật thứ tự</span>
            </v-card-title>
            <v-card-text>
              <v-container>
                <v-row>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Thứ tự mới*"
                      hint="Thứ tự khi hiển thị"
                      v-model="sortNumber"
                      :rules="rules"
                      type="number"
                    ></v-text-field>
                  </v-col>
                </v-row>
              </v-container>
              <small>* là trường là bắt buộc. !</small>
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
  name: "BtnUpdateChapter",
  data() {
    return {
      text: "",
      snackbar: false,
      sortNumber: null,
      dialog: false,
      btnLoading: false,
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
      const token = localStorage.getItem("token");
      const result = await AdminAPI.updateSortNumberCourseChapter(
        this.courseChapterId,
        this.sortNumber,
        token
      );
      if (result.data == 1) {
        this.text = "Cập nhật thành công";
        this.dialog = false;
        this.snackbar = true;
        this.getChapterOfCourse();
      }
      if (result.data == 4) {
        this.text = "Không tồn tại";
        this.snackbar = true;
      }
      this.btnLoading = false;
    },
  },
  props: {
    getChapterOfCourse: Function,
    courseChapterId: Number,
  },
};
</script>

<style lang="css" scoped></style>
