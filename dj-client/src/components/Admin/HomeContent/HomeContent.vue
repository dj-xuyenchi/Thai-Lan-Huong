<template>
  <div style="margin-bottom: 80px">
    <v-form @submit.prevent="submit()" ref="form">
      <div>
        <v-carousel
          class="container rounded-xl"
          cycle
          hide-delimiter-background
          show-arrows="hover"
          height="86vh"
        >
          <v-carousel-item v-for="(slide1, i) in slides" :key="i">
            <v-sheet height="100%" width="100%">
              <div class="d-flex fill-height justify-center align-center">
                <img :src="slide[i]" alt="" style="width: 100%" />
              </div>
            </v-sheet>
          </v-carousel-item>
        </v-carousel>
        <h4 style="margin: 18px 0 12px 0">Danh sách slide</h4>
        <v-row>
          <v-col cols="4" sm="4" md="4">
            <h5>Slide 1</h5>
            <img
              :src="
                opt[0] ? `data:image/jpeg;base64, ` + dataImage[0] : slide[0]
              "
              alt="Hình ảnh"
              style="width: 100%; height: 200px; border-radius: 15px"
            />
            <v-btn
              color="#4d96ff"
              style="
                height: 35px;
                width: 104px;
                font-size: 14px;
                font-weight: 400;
              "
              @click="$refs.fileInput0.click()"
            >
              Chọn ảnh</v-btn
            >
            <v-file-input
              ref="fileInput0"
              v-model="selectFile[0]"
              accept="image/*"
              @change="onFileSelect(0)"
              outlined
              dense
              hide-details
              style="display: none"
            ></v-file-input>
          </v-col>

          <v-col cols="4" sm="4" md="4">
            <h5>Slide 2</h5>
            <img
              :src="
                opt[1] ? `data:image/jpeg;base64, ` + dataImage[1] : slide[1]
              "
              alt="Hình ảnh"
              style="width: 100%; height: 200px; border-radius: 15px"
            />
            <v-btn
              color="#4d96ff"
              style="
                height: 35px;
                width: 104px;
                font-size: 14px;
                font-weight: 400;
              "
              @click="$refs.fileInput1.click()"
            >
              Chọn ảnh</v-btn
            >
            <v-file-input
              ref="fileInput1"
              v-model="selectFile[1]"
              accept="image/*"
              @change="onFileSelect(1)"
              outlined
              dense
              hide-details
              style="display: none"
            ></v-file-input>
          </v-col>

          <v-col cols="4" sm="4" md="4">
            <h5>Slide 3</h5>
            <img
              :src="
                opt[2] ? `data:image/jpeg;base64, ` + dataImage[2] : slide[2]
              "
              alt="Hình ảnh"
              style="width: 100%; height: 200px; border-radius: 15px"
            />
            <v-btn
              color="#4d96ff"
              style="
                height: 35px;
                width: 104px;
                font-size: 14px;
                font-weight: 400;
              "
              @click="$refs.fileInput2.click()"
            >
              Chọn ảnh</v-btn
            >
            <v-file-input
              ref="fileInput2"
              v-model="selectFile[2]"
              accept="image/*"
              @change="onFileSelect(2)"
              outlined
              dense
              hide-details
              style="display: none"
            ></v-file-input>
          </v-col>

          <v-col cols="4" sm="4" md="4">
            <h5>Slide 4</h5>
            <img
              :src="
                opt[3] ? `data:image/jpeg;base64, ` + dataImage[3] : slide[3]
              "
              alt="Hình ảnh"
              style="width: 100%; height: 200px; border-radius: 15px"
            />
            <v-btn
              color="#4d96ff"
              style="
                height: 35px;
                width: 104px;
                font-size: 14px;
                font-weight: 400;
              "
              @click="$refs.fileInput3.click()"
            >
              Chọn ảnh</v-btn
            >
            <v-file-input
              ref="fileInput3"
              v-model="selectFile[3]"
              accept="image/*"
              @change="onFileSelect(3)"
              outlined
              dense
              hide-details
              style="display: none"
            ></v-file-input>
          </v-col>

          <v-col cols="4" sm="4" md="4">
            <h5>Slide 5</h5>
            <img
              :src="
                opt[4] ? `data:image/jpeg;base64, ` + dataImage[4] : slide[4]
              "
              alt="Hình ảnh"
              style="width: 100%; height: 200px; border-radius: 15px"
            />
            <v-btn
              color="#4d96ff"
              style="
                height: 35px;
                width: 104px;
                font-size: 14px;
                font-weight: 400;
              "
              @click="$refs.fileInput4.click()"
            >
              Chọn ảnh</v-btn
            >
            <v-file-input
              ref="fileInput4"
              v-model="selectFile[4]"
              accept="image/*"
              @change="onFileSelect(4)"
              outlined
              dense
              hide-details
              style="display: none"
            ></v-file-input>
          </v-col>
        </v-row>
      </div>
      <v-btn
        style="margin-top: 24px"
        color="blue-darken-1"
        :loading="btnLoading"
        variant="text"
        type="submit"
        @click="submit()"
      >
        Cập nhật
      </v-btn>
    </v-form>
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
import AdminAPI from "../../../apis/APIAdmin/AdminAPI";
import { mapMutations } from "vuex";
export default {
  data() {
    return {
      slides: ["First", "Second", "Third", "Fourth", "Fifth"],
      slide: [],
      selectFile: [null, null, null, null, null],
      opt: [false, false, false, false, false],
      dataImage: [null, null, null, null, null],
      text: "",
      change: false,
      snackbar: false,
      btnLoading: false,
    };
  },
  created() {
    this.getHomeSlide();
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    async getHomeSlide() {
      this.setIsLoadedData(true);
      const token = localStorage.getItem("token");
      const data = await AdminAPI.getHomeContent(token);
      this.slide.push(data.data.slide1);
      this.slide.push(data.data.slide2);
      this.slide.push(data.data.slide3);
      this.slide.push(data.data.slide4);
      this.slide.push(data.data.slide5);
      this.setIsLoadedData(false);
    },
    onFileSelect(index) {
      if (
        this.selectFile[index][0].type == "image/png" ||
        this.selectFile[index][0].type == "image/jpeg" ||
        this.selectFile[index][0].type == "image/jpg"
      ) {
        if (this.selectFile[index][0].size > 2048576) {
          this.text = "File quá nặng chỉ hỗ trợ file dung lượng < 1MB";
          this.snackbar = true;
          return;
        }
        const reader = new FileReader();
        reader.onload = () => {
          this.dataImage[index] = reader.result.split(",")[1];
        };
        reader.readAsDataURL(this.selectFile[index][0]);
        this.opt[index] = true;
        this.change = true;
      } else {
        this.text =
          "Vui lòng chọn đúng file định dạng ảnh! Các định dạng được hỗ trợ: JPG, JPEG, PNG";
        this.snackbar = true;
        return;
      }
    },
    async submit() {
      this.btnLoading = true;
      if (!this.change) {
        this.text = "Chưa có thay đổi nào được ghi nhận!";
        this.snackbar = true;
        this.btnLoading = false;
        return;
      }
      const token = localStorage.getItem("token");
      const formData = new FormData();
      formData.append(
        "slide1",
        this.selectFile[0] ? this.selectFile[0][0] : null
      );
      formData.append(
        "slide2",
        this.selectFile[1] ? this.selectFile[1][0] : null
      );
      formData.append(
        "slide3",
        this.selectFile[2] ? this.selectFile[2][0] : null
      );
      formData.append(
        "slide4",
        this.selectFile[3] ? this.selectFile[3][0] : null
      );
      formData.append(
        "slide5",
        this.selectFile[4] ? this.selectFile[4][0] : null
      );
      const result = await AdminAPI.changeSlide(formData, token);
      if (result.data == 1) {
        this.text = "Thành công!";
        this.snackbar = true;
        this.getHomeSlide();
      }
      this.btnLoading = false;
    },
  },
};
</script>

<style lang="scss" scoped></style>
