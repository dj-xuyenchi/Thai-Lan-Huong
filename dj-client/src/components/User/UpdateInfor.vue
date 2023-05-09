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
        <v-form @submit.prevent="submit()" ref="form" style="overflow: scroll">
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
                      :src="
                        'data:image/jpeg;base64, ' + user.userAvatarData40x40
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
                      v-model="selectFile"
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
                      density="compact"
                      label="Họ*"
                      hint="Họ của bạn"
                      variant="outlined"
                      :rules="[rules.validName, rules.validValue]"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="4" sm="4" md="4">
                    <v-text-field
                      v-model="lastName"
                      density="compact"
                      label="Tên*"
                      hint="Tên của bạn"
                      variant="outlined"
                      :rules="[rules.validName, rules.validValue]"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="4" sm="4" md="4">
                    <v-label>Ngày sinh</v-label>
                    <input
                      v-model="userBirth"
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
                      :rules="[rules.sdt]"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="4" sm="4" md="4">
                    <v-text-field
                      v-model="userFacebook"
                      density="compact"
                      label="Facebook"
                      hint="Facebook"
                      variant="outlined"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="4" sm="4" md="4">
                    <v-text-field
                      v-model="userLinkedIn"
                      density="compact"
                      label="LinkedIn"
                      hint="LinkedIn"
                      variant="outlined"
                    ></v-text-field>
                  </v-col>

                  <v-col cols="4" sm="4" md="4">
                    <v-select
                      v-model="userTinh"
                      label="Tỉnh/thành phố"
                      :items="listTinh"
                      item-title="full_name"
                      persistent-hint
                      return-object
                      item-value="code"
                      variant="outlined"
                      @change="getHuyen()"
                    ></v-select>
                  </v-col>
                  <v-col cols="4" sm="4" md="4">
                    <v-select
                      v-model="userHuyen"
                      label="Quận/huyện"
                      :items="listHuyen"
                      variant="outlined"
                      item-title="full_name"
                      persistent-hint
                      return-object
                      item-value="code"
                    ></v-select>
                  </v-col>
                  <v-col cols="4" sm="4" md="4">
                    <v-select
                      v-model="userXa"
                      label="Xã/phường"
                      :items="listXa"
                      item-title="full_name"
                      persistent-hint
                      return-object
                      item-value="code"
                      variant="outlined"
                    ></v-select>
                  </v-col>
                  <v-col cols="12" sm="12" md="12">
                    <v-select
                      v-model="userGender"
                      label="Giới tính"
                      :items="listGender"
                      item-title="genderName"
                      persistent-hint
                      return-object
                      item-value="id"
                      variant="outlined"
                    ></v-select>
                  </v-col>
                  <v-col cols="12" sm="12" md="12">
                    <v-textarea
                      v-model="userDetail"
                      density="compact"
                      label="Mô tả bản thân"
                      hint="Mô tả bản thân"
                      variant="outlined"
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
import UserAPI from "../../apis/APIUser/UserAPI.ts";
import { mapMutations } from "vuex";
export default {
  name: "UpdateInfor",
  data() {
    return {
      text: "",
      snackbar: false,
      selectFile: null,
      listTinh: [{ code: "", full_name: "" }],
      listHuyen: [{ code: "", full_name: "" }],
      listXa: [{ code: "", full_name: "" }],
      listGender: [],
      firstName: "",
      lastName: "",
      userPhone: "",
      userBirth: null,
      userGender: null,
      userGenderId: null,
      userDetail: "",
      userFacebook: "",
      userLinkedIn: "",
      userTinh: null,
      userTinhCode: null,
      userHuyen: null,
      userHuyenCode: null,
      userXa: null,
      userXaCode: null,
      dialog: false,
      btnLoading: false,
      rules: {
        validName: (value) =>
          !/[@#$%^&+=! ]/.test(value) || "Tên chứa ký tự không hợp lệ",
        sdt: (value) => /^\+?\d{1,3}\s?\d{9,}$/.test(value) || "SDT chưa đúng",
        validValue: (value) =>
          value.trim().length > 0 || "Không được để trống thông tin này!",
      },
    };
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
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
    async getOption() {
      const token = localStorage.getItem("token");
      const data = await UserAPI.getOptionUpdate(token);
      this.listGender = data.data.genders;
      this.listTinh = data.data.provinces;
    },
    async getHuyen() {
      console.log(this.userTinh);
      const token = localStorage.getItem("token");
      const data = await UserAPI.getHuyen(this.userTinh.code, token);
      this.listHuyen = data.data.districts;
    },
    async getXa() {
      const token = localStorage.getItem("token");
      const data = await UserAPI.getOptionUpdate(token);
      this.listXa = data.data.wards;
    },
  },
  mounted() {
    this.userDetail = this.user.userDetail;
    this.firstName = this.user.userFisrtName;
    this.lastName = this.user.userLastName;
    this.userLinkedIn = this.user.userLinkedIn;
    this.userFacebook = this.user.userFacebook;
    this.userPhone = this.user.numberPhone;
    this.listGender = this.user.genders;
    if (this.user.provinces) {
      this.listTinh = this.user.provinces;
      this.listHuyen = this.user.districts;
      this.listXa = this.user.wards;
    }
    this.userTinh = this.user.province;
    this.userTinhCode = this.user.provinceCode;
    this.userHuyen = this.user.district;
    this.userTinhCode = this.user.districtCode;
    this.userXa = this.user.ward;
    this.userXaCode = this.user.wardCode;
    this.userGender = this.user.genderName;
    this.userGenderId = this.user.genderId;
    if (this.user.birthday) {
      const birthday = this.user.birthday.split(" - ");
      this.userBirth = birthday[2] + "-" + birthday[1] + "-" + birthday[0];
    }
    // this.getOption();

    // const tt = this.listGender.find((x) => {
    //   return (x.id = this.user.genderId);
    // });
    // console.log(tt);
  },
  props: {
    user: Object,
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
