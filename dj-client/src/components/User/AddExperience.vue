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
        <v-form
          @submit.prevent="submit()"
          ref="form"
          style="overflow: scroll"
          enctype="multipart/form-data"
        >
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
                  <v-col cols="4" sm="4" md="4">
                    <v-text-field
                      v-model="userFacebook"
                      density="compact"
                      label="Facebook"
                      hint="Facebook"
                      variant="outlined"
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
import UserAPI from "../../apis/APIUser/UserAPI.ts";
import { mapMutations } from "vuex";
export default {
  name: "AddExpertience",
  data() {
    return {
      text: "",
      snackbar: false,

      dialog: false,
      btnLoading: false,
      rules: {
        validName: (value) =>
          !/[@#$%^&+=!]/.test(value) || "Tên chứa ký tự không hợp lệ",
        sdt: (value) => /^\+?\d{1,3}\s?\d{9,}$/.test(value) || "SDT chưa đúng",
        validValue: (value) =>
          value.trim().length > 0 || "Không được để trống thông tin này!",
      },
    };
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),

    async submit() {
      this.btnLoading = true;
      // if (
      //   this.lessonName.trim().length < 1 ||
      //   this.lessonDescription.trim().length < 1 ||
      //   this.lessonTime.trim().length < 1 ||
      //   this.question.trim().length < 1 ||
      //   this.answera.trim().length < 1 ||
      //   this.answerb.trim().length < 1 ||
      //   this.answerc.trim().length < 1 ||
      //   this.answerd.trim().length < 1
      // ) {
      //   this.btnLoading = false;
      //   return;
      // }
      const token = localStorage.getItem("token");
      const formData = new FormData();
      formData.append("avatar", this.selectFile ? this.selectFile[0] : null);
      formData.append("updateUserRequest", JSON.stringify(this.getData()));
      const result = await UserAPI.updateUser(formData, token);
      if (result.data.status == 1) {
        this.text = "Cập nhật thành công!";
        localStorage.setItem("nickName", result.data.nickName);
        localStorage.setItem("avatar", result.data.avatar);
        localStorage.setItem("name", result.data.name);
        this.getUserInfor();
        this.dialog = false;
        this.snackbar = true;
        this.btnLoading = false;
        this.getLessonDetail();
      }
      if (result.data.status == 4) {
        this.text = "Cập nhật thất bại!";
        this.snackbar = true;
      }
      this.btnLoading = false;
    },
    async getOption() {
      const token = localStorage.getItem("token");
      const data = await UserAPI.getOptionUpdate(token);
      this.listGender = data.data.genders;
      this.listTinh = data.data.provinces;
    },
    async getHuyen() {
      const token = localStorage.getItem("token");
      const data = await UserAPI.getHuyen(this.userTinh.code, token);
      this.listHuyen = data.data;
      this.userHuyen = data.data[0];
      this.getXa();
    },
    async getXa() {
      const token = localStorage.getItem("token");
      const data = await UserAPI.getXa(this.userHuyen.code, token);
      this.listXa = data.data;
      this.userXa = data.data[0];
    },
  },
  props: {},
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
