<template>
  <div style="margin-left: 12px">
    <v-row>
      <v-dialog v-model="dialog" persistent width="1024">
        <template v-slot:activator="{ props }">
          <v-btn
            color="#4d96ff"
            v-bind="props"
            density="compact"
            icon="mdi-plus"
          >
          </v-btn>
        </template>
        <v-form @submit.prevent="submit()" ref="form" style="overflow: scroll">
          <v-card
            class="mx-auto pa-12 pb-8"
            elevation="8"
            min-width="40%"
            rounded="lg"
          >
            <v-card-title>
              <span class="text-h5">Thêm thông tin học vấn</span>
            </v-card-title>
            <v-card-text>
              <v-container>
                <v-row>
                  <v-col cols="6" sm="6" md="6">
                    <v-select
                      v-model="school"
                      label="Trường*"
                      :items="listSchool"
                      item-title="schoolName"
                      hint="Trường Cao Đẳng/Đại Học"
                      persistent-hint
                      return-object
                      item-value="id"
                      variant="outlined"
                    ></v-select>
                  </v-col>
                  <v-col cols="6" sm="6" md="6">
                    <v-select
                      v-model="majors"
                      label="Chuyên nghành*"
                      :items="listMajors"
                      item-title="majorsName"
                      hint="Nghành học tại trường"
                      persistent-hint
                      return-object
                      item-value="id"
                      variant="outlined"
                    ></v-select>
                  </v-col>
                  <v-col cols="6" sm="6" md="6">
                    <v-label>Bắt đầu từ*</v-label>
                    <input
                      v-model="start"
                      type="date"
                      style="margin-left: 12px; height: 40px; font-size: 16px"
                  /></v-col>
                  <v-col cols="6" sm="6" md="6">
                    <v-label>Kết thúc*</v-label>
                    <input
                      v-model="end"
                      type="date"
                      style="margin-left: 12px; height: 40px; font-size: 16px"
                  /></v-col>
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
                Xác nhận
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
import UserAPI from "../../apis/APIUser/UserAPI.ts";
import { mapMutations } from "vuex";
export default {
  name: "AddLearningExperience",
  data() {
    return {
      text: "",
      snackbar: false,
      listSchool: [],
      listMajors: [],
      school: null,
      majors: null,
      start: null,
      end: null,
      dialog: false,
      btnLoading: false,
      rules: {
        validValue: (value) =>
          value.trim().length > 0 || "Không được để trống thông tin này!",
      },
    };
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    getData() {
      return {
        userId: localStorage.getItem("id"),
        school: this.school.id,
        majors: this.majors.id,
        start: this.start,
        end: this.end,
      };
    },
    async submit() {
      this.btnLoading = true;
      if (!this.school || !this.majors || !this.start || !this.end) {
        this.text = "Không được để trống thông tin!";
        this.snackbar = true;
        this.btnLoading = false;
        return;
      }
      const token = localStorage.getItem("token");
      const result = await UserAPI.createLearning(this.getData(), token);
      if (result.data == 1) {
        this.text = "Thêm thành công!";
        this.start = null;
        this.school = null;
        this.majors = null;
        this.end = null;
        this.dialog = false;
        this.snackbar = true;
        this.btnLoading = false;
        this.getUserInfor();
      }
      if (result.data == 4) {
        this.text = "Thêm thất bại!";
        this.snackbar = true;
      }
      this.btnLoading = false;
    },
    async getOption() {
      const token = localStorage.getItem("token");
      const result = await UserAPI.getOption(token);
      this.listMajors = result.data.majorsDTOs;
      this.listSchool = result.data.schoolDTOs;
    },
  },
  created() {
    this.getOption();
  },
  props: { getUserInfor: Function },
};
</script>

<style lang="css" scoped>
.iconBtn {
  margin-left: 40px;
  font-size: 16px;
  position: absolute;
  right: 20px;
}
.iconBtn:hover {
  cursor: pointer;
}

.my-file-input {
  display: none;
}
</style>
