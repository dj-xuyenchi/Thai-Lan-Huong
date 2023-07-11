<template>
  <v-dialog v-model="dialog" persistent width="1024">
    <template v-slot:activator="{ props }">
      <v-btn color="primary" v-bind="props"> Thêm người dùng</v-btn>
    </template>
    <v-card>
      <v-card-title>
        <span class="text-h5">Thêm người dùng</span>
      </v-card-title>
      <v-card-text>
        <v-container>
          <v-row>
            <v-form
              @submit.prevent="submit()"
              ref="form"
              enctype="multipart/form-data"
            >
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
                    >Ảnh đại diện người dùng</v-label
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
                    hint="Họ người dùng"
                    variant="outlined"
                    :rules="[rules.validName, rules.validValue]"
                  ></v-text-field>
                </v-col>
                <v-col cols="4" sm="4" md="4">
                  <v-text-field
                    v-model="lastName"
                    density="compact"
                    label="Tên*"
                    hint="Tên người dùng"
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
                    hint="Số điện thoại người dùng"
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
                  <v-text-field
                    v-model="userName"
                    density="compact"
                    label="Tên tài khoản*"
                    hint="Tên tài khoản"
                    variant="outlined"
                    :rules="[rules.validName, rules.validValue]"
                  ></v-text-field>
                </v-col>
                <v-col cols="4" sm="4" md="4">
                  <v-text-field
                    v-model="userEmail"
                    density="compact"
                    label="Email*"
                    hint="Email người dùng"
                    variant="outlined"
                    :rules="[rules.email, rules.validValue]"
                  ></v-text-field>
                </v-col>
                <v-col cols="4" sm="4" md="4">
                  <v-text-field
                    v-model="userPass"
                    density="compact"
                    label="Mật khẩu*"
                    hint="Mật khẩu người dùng"
                    variant="outlined"
                    type="password"
                    :rules="[rules.validValue]"
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
                <v-col cols="4" sm="4" md="4">
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
                <v-col cols="4" sm="4" md="4">
                  <v-select
                    v-model="userJob"
                    label="Công việc hiện tại"
                    :items="listCatalog"
                    item-title="catalogName"
                    persistent-hint
                    return-object
                    item-value="id"
                    variant="outlined"
                  ></v-select>
                </v-col>
                <v-col cols="4" sm="4" md="4">
                  <v-select
                    v-model="userRole"
                    label="Quyền hạn*"
                    :items="listRole"
                    item-title="userRoleName"
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
                <v-col cols="12">
                  <v-switch
                    v-model="isKYC"
                    label="Xác minh tài khoản tích xanh"
                    color="secondary"
                    hide-details
                  ></v-switch>
                </v-col>
              </v-row>
            </v-form>
          </v-row>
        </v-container>
        <small>* là trường là bắt buộc!</small>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="blue-darken-1" variant="text" @click="dialog = false">
          Hủy
        </v-btn>
        <v-btn
          color="blue-darken-1"
          :loading="btnLoading"
          variant="text"
          type="submit"
          @click="submit()"
        >
          Thêm người dùng
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
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
import AdminAPI from "../../../apis/APIAdmin/AdminAPI";
import RootAPI from "../../../apis/APIAdmin/RootAPI";
import UserAPI from "../../../apis/APIUser/UserAPI";

import { SHA512 } from "crypto-js";
export default {
  name: "AddUser",
  data: () => ({
    text: "",
    snackbar: false,
    selectFile: null,
    listGender: [],
    listTinh: [],
    listRole: [],
    listCatalog: [],
    listHuyen: [],
    listXa: [],
    listJob: [],
    firstName: "",
    lastName: "",
    userAddressNow: "",
    userAvatarData40x40: "",
    userPhone: "",
    userBirth: "",
    userName: "",
    userGender: "",
    userGenderId: "",
    userDetail: "",
    userJob: "",
    userPass: "",
    userJobCode: "",
    userId: "",
    userFacebook: "",
    userLinkedIn: "",
    userTinh: null,
    userTinhCode: null,
    userHuyen: null,
    isKYC: false,
    userRole: "",
    userEmail: "",
    userHuyenCode: "",
    userXa: null,
    userXaCode: "",
    dialog: false,
    btnLoading: false,
    opt: false,
    rules: {
      validName: (value) =>
        !/[@#$%^&+=!]/.test(value) || "Tên chứa ký tự không hợp lệ",
      sdt: (value) => /^\+?\d{1,3}\s?\d{9,}$/.test(value) || "SDT chưa đúng",
      validValue: (value) =>
        value.trim().length > 0 || "Không được để trống thông tin này!",
      email: (value) => value.includes("@") || "Email chưa đúng",
    },
  }),
  created() {
    this.getOption();
  },
  methods: {
    getData() {
      return {
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
        email: this.userEmail,
        roleId: this.userRole.id,
        isKYC: this.isKYC,
        userName: this.userName,
        userPass: SHA512(this.userPass).toString(),
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
      if (
        this.firstName.trim().length == 0 ||
        this.lastName.trim().length == 0 ||
        this.userPhone.trim().length == 0 ||
        this.userEmail.trim().length == 0 ||
        this.userName.trim().length == 0 ||
        this.userPass.trim().length == 0 ||
        this.userRole == null
      ) {
        this.text = "Không được để trông các trường bắt buộc!";
        this.snackbar = true;
        this.btnLoading = false;
        return;
      }
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
      const result = await RootAPI.createUser(formData, token);
      if (result.data == 1) {
        this.getUserPage();
        this.text = "Thêm thành công!";
        this.dialog = false;
        this.snackbar = true;
        this.btnLoading = false;
        this.userDetail = "";
        this.firstName = "";
        this.lastName = "";
        this.userAddressNow = "";
        this.userAvatarData40x40 = "";
        this.userPhone = "";
        this.userBirth = "";
        this.userName = "";
        this.userPass = "";
        this.userFacebook = "";
        this.userLinkedIn = "";
        this.userHuyen = null;
        this.userTinh = null;
        this.userXa = null;
        this.isKYC = false;
        this.userEmail = "";
        this.userGender = this.listGender[0];
        this.province = this.listTinh[0];
        this.userJob = this.listCatalog[0];
        this.userRole = this.listRole[0];
      }
      if (result.data == 8) {
        this.text = "Tồn tại tài khoản có userName là " + this.userName + "!";
        this.snackbar = true;
      }
      if (result.data == 9) {
        this.text =
          "Tồn tại tài khoản có số điện thoại là " + this.userPhone + "!";
        this.snackbar = true;
      }
      if (result.data == 10) {
        this.text = "Tồn tại tài khoản có email là " + this.userEmail + "!";
        this.snackbar = true;
      }
      this.btnLoading = false;
    },
    async getOption() {
      const token = localStorage.getItem("token");
      const data = await UserAPI.getOptionUpdate(token);
      this.listGender = data.data.genders;
      this.listTinh = data.data.provinces;
      this.listCatalog = data.data.catalogs;
      this.listRole = data.data.roles;
      this.userGender = this.listGender[0];
      this.province = this.listTinh[0];
      this.userJob = this.listCatalog[0];
      this.userRole = this.listRole[0];
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
  props: {
    getUserPage: Function,
  },
};
</script>

<style lang="css" scoped>
.my-file-input {
  display: none;
}
</style>
