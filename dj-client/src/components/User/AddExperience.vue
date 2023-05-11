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
              <span class="text-h5">Thêm kinh nghiệm làm việc</span>
            </v-card-title>
            <v-card-text>
              <v-container>
                <v-row>
                  <v-col cols="6" sm="6" md="6">
                    <v-text-field
                      v-model="detail"
                      density="compact"
                      label="Công việc*"
                      hint="Nơi làm việc, tên công ty"
                      variant="outlined"
                      :rules="[rules.validValue]"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="6" sm="6" md="6">
                    <v-text-field
                      v-model="position"
                      density="compact"
                      label="Vị trí*"
                      hint="Vị trí làm việc VD: Trưởng nhóm"
                      variant="outlined"
                      :rules="[rules.validValue]"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="6" sm="6" md="6">
                    <v-label>Bắt đầu từ*</v-label>
                    <input
                      v-model="start"
                      type="date"
                      style="margin-left: 12px; height: 40px; font-size: 16px"
                  /></v-col>
                  <v-col cols="6" sm="6" md="6" v-if="!isWorking">
                    <v-label>Kết thúc</v-label>
                    <input
                      v-model="end"
                      type="date"
                      style="margin-left: 12px; height: 40px; font-size: 16px"
                  /></v-col>
                  <v-col cols="12" sm="12" md="12">
                    <v-switch
                      v-model="isWorking"
                      label="Đang làm việc"
                      color="secondary"
                      hide-details
                    ></v-switch>
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
  name: "AddExpertience",
  data() {
    return {
      text: "",
      snackbar: false,
      isWorking: false,
      detail: null,
      position: null,
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
        isWorking: this.isWorking,
        detail: this.detail,
        position: this.position,
        start: this.start,
        end: this.end,
      };
    },
    async submit() {
      this.btnLoading = true;
      if (
        !this.detail ||
        !this.position ||
        this.position.trim().length == 0 ||
        this.detail.trim().length == 0
      ) {
        this.text = "Không được để trống thông tin!";
        this.snackbar = true;
        this.btnLoading = false;
        return;
      }
      if (this.start == null) {
        this.text = "Không được để trống ngày bắt đầu!";
        this.snackbar = true;
        this.btnLoading = false;
        return;
      }
      if (!this.isWorking && this.end == null) {
        this.text = "Không được để trống ngày kết thúc!";
        this.snackbar = true;
        this.btnLoading = false;
        return;
      }
      const token = localStorage.getItem("token");
      const result = await UserAPI.createExperience(this.getData(), token);
      if (result.data == 1) {
        this.text = "Thêm thành công!";
        this.detail = null;
        this.position = null;
        this.start = null;
        this.end = null;
        this.isWorking = false;
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
