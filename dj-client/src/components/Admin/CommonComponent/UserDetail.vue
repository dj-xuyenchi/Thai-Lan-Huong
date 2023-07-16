<template>
  <v-dialog v-model="dialog" persistent width="1024">
    <template v-slot:activator="{ props }">
      <span
        v-bind="props"
        style="min-width: 260px; display: inline-flex; align-items: center"
      >
        <img
          :src="avatar"
          alt="Hình ảnh"
          style="height: 40px; width: 40px; border-radius: 50%"
        />
        <span style="margin-left: 8px">
          {{ name
          }}<img
            v-if="isKYC"
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
          <v-row>
            <v-row
              ><v-col cols="12" sm="12" md="12">
                <img
                  :src="avatar"
                  alt="Hình ảnh"
                  style="height: 100px; width: 100px; border-radius: 50%"
                />
              </v-col>
              <v-col cols="4" sm="4" md="4">
                <v-text-field
                  v-model="nameAPI"
                  density="compact"
                  label="Họ tên"
                  readonly
                  variant="outlined"
                ></v-text-field>
              </v-col>
              <v-col cols="4" sm="4" md="4">
                <v-text-field
                  v-model="email"
                  density="compact"
                  label="Email"
                  readonly
                  variant="outlined"
                ></v-text-field>
              </v-col>
              <v-col cols="4" sm="4" md="4">
                <v-label>Ngày sinh</v-label>
                <input
                  v-model="birthDay"
                  type="date"
                  readonly
                  style="margin-left: 12px; height: 40px; font-size: 16px"
              /></v-col>

              <v-col cols="4" sm="4" md="4">
                <v-text-field
                  v-model="gender"
                  density="compact"
                  readonly
                  label="Giới tính"
                  variant="outlined"
                ></v-text-field>
              </v-col>
              <v-col cols="4" sm="4" md="4">
                <v-text-field
                  v-model="role"
                  density="compact"
                  label="Quyền hạn"
                  readonly
                  variant="outlined"
                ></v-text-field>
              </v-col>
              <v-col cols="4" sm="4" md="4">
                <v-text-field
                  v-model="address"
                  density="compact"
                  readonly
                  label="Địa chỉ"
                  variant="outlined"
                ></v-text-field>
              </v-col>

              <v-col cols="12" sm="12" md="12">
                <v-textarea
                  v-model="detail"
                  density="compact"
                  label="Mô tả"
                  readonly
                  variant="outlined"
                ></v-textarea>
              </v-col>
              <v-col cols="12">
                <v-switch
                  v-model="kyc"
                  label="Xác minh tài khoản tích xanh"
                  readonly
                  color="secondary"
                  hide-details
                ></v-switch>
              </v-col>
            </v-row>
          </v-row>
        </v-container>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="blue-darken-1" variant="text" @click="dialog = false">
          Đồng ý
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
export default {
  name: "UserDetail",
  data() {
    return {
      dialog: false,
      role: "",
      nameAPI: "",
      email: "",
      gender: "",
      detail: "",
      birthDay: "",
      address: "",
      kyc: false,
    };
  },
  mounted() {
    this.getUserShow();
  },
  methods: {
    async getUserShow() {
      const data = await AdminAPI.getUserShow(
        this.userId,
        localStorage.getItem("token")
      );
      this.role = data.role;
      this.email = data.email;
      this.nameAPI = data.name;
      this.gender = data.gender;
      this.detail = data.detail;
      this.birthDay = data.birthDay;
      this.address = data.address;
      this.kyc = data.isKYC;
    },
  },
  props: { avatar: String, name: String, isKYC: Boolean, userId: Number },
  watch: {
    userId: {
      immediate: true,
      handler() {
        this.getUserShow();
      },
    },
  },
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
