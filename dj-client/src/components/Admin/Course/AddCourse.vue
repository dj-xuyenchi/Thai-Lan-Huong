<template>
  <div>
    <v-form @submit.prevent="submit()" ref="form" enctype="multipart/form-data">
      <v-row>
        <v-dialog v-model="dialog" persistent width="1024">
          <template v-slot:activator="{ props }">
            <v-btn color="primary" v-bind="props"> Thêm khóa học</v-btn>
          </template>

          <v-card>
            <v-card-title>
              <span class="text-h5">Thêm khóa học</span>
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
                      >Ảnh đại diện khóa học</v-label
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
                  <v-col cols="12" sm="4" md="4">
                    <v-text-field
                      label="Khóa học Code"
                      hint="Khóa học Code"
                      required
                      v-model="courseCode"
                      :rules="[rules.validValue]"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="8" md="8">
                    <v-text-field
                      label="Tên khóa học"
                      hint="Tên khóa học"
                      required
                      v-model="courseName"
                      :rules="[rules.validValue]"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="4" md="4">
                    <v-text-field
                      label="Tiêu đề phụ khóa học"
                      hint="Tiêu đề phụ khóa học"
                      required
                      v-model="courseSubTitle"
                      :rules="[rules.validValue]"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="4" md="4">
                    <v-select
                      label="Độ khó"
                      :items="optionLevel"
                      :rules="rules"
                      v-model="courseLevel"
                      item-title="levelName"
                      persistent-hint
                      return-object
                      item-value="id"
                    ></v-select>
                  </v-col>
                  <v-col cols="12" sm="4" md="4">
                    <v-text-field
                      label="Thời gian học"
                      hint="Thời gian cần bỏ ra để học xong"
                      required
                      v-model="courseTotalTime"
                      :rules="[rules.validValue]"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="6">
                    <v-select
                      label="Dạng khóa học"
                      :items="optionType"
                      :rules="rules"
                      v-model="courseType"
                      item-title="courseTypeName"
                      persistent-hint
                      return-object
                      item-value="id"
                    ></v-select>
                  </v-col>
                  <v-col cols="12">
                    <v-text-field
                      label="Link video giới thiệu"
                      hint="Link video giới thiệu khóa học"
                      required
                      v-model="courseIntro"
                      :rules="[rules.validValue]"
                    ></v-text-field>
                  </v-col>
                </v-row>
              </v-container>
              <small>Tất cả các trường là bắt buộc!</small>
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
                @click="submit()"
              >
                Thêm khóa học
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
      </v-row>
    </v-form>
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
import AdminAPI from "../../../apis/APIAdmin/AdminAPI";
export default {
  name: "AddCourse",
  data: () => ({
    selectFile: null,
    dataImage: "",
    courseCode: "",
    courseName: "",
    courseSubTitle: "",
    courseLevel: "",
    courseTotalTime: "",
    courseType: "",
    courseIntro: "",
    optionLevel: [],
    optionType: [],
    dialog: false,
    btnLoading: false,
    text: "",
    snackbar: false,
    opt: false,
    rules: {
      validValue: (value) =>
        value.trim().length > 0 || "Không được để trống thông tin này!",
    },
  }),
  methods: {
    getData() {
      return {
        courseCode: this.courseCode,
        courseName: this.courseName,
        courseSubTitle: this.courseSubTitle,
        levelId: this.courseLevel.id,
        totalTime: this.courseTotalTime,
        typeId: this.courseType.id,
        introVideoLink: this.courseIntro,
      };
    },
    async submit() {
      this.btnLoading = true;
      if (
        this.courseCode.trim().length == 0 ||
        this.courseName.trim().length == 0 ||
        this.courseSubTitle.trim().length == 0 ||
        this.courseIntro.trim().length == 0 ||
        this.courseTotalTime.trim().length == 0 ||
        this.selectFile == null
      ) {
        this.text = "Không được để trông thông tin!";
        this.snackbar = true;
        this.btnLoading = false;
        return;
      }
      const token = localStorage.getItem("token");
      const formData = new FormData();
      formData.append("img", this.selectFile ? this.selectFile[0] : null);
      formData.append("data", JSON.stringify(this.getData()));
      const result = await AdminAPI.addCourse(formData, token);
      if (result.data == 1) {
        this.text = "Thêm khóa học thành công!";
        this.dialog = false;
        this.snackbar = true;
        this.btnLoading = false;
        this.courseCode = "";
        this.courseName = "";
        this.courseTotalTime = "";
        this.courseSubTitle = "";
        this.courseLevel = "";
        this.courseType = "";
        this.chapterCount = "";
        this.courseStatus = "";
        this.registerCount = "";
        this.doneCount = "";
        this.lessonCount = "";
        this.linkVideoIntro = "";
        this.typeId = "";
        this.levelId = "";
        this.statusId = "";
        this.courseId = "";
        this.courseIntro = "";
        this.dataImage = "";
        this.getCoursePage();
      }
      if (result.data == 4) {
        this.text = "Thêm khóa học thất bại!";
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
    async getOption() {
      const result = await AdminAPI.getOptionAddCourse(
        localStorage.getItem("token")
      );
      this.optionLevel = result.data.level;
      this.optionType = result.data.type;
    },
  },
  mounted() {
    this.getOption();
  },
  props: {
    getCoursePage: Function,
  },
};
</script>

<style lang="css" scoped></style>
