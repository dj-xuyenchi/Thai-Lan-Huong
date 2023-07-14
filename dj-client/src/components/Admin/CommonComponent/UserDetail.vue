<template>
  <v-dialog v-model="dialog" persistent width="1024">
    <template v-slot:activator="{ props }">
      <span
        v-bind="props"
        style="min-width: 260px; display: inline-flex; align-items: center"
      >
        <img
          :src="item.studentAvatar"
          alt="Hình ảnh"
          style="height: 40px; width: 40px; border-radius: 50%"
        />
        <span style="margin-left: 8px">
          {{ item.studentName
          }}<img
            v-if="item.isKYC"
            :src="require('../../../assets/kyc.png')"
            alt="Hình ảnh"
            class="kyc"
        /></span>
      </span>
    </template>
    <v-card>
      <v-card-title>
        <span class="text-h5">Thông tin người dùng</span>
      </v-card-title>
      <v-card-text>
        <v-container>
          <!-- <v-row>
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
                <v-col cols="4" sm="4" md="4">
                  <v-select
                    v-model="userStatus"
                    label="Trạng thái*"
                    :items="listStatus"
                    item-title="userStatusName"
                    persistent-hint
                    return-object
                    item-value="id"
                    variant="outlined"
                  ></v-select>
                </v-col>
                <div v-if="userStatus.id == 4">
                  <v-col cols="12" sm="12" md="12">
                    <v-select
                      v-model="lockOpt"
                      label="Khóa trong"
                      :items="listOpt"
                      item-title="name"
                      persistent-hint
                      return-object
                      item-value="id"
                      variant="outlined"
                    ></v-select>
                  </v-col>
                </div>
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
          </v-row> -->
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
          Cập nhật
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
  name: "UserDetail",
  data() {
    return {
      dialog: false,
    };
  },
  created() {
    console.log(this.item);
  },
  props: { changeDialogDetail: Function, item: Object },
};
</script>

<style lang="css" scoped>
.my-file-input {
  display: none;
}
.kyc {
  height: 20px;
  width: 20px;
  position: relative;
  top: 4px;
  left: 4px;
}
</style>
