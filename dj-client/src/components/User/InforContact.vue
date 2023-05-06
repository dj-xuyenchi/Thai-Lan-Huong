<template>
  <div>
    <h4
      style="
        color: #4d96ff;
        font-size: 24px;
        font-weight: bold;
        margin-bottom: 14px;
        letter-spacing: 1px;
      "
    >
      Thông tin
    </h4>
    <div class="left-avatar">
      <img
        :src="'data:image/jpeg;base64,' + userInfor.userAvatarData40x40"
        alt=""
      />
    </div>
    <div class="right-infor">
      <ul>
        <li>
          <div>
            <span class="field-title"
              >Họ và tên <span class="required-star">*</span></span
            >
            <span class="field-content" style="position: relative"
              >{{ userInfor.userLastName + " " + userInfor.userFisrtName }}
              <UpdateInfor />
            </span>
          </div>
        </li>
        <li>
          <div>
            <span class="field-title"
              >Ngày sinh <span class="required-star"></span
            ></span>
            <span class="field-content">{{ userInfor.birthday }}</span>
          </div>
        </li>
        <li>
          <div>
            <span class="field-title"
              >Số điện thoại <span class="required-star">*</span></span
            >
            <span class="field-content">{{ userInfor.numberPhone }}</span>
          </div>
        </li>
        <li>
          <div>
            <span class="field-title"
              >Địa chỉ Email <span class="required-star">*</span></span
            >
            <span class="field-content">{{ userInfor.userEmail }}</span>
          </div>
        </li>
        <li>
          <div>
            <span class="field-title"
              >Tỉnh/Thành phố <span class="required-star"></span
            ></span>
            <span class="field-content">{{ userInfor.province }}</span>
          </div>
        </li>
        <li>
          <div>
            <span class="field-title"
              >Quận/Huyện <span class="required-star"></span
            ></span>
            <span class="field-content">{{ userInfor.district }}</span>
          </div>
        </li>
        <li>
          <div>
            <span class="field-title"
              >Xã/Phường <span class="required-star"></span
            ></span>
            <span class="field-content">{{ userInfor.ward }}</span>
          </div>
        </li>
        <li>
          <div>
            <span class="field-title"
              >Giới tính <span class="required-star"></span
            ></span>
            <span class="field-content">{{ userInfor.genderName }}</span>
          </div>
        </li>
        <li>
          <div>
            <span class="field-title"
              >Facebook <span class="required-star"></span
            ></span>
            <span class="field-content">{{ userInfor.userFacebook }}</span>
          </div>
        </li>
        <li>
          <div>
            <span class="field-title"
              >LinkedIn <span class="required-star"></span
            ></span>
            <span class="field-content">{{ userInfor.userLinkedIn }}</span>
          </div>
        </li>
        <li>
          <div>
            <span class="field-title"
              >Mô tả bản thân <span class="required-star"></span
            ></span>
            <span class="field-content">{{ userInfor.userDetail }}</span>
          </div>
        </li>
        <li>
          <div>
            <span class="field-title"
              >Thành tích <span class="required-star"></span
            ></span>
            <span class="field-content">Chiến thần Front End</span>
          </div>
        </li>
      </ul>
    </div>
    <h4
      style="
        color: #4d96ff;
        font-size: 24px;
        font-weight: bold;
        margin-bottom: 14px;
        letter-spacing: 1px;
      "
    >
      Kinh nghiệm
    </h4>
    <h5
      style="
        color: #000000;
        font-size: 15px;
        font-weight: bold;
        margin-bottom: 14px;
        letter-spacing: 1px;
      "
    >
      Mô tả kinh nghiệm làm việc của bạn
    </h5>
    <AddExperience />
    <h4
      style="
        color: #4d96ff;
        font-size: 24px;
        font-weight: bold;
        margin-bottom: 14px;
        margin-top: 24px;
        letter-spacing: 1px;
      "
    >
      Học vấn
    </h4>
    <h5
      style="
        color: #000000;
        font-size: 15px;
        font-weight: bold;
        margin-bottom: 14px;
        letter-spacing: 1px;
      "
    >
      Thêm thông tin học vấn
    </h5>
    <AddExperience />
    <div style="height: 40px"></div>
    <v-snackbar v-model="snackbarOk" multi-line>
      {{ snackBarContent }}
      <template v-slot:actions>
        <v-btn color="green" variant="text" @click="snackbarOk = false">
          Đóng
        </v-btn>
      </template>
    </v-snackbar>
  </div>
</template>

<script>
import UserAPI from "../../apis/APIUser/UserAPI.ts";
import AddExperience from "./AddExperience.vue";
import UpdateInfor from "./UpdateInfor.vue";

import { mapMutations } from "vuex";
export default {
  name: "InforContact",
  components: { AddExperience, UpdateInfor },
  data() {
    return {
      userInfor: [],
      snackbarOk: false,
      snackBarContent: "",
    };
  },
  created() {
    this.getUserInfor();
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    async getUserInfor() {
      this.setIsLoadedData(true);
      const token = localStorage.getItem("token");
      const userId = localStorage.getItem("id");
      const data = await UserAPI.getUserInfor(userId, token);
      if (data.status == 4) {
        this.snackbarOk = true;
        this.snackBarContent = "Lỗi không tìm thấy thông tin tài khoản!";
        this.setIsLoadedData(false);
        return;
      }
      this.userInfor = data.data;
      this.setIsLoadedData(false);
    },
  },
};
</script>

<style lang="css" scoped>
.left-avatar {
  width: 16%;
  float: left;
}
.left-avatar img {
  height: 100px;
  width: 100px;
  border-radius: 50%;
}
.right-infor {
  width: 84%;
  float: left;
}
.right-infor ul li {
  height: 44px;
}
.right-infor .field-title {
  color: #898989;
  font-size: 14px;
  line-height: 16px;
  font-weight: normal;
  font-family: "Muli", sans-serif;
  letter-spacing: 1px;
  width: 25%;
  display: block;
  float: left;
}
.right-infor .required-star {
  color: #f00;
}
.right-infor .field-content {
  height: 16px;
  color: #333;
  font-size: 14px;
  line-height: 16px;
  font-weight: normal;
  font-family: "Muli", sans-serif;
  letter-spacing: 1px;
  font-weight: 400;
  width: 75%;
  display: block;
  float: left;
}
</style>
