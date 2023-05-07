<template>
  <div style="margin-left: 12px">
    <v-row>
      <v-dialog v-model="dialog" persistent width="1024">
        <template v-slot:activator="{ props }">
          <font-awesome-icon
            icon="fa-solid fa-pen"
            v-bind="props"
            class="iconBtn"
            color="#898989"
          />
        </template>
        <v-form @submit.prevent="submit()" ref="form">
          <v-card
            class="mx-auto pa-12 pb-8"
            elevation="8"
            min-width="40%"
            rounded="lg"
          >
            <v-card-title>
              <span class="text-h5">Cập nhật thông tin</span>
            </v-card-title>
            <v-card-text>
              <v-container>
                <v-row
                  ><v-col cols="12" sm="12" md="12">
                    <img
                      src="
                       https://haycafe.vn/wp-content/uploads/2022/02/anh-meo-cute-hinh-cute-meo.jpg
                      "
                      alt=""
                      style="height: 100px; width: 100px; border-radius: 50%"
                    />
                    <v-label style="width: 100%; margin: 24px 0 8px 0"
                      >Ảnh đại diện của bạn</v-label
                    >
                    <v-btn
                      color="#4d96ff"
                      style="
                        height: 35px;
                        width: 104px;
                        font-size: 14px;
                        font-weight: 400;
                      "
                      @click="$refs.fileInput.click()"
                    >
                      Chọn ảnh</v-btn
                    >
                    <v-file-input
                      ref="fileInput"
                      v-model="selectedFiles"
                      accept="image/*"
                      @change="onFileSelect"
                      outlined
                      dense
                      hide-details
                      class="my-file-input"
                    ></v-file-input>
                  </v-col>
                  <v-col cols="4" sm="4" md="4">
                    <v-text-field
                      v-model="firstName"
                      class="input-field"
                      density="compact"
                      label="Họ*"
                      hint="Họ của bạn"
                      variant="outlined"
                      :rules="rules.validName"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="4" sm="4" md="4">
                    <v-text-field
                      v-model="lastName"
                      density="compact"
                      label="Tên*"
                      hint="Tên của bạn"
                      variant="outlined"
                      :rules="rules.validName"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="4" sm="4" md="4">
                    <v-label>Ngày sinh</v-label>
                    <input
                      v-model="firstName"
                      type="date"
                      style="margin-left: 12px; height: 40px; font-size: 16px"
                  /></v-col>
                  <v-col cols="4" sm="4" md="4">
                    <v-text-field
                      v-model="userPhone"
                      density="compact"
                      label="SĐT*"
                      hint="Số điện thoại liên lạc"
                      variant="outlined"
                      :rules="rules"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="4" sm="4" md="4">
                    <v-text-field
                      v-model="firstName"
                      density="compact"
                      label="Facebook"
                      hint="Facebook"
                      variant="outlined"
                      :rules="rules"
                    ></v-text-field>
                  </v-col>

                  <v-col cols="4" sm="4" md="4">
                    <v-text-field
                      v-model="firstName"
                      density="compact"
                      label="LinkedIn"
                      hint="LinkedIn"
                      variant="outlined"
                      :rules="rules"
                    ></v-text-field>
                  </v-col>

                  <v-col cols="4" sm="4" md="4">
                    <v-select
                      label="Tỉnh/thành phố"
                      :items="[
                        'California',
                        'Colorado',
                        'Florida',
                        'Georgia',
                        'Texas',
                        'Wyoming',
                      ]"
                      variant="outlined"
                    ></v-select>
                  </v-col>
                  <v-col cols="4" sm="4" md="4">
                    <v-select
                      label="Quận/huyện"
                      :items="[
                        'California',
                        'Colorado',
                        'Florida',
                        'Georgia',
                        'Texas',
                        'Wyoming',
                      ]"
                      variant="outlined"
                    ></v-select>
                  </v-col>
                  <v-col cols="4" sm="4" md="4">
                    <v-select
                      label="Xã phường"
                      :items="[
                        'California',
                        'Colorado',
                        'Florida',
                        'Georgia',
                        'Texas',
                        'Wyoming',
                      ]"
                      variant="outlined"
                      height="40px"
                    ></v-select>
                  </v-col>
                  <v-col cols="12" sm="12" md="12">
                    <v-select
                      label="Giới tính"
                      :items="[
                        'California',
                        'Colorado',
                        'Florida',
                        'Georgia',
                        'Texas',
                        'Wyoming',
                      ]"
                      variant="outlined"
                    ></v-select>
                  </v-col>
                  <v-col cols="12" sm="12" md="12">
                    <v-textarea
                      v-model="firstName"
                      density="compact"
                      label="Mô tả bản thân"
                      hint="Mô tả bản thân"
                      variant="outlined"
                      :rules="rules"
                    ></v-textarea>
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
import { mapMutations } from "vuex";
export default {
  name: "UpdateInfor",
  data() {
    return {
      text: "",
      snackbar: false,
      firstName: "",
      lastName: "",
      userPhone: "",
      userGender: "",
      userDetail: "",
      userFacebook: "",
      userLinkedIn: "",
      userTinh: "",
      userHuyen: "",
      userXa: "",
      dialog: false,
      btnLoading: false,
      rules: {
        validName: (value) =>
          !/[@#$%^&+=! ]/.test(value) || "Tên chứa ký tự không hợp lệ",
        sdt: (value) => /^\+?\d{1,3}\s?\d{9,}$/.test(value) || "SDT chưa đúng",
        validValue: (value) => value || "Tài khoản lớn hơn 8 ký tự",
      },
    };
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
  },
  async submit() {
    //   this.btnLoading = true;
    //   if (
    //     this.lessonName.trim().length < 1 ||
    //     this.lessonDescription.trim().length < 1 ||
    //     this.lessonTime.trim().length < 1 ||
    //     this.question.trim().length < 1 ||
    //     this.answera.trim().length < 1 ||
    //     this.answerb.trim().length < 1 ||
    //     this.answerc.trim().length < 1 ||
    //     this.answerd.trim().length < 1
    //   ) {
    //     this.btnLoading = false;
    //     return;
    //   }
    //   const token = localStorage.getItem("token");
    //   if (result.status == 1) {
    //     this.text = "Thêm thành công";
    //     this.dialog = false;
    //     this.snackbar = true;
    //     this.lessonName = "";
    //     this.lessonDescription = "";
    //     this.lessonTime = "";
    //     this.question = "";
    //     this.answera = "";
    //     this.answerb = "";
    //     this.answerc = "";
    //     this.answerd = "";
    //     this.answer = "A";
    //     this.getLessonDetail();
    //   }
    //   if (result.status == 2) {
    //     this.text = "Thêm thất bại";
    //     this.snackbar = true;
    //   }
    //   this.btnLoading = false;
  },

  props: {
    getLessonDetail: Function,
  },
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
