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
      <img :src="userInfor.userAvatarData40x40" alt="Hình ảnh" />
    </div>
    <div class="right-infor">
      <ul>
        <li>
          <div>
            <span class="field-title"
              >Họ và tên <span class="required-star">*</span></span
            >
            <span class="field-content" style="position: relative"
              >{{ userInfor.userFisrtName + " " + userInfor.userLastName }}
              <UpdateInfor
                :getUserInfor="getUserInfor"
                v-if="userInfor.userAvatarData40x40"
                :user="userInfor"
              />
            </span>
          </div>
        </li>
        <li>
          <div>
            <span class="field-title"
              >Ngày sinh <span class="required-star"></span
            ></span>
            <span class="field-content">{{
              userInfor.birthday ? userInfor.birthday : "Chưa cập nhật!"
            }}</span>
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
              >Công việc hiện tại <span class="required-star"></span
            ></span>
            <span class="field-content">{{
              userInfor.catalog ? userInfor.catalog : "Chưa cập nhật!"
            }}</span>
          </div>
        </li>
        <li>
          <div>
            <span class="field-title"
              >Tỉnh/Thành phố <span class="required-star"></span
            ></span>
            <span class="field-content">{{
              userInfor.province ? userInfor.province : "Chưa cập nhật!"
            }}</span>
          </div>
        </li>
        <li>
          <div>
            <span class="field-title"
              >Quận/Huyện <span class="required-star"></span
            ></span>
            <span class="field-content">{{
              userInfor.district ? userInfor.district : "Chưa cập nhật!"
            }}</span>
          </div>
        </li>
        <li>
          <div>
            <span class="field-title"
              >Xã/Phường <span class="required-star"></span
            ></span>
            <span class="field-content">{{
              userInfor.ward ? userInfor.ward : "Chưa cập nhật!"
            }}</span>
          </div>
        </li>
        <li>
          <div>
            <span class="field-title"
              >Địa chỉ hiện tại <span class="required-star"></span
            ></span>
            <span class="field-content">{{
              userInfor.addressNow ? userInfor.addressNow : "Chưa cập nhật!"
            }}</span>
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
            <a
              :href="userInfor.userFacebook ? userInfor.userFacebook : ``"
              class="field-content"
              target="_blank"
              style="color: blue"
              >{{
                userInfor.userFacebook
                  ? userInfor.userFacebook.length > 40
                    ? userInfor.userFacebook.substring(0, 37) + `...`
                    : userInfor.userFacebook
                  : "Chưa cập nhật!"
              }}</a
            >
          </div>
        </li>
        <li>
          <div>
            <span class="field-title"
              >LinkedIn <span class="required-star"></span
            ></span>
            <a
              :href="userInfor.userLinkedIn ? userInfor.userLinkedIn : ``"
              class="field-content"
              target="_blank"
              style="color: blue"
              >{{
                userInfor.userLinkedIn
                  ? userInfor.userLinkedIn.length > 40
                    ? userInfor.userLinkedIn.substring(0, 37) + `...`
                    : userInfor.userLinkedIn
                  : "Chưa cập nhật!"
              }}</a
            >
          </div>
        </li>
        <li>
          <div>
            <span class="field-title"
              >Mô tả bản thân <span class="required-star"></span
            ></span>
            <span class="field-content">{{
              userInfor.userDetail ? userInfor.userDetail : "Chưa cập nhật!"
            }}</span>
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
    <AddExperience :getUserInfor="getUserInfor" />
    <div
      style="margin-top: 36px"
      v-for="(item, index) in userInfor.experienceDTOs"
      :key="index"
    >
      <h4
        style="
          color: #898989;
          font-size: 14px;
          line-height: 16px;
          font-weight: normal;
        "
      >
        Công việc <span style="color: red">*</span
        ><font-awesome-icon
          icon="fa-regular fa-trash-can"
          class="iconBtn"
          color="#898989"
          style="margin-left: 12px"
          @click="deleteExperience(item.id)"
        />
      </h4>
      <h4
        style="
          color: #black;
          font-size: 14px;
          line-height: 16px;
          font-weight: normal;
          margin-top: 4px;
          font-family: 'Muli', sans-serif;
        "
      >
        {{ item.detail }}
      </h4>
      <h4
        style="
          color: #898989;
          font-size: 14px;
          line-height: 16px;
          font-weight: normal;
          margin-top: 8px;
        "
      >
        Vị trí <span style="color: red">*</span>
      </h4>
      <h4
        style="
          color: #black;
          font-size: 14px;
          line-height: 16px;
          font-weight: normal;
          margin-top: 4px;
          font-family: 'Muli', sans-serif;
        "
      >
        {{ item.position }}
      </h4>
      <h4
        style="
          color: #898989;
          font-size: 14px;
          line-height: 16px;
          font-weight: normal;
          margin-top: 8px;
        "
      >
        Thời gian <span style="color: red">*</span>
      </h4>
      <h4
        style="
          color: #black;
          font-size: 14px;
          line-height: 16px;
          font-weight: normal;
          margin-top: 4px;
          font-family: 'Muli', sans-serif;
        "
      >
        {{ item.timeLine }}
      </h4>
    </div>
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
    <AddLearningExperience :getUserInfor="getUserInfor" />
    <div
      style="margin-top: 36px"
      v-for="(item, index) in userInfor.learningDTOs"
      :key="index"
    >
      <h4
        style="
          color: #898989;
          font-size: 14px;
          line-height: 16px;
          font-weight: normal;
        "
      >
        Trường <span style="color: red">*</span
        ><font-awesome-icon
          icon="fa-regular fa-trash-can"
          class="iconBtn"
          color="#898989"
          style="margin-left: 12px"
          @click="deleteLearning(item.id)"
        />
      </h4>
      <h4
        style="
          color: #black;
          font-size: 14px;
          line-height: 16px;
          font-weight: normal;
          margin-top: 4px;
          font-family: 'Muli', sans-serif;
        "
      >
        {{ item.schoolName }}
      </h4>
      <h4
        style="
          color: #898989;
          font-size: 14px;
          line-height: 16px;
          font-weight: normal;
          margin-top: 8px;
        "
      >
        Chuyên nghành <span style="color: red">*</span>
      </h4>
      <h4
        style="
          color: #black;
          font-size: 14px;
          line-height: 16px;
          font-weight: normal;
          margin-top: 4px;
          font-family: 'Muli', sans-serif;
        "
      >
        {{ item.majors }}
      </h4>
      <h4
        style="
          color: #898989;
          font-size: 14px;
          line-height: 16px;
          font-weight: normal;
          margin-top: 8px;
        "
      >
        Thời gian <span style="color: red">*</span>
      </h4>
      <h4
        style="
          color: #black;
          font-size: 14px;
          line-height: 16px;
          font-weight: normal;
          margin-top: 4px;
          font-family: 'Muli', sans-serif;
        "
      >
        {{ item.timeLine }}
      </h4>
    </div>
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
import AddLearningExperience from "./AddLearningExperience.vue";
import UpdateInfor from "./UpdateInfor.vue";

