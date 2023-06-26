<template>
  <div>
    <v-row>
      <v-dialog v-model="dialog" persistent width="1024">
        <template v-slot:activator="{ props }">
          <v-btn
            color="green"
            v-bind="props"
            density="compact"
            icon="mdi-magnify"
          >
          </v-btn>
        </template>
        <v-form @submit.prevent="submit()" ref="form">
          <v-card style="overflow: scroll">
            <v-card-title>
              <span class="text-h5">Thông tin chi tiết yêu cầu</span>
            </v-card-title>
            <v-card-text>
              <v-container>
                <v-row v-if="isConfirm">
                  <v-col cols="12" sm="12" md="12">
                    <v-btn color="blue" @click="getData()"
                      >Xác nhận xem yêu cầu!</v-btn
                    >
                  </v-col>
                </v-row>
                <v-row v-if="!isConfirm">
                  <v-col cols="12" sm="12" md="12">
                    <v-label
                      >Yêu cầu tư vấn:
                      <span style="color: red">
                        {{
                          type == 1
                            ? " Học 1:1"
                            : type == 2
                            ? " Định hướng nghề"
                            : type == 3
                            ? " Cơ hội việc làm"
                            : " Khác"
                        }}</span
                      ></v-label
                    >
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-label>Họ tên</v-label>
                    <v-text-field
                      v-model="name"
                      density="compact"
                      variant="outlined"
                      readonly
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-label>Số điện thoại</v-label>
                    <v-text-field
                      v-model="sdt"
                      density="compact"
                      variant="outlined"
                      readonly
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-label>Ngày gửi yêu cầu</v-label>
                    <v-text-field
                      v-model="time"
                      density="compact"
                      variant="outlined"
                      readonly
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="12" md="12">
                    <v-label>Ghi chú người gửi</v-label>
                    <v-textarea
                      v-model="note"
                      density="compact"
                      variant="outlined"
                      readonly
                    ></v-textarea>
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
  name: "AdviceDetail",
  data() {
    return {
      text: "",
      snackbar: false,
      name: "ss",
      sdt: "",
      time: "",
      note: "",
      type: 0,
      isConfirm: true,
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
    async getData() {
      const token = localStorage.getItem("token");
      const result = await AdminAPI.getAdviceData(this.idAdvice, token);
      this.name = result.name;
      this.sdt = result.sdt;
      this.note = result.note;
      this.time = result.sendRequest;
      this.type = result.typeAdvice;
      this.isConfirm = false;
    },
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
      const result = await AdminAPI.getAdviceData(
        this.courseChapterId,
        this.sortNumber,
        token
      );
      if (result.data == 1) {
        this.text = "Cập nhật thành công";
        this.dialog = false;
        this.snackbar = true;
      }
      if (result.data == 4) {
        this.text = "Không tồn tại";
        this.snackbar = true;
      }
      this.btnLoading = false;
    },
    fixDate(vari) {
      return (
        vari.substring(8, 10) + vari.substring(4, 8) + vari.substring(0, 4)
      );
    },
  },
  props: {
    idAdvice: Number,
  },
};
</script>

<style lang="css" scoped></style>
