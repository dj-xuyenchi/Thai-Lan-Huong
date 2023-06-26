<template>
  <div class="course-detail-container">
    <div class="course-detail-left">
      <div class="detail-header">
        <h1 style="font-weight: 700; font-size: 30px">
          Chứng nhận hoàn thành khóa học
        </h1>
        <h4 style="font-weight: 400">
          Cảm ơn sự nỗ lực của bạn trong thời gian qua dưới đây là Chứng nhận
          hoàn thành khóa học.
        </h4>
      </div>
      <div
        style="
          width: 100%;
          display: flex;
          justify-content: center;
          margin-top: 24px;
        "
      >
        <div id="certificate">
          <div class="name">
            <span>{{ name }}</span>
          </div>
          <div class="course">
            <span>Đã hoàn thành khóa học</span>
          </div>
          <div class="course-detail">
            <span>{{ courseName }}</span>
          </div>
          <div class="signature1">
            <span>giám đốc sản xuất</span>
          </div>
          <div class="logo">
            <img
              :src="require(`../../assets/logo-web.png`)"
              alt="logo"
              style="height: 65px"
            />
          </div>
          <div class="done-time">
            <span>Hà Nội, ngày {{ day }} tháng {{ month }} năm {{ year }}</span>
          </div>
          <div class="signature">
            <img
              :src="require(`../../assets/chuky.png`)"
              alt="logo"
              style="height: 75px"
            />
          </div>
          <div class="signature2">
            <span>Đỗ Quang Anh</span>
          </div>
        </div>
      </div>
      <v-btn color="#4d96ff" @click="generatePDF()" style="margin: 12px 0 0 20%"
        >Tải xuống PDF</v-btn
      >
      <br />
      <p style="margin: 12px 0 0 20%">Link Chứng chỉ</p>
      <input
        type=""
        name=""
        :value="
          `https://dj-xuyenchi.edu.vn/#/home/certificate/` +
          this.$route.params.courseId +
          `/` +
          this.$route.params.userId
        "
        style="width: 400px; height: 24px; margin: 12px 0 0 20%; color: blue"
      />
    </div>
  </div>
</template>

<script>
import html2pdf from "html2pdf.js";
import HomeAPI from "../../apis/APIHome/HomeAPI";
import { mapMutations } from "vuex";
export default {
  data() {
    return {
      name: "",
      courseName: "",
      day: "",
      month: "",
      year: "",
    };
  },
  created() {
    this.takeCertificate();
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    async takeCertificate() {
      this.setIsLoadedData(true);
      const data = await HomeAPI.takeCertificate(
        this.$route.params.courseId,
        this.$route.params.userId
      );
      this.name = data.data.name;
      this.courseName = data.data.courseName;
      this.day = data.data.day;
      this.month = data.data.month;
      this.year = data.data.year;
      this.setIsLoadedData(false);
    },
    generatePDF() {
      const element = document.getElementById("certificate"); // ID của phần tử HTML chứa nội dung muốn chuyển đổi thành PDF
      const options = {
        filename: "certificate.pdf",
        image: { type: "jpeg", quality: 0.98 }, // Tuỳ chọn hình ảnh nếu cần
        html2canvas: {}, // Tuỳ chọn html2canvas nếu cần
        jsPDF: {
          format: [this.pxToMm(500), this.pxToMm(750)],
          orientation: "landscape",
        }, // Tuỳ chọn jsPDF nếu cần
      };

      html2pdf().set(options).from(element).save();
    },
    pxToMm(px) {
      return Math.floor(px * 0.264583);
    },
  },
};
</script>

<style lang="css" scoped>
.course-detail-container {
  width: 95%;
  margin-left: 2.5%;
}
.course-detail-container .course-detail-left {
  display: block;
  float: left;
  width: 65%;
}
#certificate {
  background-image: url("../../assets/certificate.jpeg");
  height: 500px;
  width: 750px;
  position: relative;
}
#certificate .name {
  position: absolute;
  top: 240px;
  color: #4d96ff;
  font-size: 46px;
  display: flex;
  width: 100%;
  justify-content: center;
  font-family: "Dancing Script", cursive;
}
#certificate .course {
  position: absolute;
  top: 325px;
  font-size: 18px;
  display: flex;
  width: 100%;
  justify-content: center;
  font-family: "Merriweather", serif;
}
#certificate .course-detail {
  position: absolute;
  top: 350px;
  color: #4d96ff;
  font-size: 18px;
  display: flex;
  width: 100%;
  justify-content: center;
  font-style: italic;
  font-family: "Merriweather", serif;
}
#certificate .signature {
  position: absolute;
  top: 400px;
  font-size: 12px;
  width: 100%;
  left: 430px;
}
#certificate .signature2 {
  position: absolute;
  top: 440px;
  font-size: 12px;
  width: 100%;
  left: 470px;
  font-weight: bold;
}
#certificate .signature1 {
  position: absolute;
  top: 380px;
  font-size: 14px;
  width: 100%;
  text-transform: uppercase;
  left: 440px;
}
#certificate .done-time {
  position: absolute;
  top: 445px;
  font-size: 12px;
  width: 100%;
  text-transform: uppercase;
  left: 240px;
}
#certificate .logo {
  position: absolute;
  top: 380px;
  left: 300px;
}
</style>
