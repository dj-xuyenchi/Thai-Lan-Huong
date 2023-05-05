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
      <img :src="require('../../assets/intro.jpg')" alt="" />
    </div>
    <div class="right-infor">
      <ul>
        <li>
          <div>
            <span class="field-title"
              >Họ và tên <span class="required-star">*</span></span
            >
            <span class="field-content" style="position: relative"
              >Đỗ Quang Anh
              <font-awesome-icon
                icon="fa-solid fa-pen"
                style="
                  margin-left: 40px;
                  font-size: 16px;
                  position: absolute;
                  right: 20px;
                "
                color="#898989"
            /></span>
          </div>
        </li>
        <li>
          <div>
            <span class="field-title"
              >Ngày sinh <span class="required-star"></span
            ></span>
            <span class="field-content">Đỗ Quang Anh</span>
          </div>
        </li>
        <li>
          <div>
            <span class="field-title"
              >Số điện thoại <span class="required-star">*</span></span
            >
            <span class="field-content">Đỗ Quang Anh</span>
          </div>
        </li>
        <li>
          <div>
            <span class="field-title"
              >Địa chỉ Email <span class="required-star">*</span></span
            >
            <span class="field-content">Đỗ Quang Anh</span>
          </div>
        </li>
        <li>
          <div>
            <span class="field-title"
              >Tỉnh/Thành phố <span class="required-star"></span
            ></span>
            <span class="field-content">Đỗ Quang Anh</span>
          </div>
        </li>
        <li>
          <div>
            <span class="field-title"
              >Quận/Huyện <span class="required-star"></span
            ></span>
            <span class="field-content">Đỗ Quang Anh</span>
          </div>
        </li>
        <li>
          <div>
            <span class="field-title"
              >Xã/Phường <span class="required-star"></span
            ></span>
            <span class="field-content">Đỗ Quang Anh</span>
          </div>
        </li>
        <li>
          <div>
            <span class="field-title"
              >Giới tính <span class="required-star"></span
            ></span>
            <span class="field-content">Đỗ Quang Anh</span>
          </div>
        </li>
        <li>
          <div>
            <span class="field-title"
              >Facebook <span class="required-star"></span
            ></span>
            <span class="field-content">Đỗ Quang Anh</span>
          </div>
        </li>
        <li>
          <div>
            <span class="field-title"
              >LinkedIn <span class="required-star"></span
            ></span>
            <span class="field-content">Đỗ Quang Anh</span>
          </div>
        </li>
        <li>
          <div>
            <span class="field-title"
              >Mô tả bản thân <span class="required-star"></span
            ></span>
            <span class="field-content">Đỗ Quang Anh</span>
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
    <AddExperience style="margin-left: 12px" />
  </div>
</template>

<script>
import AddExperience from "./AddExperience.vue";
export default {
  name: "InforContact",
  components: { AddExperience },
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
