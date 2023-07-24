<template>
  <div>
    <v-row>
      <v-dialog v-model="dialog" persistent width="80vw">
        <template v-slot:activator="{ props }">
          <v-btn
            color="green"
            v-bind="props"
            density="compact"
            icon="mdi-pencil"
          >
          </v-btn>
        </template>
        <v-form @submit.prevent="submit()" ref="form" style="overflow: scroll">
          <v-card>
            <v-card-title>
              <span class="text-h5">Cập nhật bài viết</span>
            </v-card-title>
            <v-card-text>
              <v-container>
                <v-row>
                  <v-col cols="12" sm="12" md="12">
                    <v-text-field
                      v-model="title"
                      density="compact"
                      label="Tiêu đề bài viết*"
                      hint="Tiêu đề bài viết"
                      variant="outlined"
                      type="text"
                      :rules="[rules.validValue]"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="12" md="12">
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
                  <v-col cols="12" sm="12" md="12">
                    <v-md-editor v-model="content"></v-md-editor>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-select
                      v-model="opt2"
                      label="Trạng thái bài viết*"
                      :items="listOpt"
                      item-title="postStatusName"
                      persistent-hint
                      return-object
                      item-value="id"
                      variant="outlined"
                    ></v-select>
                  </v-col>
                </v-row>
              </v-container>
              <small>* là trường là bắt buộc. !</small>
            </v-card-text>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn
                color="blue-darken-1"
                variant="text"
                @click="dialog = false"
              >
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
    </v-row>
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
import MarkdownIt from "markdown-it";
import AdminAPI from "../../../apis/APIAdmin/AdminAPI.ts";
import { mapMutations } from "vuex";
export default {
  name: "BtnPreviewPost",
  created() {
    this.listOpt = this.option;
    this.opt2 = this.item.postStatus;
    this.content = this.item.postData;
    this.dataImage = this.item.postAvatar;
    this.title = this.item.postTitle;
  },
  data() {
    return {
      text: "",
      title: "",
      dataImage: "",
      selectFile: null,
      opt: false,
      opt2: { name: "Cho phép", id: 1 },
      listOpt: [],
      content: "",
      renderedHTML: "",
      renderedHTMLData: "",
      snackbar: false,
      dialog: false,
      btnLoading: false,
      rules: {
        validName: (value) =>
          !/[@#$%^&+=!]/.test(value) || "Tên chứa ký tự không hợp lệ",
        sdt: (value) => /^\+?\d{1,3}\s?\d{9,}$/.test(value) || "SDT chưa đúng",
        validValue: (value) =>
          value.trim().length > 0 || "Không được để trống thông tin này!",
        email: (value) => value.includes("@") || "Email chưa đúng",
      },
    };
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    async submit() {
      this.btnLoading = true;
      if (this.title.trim().length <= 0) {
        this.text = "Tiêu đề bài viết không được để trống!";
        this.snackbar = true;
        this.dialog = false;
        this.btnLoading = false;
        return;
      }
      const token = localStorage.getItem("token");
      const formData = new FormData();
      formData.append("img", this.selectFile ? this.selectFile[0] : null);
      formData.append(
        "data",
        JSON.stringify({
          PostId: this.item.id,
          PostData: this.content,
          PostTitle: this.title,
          PostStatusId: this.opt2.id,
        })
      );
      const result = await AdminAPI.updatePostAdmin(formData, token);
      if (result.data == 1) {
        this.text = "Cập nhật thành công";
        this.dialog = false;
        this.snackbar = true;
        this.getPostAdmin();
      }
      if (result.data == 4) {
        this.text = "Không tồn tại";
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
  props: {
    getPostAdmin: Function,
    item: Object,
    option: [],
  },
  watch: {
    item: {
      immediate: true,
      handler(newItem) {
        this.opt2 = newItem.postStatus;
        this.content = newItem.postData;
        this.dataImage = newItem.postAvatar;
        this.title = newItem.postTitle;
      },
    },
  },
};
</script>

<style lang="css" scoped></style>
