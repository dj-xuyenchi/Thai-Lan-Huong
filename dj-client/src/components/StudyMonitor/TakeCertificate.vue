<template>
  <div class="course-detail-container">
    <div class="course-detail-left">
      <div class="detail-header">
        <h1 style="font-weight: 700; font-size: 30px">Hahahaha</h1>
        <h5 style="font-weight: 400">HIHIH</h5>
      </div>
      <div id="certificate">áddsa</div>
      <v-btn @click="generatePDF()">Tải xuống</v-btn>
    </div>
  </div>
</template>

<script>
import html2pdf from "html2pdf.js";
export default {
  mounted() {
    this.generatePDF();
  },
  methods: {
    generatePDF() {
      const element = document.getElementById("certificate"); // ID của phần tử HTML chứa nội dung muốn chuyển đổi thành PDF

      const options = {
        filename: "certificate.pdf",
        image: { type: "jpeg", quality: 0.98 }, // Tuỳ chọn hình ảnh nếu cần
        html2canvas: {}, // Tuỳ chọn html2canvas nếu cần
        jsPDF: { format: "a4", orientation: "landscape" }, // Tuỳ chọn jsPDF nếu cần
      };

      html2pdf().set(options).from(element).save();
    },
  },
};
</script>

<style lang="css" scoped>
.course-detail-container {
  width: 95%;
  margin-left: 2.5%;
  min-height: 80vh;
}
.course-detail-container .course-detail-left {
  display: block;
  float: left;
  width: 65%;
}
</style>
