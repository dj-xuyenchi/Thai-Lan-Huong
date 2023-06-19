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
              <span class="text-h5">Cập nhật thông tin</span>
            </v-card-title>
            <v-card-text>
              <v-container>
                <v-row
                  ><v-col cols="12" sm="12" md="12">
                    <img
                      :src="
                        (opt ? `data:image/jpeg;base64, ` : ``) +
                        userAvatarData40x40
                      "
                      alt="Hình ảnh"
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
                  <v-col cols="12" sm="12" md="12">
                    <v-textarea
                      v-model="userAddressNow"
                      density="compact"
                      label="Địa chỉ hiện tại"
                      hint="Địa chỉ hiện tại"
                      variant="outlined"
                      max-rows="5"
                    ></v-textarea>
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
                      @update:modelValue="getHuyen()"
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
                      @update:modelValue="getXa()"
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
                  <v-col cols="6" sm="6" md="6">
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
                  <v-col cols="6" sm="6" md="6">
                    <v-select
                      v-model="userJob"
                      label="Công việc hiện tại"
                      :items="listJob"
                      item-title="catalogName"
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
import { SHA512 } from "crypto-js";

export default {
  name: "UpdateInfor",
  data() {
    return {
      text: "",
      snackbar: false,
      selectFile: null,
      listTinh: [],
      opt: false,
      listHuyen: [],
      listXa: [],
      listJob: [],
      listGender: [],
      firstName: null,
      lastName: null,
      userAddressNow: null,
      userAvatarData40x40: null,
      userPhone: null,
      userBirth: null,
      userGender: null,
      userGenderId: null,
      userDetail: null,
      userJob: null,
      userJobCode: null,
      userId: null,
      userFacebook: null,
      userLinkedIn: null,
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
          !/[@#$%^&+=!]/.test(value) || "Tên chứa ký tự không hợp lệ",
        sdt: (value) => /^\+?\d{1,3}\s?\d{9,}$/.test(value) || "SDT chưa đúng",
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
        firstName: this.firstName,
        lastName: this.lastName,
        birthday: this.userBirth ? this.userBirth : "1000-01-01",
        sdt: this.userPhone,
        facebook: this.userFacebook,
        linkedIn: this.userLinkedIn,
        addressNow: this.userAddressNow,
        province: this.userTinh ? this.userTinh.code : this.userTinhCode,
        district: this.userHuyen ? this.userHuyen.code : this.userHuyenCode,
        ward: this.userXa ? this.userXa.code : this.userXaCode,
        gender: this.userGender.id ? this.userGender.id : this.userGenderId,
        catalog: this.userJob ? this.userJob.id : this.userJobCode,
        detail: this.userDetail,
      };
    },
    onFileSelect() {
      if (
        this.selectFile[0].type == "image/png" ||
        this.selectFile[0].type == "image/jpeg" ||
        this.selectFile[0].type == "image/jpg"
      ) {
        if (this.selectFile[0].size > 1048576) {
          this.text = "File quá nặng chỉ hỗ trợ file dung lượng < 1MB";
          this.snackbar = true;
          return;
        }
        const reader = new FileReader();
        reader.onload = () => {
          this.userAvatarData40x40 = reader.result.split(",")[1];
        };
        reader.readAsDataURL(this.selectFile[0]);
        this.opt = true;
      } else {
        this.text =
          "Vui lòng chọn đúng file định dạng ảnh! Các định dạng được hỗ trợ: JPG, JPEG, PNG";
        this.snackbar = true;
        return;
      }
    },
    async submit() {
      this.btnLoading = true;
      if (this.firstName.length + this.lastName.length > 25) {
        this.text = "Tên quá dài!";
        this.snackbar = true;
        this.btnLoading = false;
        return;
      }
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
  mounted() {
    this.userDetail = this.user.userDetail;
    this.firstName = this.user.userFisrtName;
    this.lastName = this.user.userLastName;
    this.userLinkedIn = this.user.userLinkedIn;
    this.userFacebook = this.user.userFacebook;
    this.userPhone = this.user.numberPhone;
    this.listGender = this.user.genders;
    this.listJob = this.user.catalogs;
    this.userJob = this.user.catalog;
    this.userJobCode = this.user.catalogId;
    this.userAvatarData40x40 = this.user.userAvatarData40x40;
    this.userAddressNow = this.user.addressNow;
    if (this.listHuyen) {
      this.listTinh = this.user.provinces;
      this.listHuyen = this.user.districts;
      this.listXa = this.user.wards;
    } else {
      this.listTinh = this.user.provinces;
    }
    this.userTinh = this.user.province;
    this.userTinhCode = this.user.provinceCode;
    this.userHuyen = this.user.district;
    this.userHuyenCode = this.user.districtCode;
    this.userXa = this.user.ward;
    this.userXaCode = this.user.wardCode;
    this.userGender = this.user.genderName;
    this.userGenderId = this.user.genderId;
    if (this.user.birthday) {
      const birthday = this.user.birthday.split(" - ");
      this.userBirth = birthday[2] + "-" + birthday[1] + "-" + birthday[0];
    }
  },
  props: {
    user: Object,
    getUserInfor: Function,
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
::-webkit-scrollbar {
  width: 0.5em;
}
</style>