import { mapMutations } from "vuex";
export default {
  name: "InforContact",
  components: { AddExperience, UpdateInfor, AddLearningExperience },
  data() {
    return {
      userInfor: {
        userAvatarData40x40: "",
      },
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
    async deleteExperience(id) {
      this.setIsLoadedData(true);
      const token = localStorage.getItem("token");
      const data = await UserAPI.deleteExperience(id, token);
      if (data.data == 1) {
        this.snackbarOk = true;
        this.snackBarContent = "Thành công!";
        this.getUserInfor();
        this.setIsLoadedData(false);
        return;
      }
      if (data.data == 4) {
        this.snackbarOk = true;
        this.snackBarContent = "Xóa thất bại!";
        this.setIsLoadedData(false);
        return;
      }
      this.setIsLoadedData(false);
    },
    async deleteLearning(id) {
      this.setIsLoadedData(true);
      const token = localStorage.getItem("token");
      const data = await UserAPI.deleteLearning(id, token);
      if (data.data == 1) {
        this.snackbarOk = true;
        this.snackBarContent = "Thành công!";
        this.getUserInfor();
        this.setIsLoadedData(false);
        return;
      }
      if (data.data == 4) {
        this.snackbarOk = true;
        this.snackBarContent = "Xóa thất bại!";
        this.setIsLoadedData(false);
        return;
      }
      this.setIsLoadedData(false);
    },
  },
};
</script>

<style lang="css" scoped>
.left-avatar {
  width: 22%;
  float: left;
}
.left-avatar img {
  height: 100px;
  width: 100px;
  border-radius: 50%;
}
.right-infor {
  width: 78%;
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
  width: 28%;
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
  width: 72%;
  display: block;
  text-decoration: none;
  float: left;
}
.iconBtn:hover {
  cursor: pointer;
}
</style>
