<template>
  <div>
    <v-dialog v-model="dialog" persistent width="1024">
      <template v-slot:activator="{ props }">
        <v-btn color="green" v-bind="props" density="compact" icon="mdi-pencil">
        </v-btn>
      </template>
      <v-form @submit.prevent="submit()" ref="form">
        <v-card style="overflow: scroll">
          <v-card-title>
            <span class="text-h5">Cập nhật Vlog</span>
          </v-card-title>
          <v-card-text>
            <v-container>
              <v-row>
                <v-col cols="12" sm="12" md="12">
                  <img
                    :src="(opt ? `data:image/jpeg;base64, ` : ``) + dataImage"
                    alt="Hình ảnh"
                    style="height: 160px; width: 280px"
                  />
                  <v-label style="width: 100%; margin: 24px 0 8px 0"
                    >Ảnh đại diện Vlog</v-label
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
                    style="display: none"
                  ></v-file-input>
                </v-col>
                <v-col cols="12" sm="8" md="8">
                  <v-text-field
                    label="Tiêu đề vlog"
                    hint="Tiêu đề vlog"
                    required
                    v-model="title"
                    :rules="[rules.validValue]"
                  ></v-text-field>
                </v-col>
                <v-col cols="12" sm="8" md="8">
                  <v-text-field
                    label="Link vlog"
                    hint="Link vlog"
                    required
                    v-model="link"
                    :rules="[rules.validValue]"
                  ></v-text-field>
                </v-col>
                <v-col cols="12">
                  <v-switch
                    v-model="isActive"
                    label="Hiển thị"
                    color="secondary"
                    hide-details
                  ></v-switch>
                </v-col>
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
            >
              Cập nhật
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-form>
    </v-dialog>
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
import AdminAPI from "../../../apis/APIAdmin/AdminAPI.ts";
import { mapMutations } from "vuex";
export default {
  name: "BtnUpdateBlog",
  data() {
    return {
      text: "",
      snackbar: false,
      dataImage: "",
      title: "",
      link: "",
      isActive: false,
      btnLoading: false,
      dialog: false,
      opt: false,
      rules: [
        (value) => {
          if (value) return true;
          return "Không được để trống!";
        },
      ],
    };
  },
  methods: {
    async submit() {
      this.btnLoading = true;
      if (this.link.trim().length == 0 || this.title.trim().length == 0) {
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
          Title: this.title,
          Link: this.link,
          Id: this.item.id,
          StatusId: this.isActive ? 1 : 2,
        })
      );
      const result = await AdminAPI.updateBlog(formData, token);
      if (result.data == 1) {
        this.text = "Cập nhật thành công!";
        this.dialog = false;
        this.snackbar = true;
        this.btnLoading = false;
        this.title = "";
        this.link = "";
        this.isActive = false;
        this.getBlogPage();
      }
      if (result.data == 4) {
        this.text = "Cập nhật thất bại!";
        this.snackbar = true;
      }
      this.btnLoading = false;
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
  mounted() {
    this.title = this.item.title;
    this.link = this.item.blogLink;
    this.dataImage = this.item.blogImg;
    this.isActive = this.item.isActive == 1 ? true : false;
  },
  props: {
    getBlogPage: Function,
    item: Object,
  },
  watch: {
    item: {
      immediate: true,
      handler(newItem) {
        this.title = newItem.title;
        this.link = newItem.blogLink;
        this.dataImage = newItem.blogImg;
        this.isActive = newItem.isActive == 1 ? true : false;
      },
    },
  },
};
</script>

<style lang="css" scoped></style>
