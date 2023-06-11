<template>
  <div style="width: 60%; margin-left: 5%; min-height: 80vh">
    <img
      :src="(opt ? `data:image/jpeg;base64, ` : ``) + dataImage"
      alt="Hình ảnh"
      style="height: 160px; width: 280px"
    />
    <v-label style="width: 100%; margin: 24px 0 8px 0"
      >Ảnh đại diện bài viết</v-label
    >
    <v-btn
      color="#4d96ff"
      style="height: 35px; width: 104px; font-size: 14px; font-weight: 400"
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
      style="display: none"
    ></v-file-input>
    <v-text-field
      label="Tiêu đề bài viết"
      hint="Tiêu đề bài viết"
      required
      variant="outlined"
      v-model="title"
      :rules="[rules.validValue]"
      style="margin-top: 40px"
    ></v-text-field>
    <v-text-field
      label="Mô tả bài viết"
      hint="SEO meta"
      required
      variant="outlined"
      v-model="des"
      :rules="[rules.validValue]"
      style="margin-top: 40px"
    ></v-text-field>
    <div style="white-space: pre-line" v-html="renderedHTML"></div>
    <v-btn
      @click="createPost()"
      variant="text"
      style="margin-bottom: 8px"
      color="red"
    >
      Xuất bản
    </v-btn>
    <v-btn
      @click="updatePost()"
      variant="text"
      style="margin-bottom: 8px"
      color="red"
    >
      Sửa lại
    </v-btn>
    <v-btn
      @click="deleteWaitPost()"
      variant="text"
      style="margin-bottom: 8px"
      color="red"
    >
      Hủy bài viết
    </v-btn>
    <v-snackbar v-model="snackbar">
      {{ text }}
      <template v-slot:actions>
        <v-btn color="green" variant="text" @click="snackbar = false">
          Đóng
        </v-btn>
      </template>
    </v-snackbar>
  </div>
</template>

<script>
import MarkdownIt from "markdown-it";
import { holdingImg } from "./file.ts";
import { mapMutations } from "vuex";
import VMdEditor from "@kangc/v-md-editor";
import UserAPI from "../../apis/APIUser/UserAPI.ts";
export default {
  data() {
    return {
      renderedHTML: "",
      selectFile: null,
      beforeRender: "",
      dataImage: "",
      text: "",
      opt: false,
      title: "",
      des: "",
      imgLink: "",
      btnLoading: false,
      snackbar: false,
      rules: {
        validValue: (value) =>
          value.trim().length > 0 || "Không được để trống thông tin này!",
      },
    };
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    async createPost() {
      this.btnLoading = true;
      if (
        this.title.trim().length == 0 ||
        this.des.trim().length == 0 ||
        this.selectFile === null
      ) {
        this.text = "Không được để trông thông tin!";
        this.snackbar = true;
        this.btnLoading = false;
        return;
      }
      const token = localStorage.getItem("token");
      const formData = new FormData();
      formData.append("img", this.selectFile ? this.selectFile[0] : null);
      formData.append(
        "data",
        JSON.stringify({
          title: this.title,
          des: this.des,
          imgLink: this.imgLink,
        })
      );
      formData.append("userId", localStorage.getItem("id"));
      const result = await UserAPI.confirmPost(formData, token);
      if (result.data == 1) {
        this.text = "Tạo bài viết thành công vui lòng chờ kiểm duyệt!";
        this.dialog = false;
        this.$router.push({ path: `/home/my-post` });
      }
      if (result.data == 4) {
        this.text = "Tạo bài viết thất bại!";
        this.snackbar = true;
      }
      this.btnLoading = false;
    },
    async getWaitPost() {
      this.setIsLoadedData(true);
      const data = await UserAPI.getWaitPost(
        localStorage.getItem("id"),
        localStorage.getItem("token")
      );
      if (data.data == null) {
        this.setIsLoadedData(false);
        return;
      }
      this.renderedHTML = data.data;
      this.beforeRender = data.data;
      const md = new MarkdownIt();
      const htmlContent = md.render(this.renderedHTML);
      this.renderedHTML = htmlContent;
      this.setIsLoadedData(false);
    },
    async deleteWaitPost() {
      this.setIsLoadedData(true);
      const data = await UserAPI.deleteWaitPost(
        localStorage.getItem("id"),
        localStorage.getItem("token")
      );
      if (data.data == 4) {
        this.text = "Không tồn tại bài đăng";
        this.snackbar = true;
        this.setIsLoadedData(false);
        return;
      }
      if (data.data == 1) {
        this.text = "Xóa thành công";
        this.snackbar = true;
        this.setIsLoadedData(false);
        this.$router.push({ path: `/home/lobby` });
        return;
      }
    },
    updatePost() {
      localStorage.setItem("post_data", this.beforeRender);
      this.$router.push({ path: `/home/create-post` });
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
          this.dataImage = reader.result.split(",")[1];
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
  },
  created() {
    this.getWaitPost();
    this.dataImage = holdingImg;
  },
};
</script>

<style lang="css" scoped></style>
