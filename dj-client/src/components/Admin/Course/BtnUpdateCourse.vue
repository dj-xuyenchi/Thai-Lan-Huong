<template>
  <div>
    <v-form @submit.prevent="submit()" ref="form" enctype="multipart/form-data">
      <v-row>
        <v-dialog v-model="dialog" persistent width="1024">
          <template v-slot:activator="{ props }">
            <v-btn
              color="green"
              density="compact"
              v-bind="{ props }"
              @click="dialog = true"
              icon="mdi-pencil"
            >
            </v-btn>
          </template>
          <v-card style="overflow: scroll">
            <v-card-title>
              <span class="text-h5">Cập nhật khóa học</span>
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
                      >Ảnh đại diện của bạn</v-label
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
                  <v-col cols="12" sm="4" md="4">
                    <v-text-field
                      label="Số lượng học phần"
                      hint="Số lượng học phần"
                      required
                      v-model="chapterCount"
                      :rules="[rules.validValue, rules.validNumber]"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="4" md="4">
                    <v-text-field
                      label="Số bài lượng bài học"
                      hint="Số bài lượng bài học"
                      required
                      v-model="lessonCount"
                      :rules="[rules.validValue, rules.validNumber]"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="4" md="4">
                    <v-select
                      label="Trạng thái khóa học"
                      :items="optionStatus"
                      :rules="rules"
                      v-model="courseStatus"
                      item-title="courseStatusName"
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
                  <v-col cols="12" sm="4" md="4">
                    <v-text-field
                      label="Số người đăng ký khóa học"
                      hint="Số người đăng ký khóa học"
                      required
                      v-model="registerCount"
                      :rules="[rules.validValue, rules.validNumber]"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="4" md="4">
                    <v-text-field
                      label="Số học viên đã hoàn thành"
                      hint="Sỗ học viên đã hoàn thành khóa học"
                      required
                      v-model="doneCount"
                      :rules="[rules.validValue, rules.validNumber]"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12">
                    <v-text-field
                      label="Link video giới thiệu"
                      hint="Link video giới thiệu khóa học chỉ hiển thị khi là link embed api youtube"
                      required
                      v-model="linkVideoIntro"
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
                Cập nhật
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
  name: "BtnUpdateCourse",
  data: () => ({
    selectFile: null,
    dataImage: null,
    courseCode: null,
    courseName: null,
    courseSubTitle: null,
    courseLevel: null,
    courseTotalTime: null,
    chapterCount: null,
    courseStatus: null,
    lessonCount: null,
    courseType: null,
    registerCount: null,
    doneCount: null,
    linkVideoIntro: null,
    optionLevel: [],
    optionType: [],
    optionStatus: [],
    typeId: "",
    levelId: "",
    statusId: "",
    courseId: "",
    dialog: false,
    btnLoading: false,
    text: "",
    snackbar: false,
    opt: false,
    rules: {
      validValue: (value) =>
        value.trim().length > 0 || "Không được để trống thông tin này!",
      validNumber: (value) =>
        /^(0|[1-9][0-9]*)$/.test(value.trim()) ||
        "Giá trị phải là số và lớn hơn 0!",
    },
  }),
  methods: {
    getData() {
      return {
        id: this.item.courseId,
        courseCode: this.courseCode.trim(),
        courseName: this.courseName.trim(),
        courseSubTitle: this.courseSubTitle.trim(),
        levelId:
          typeof this.courseLevel == "string"
            ? this.levelId
            : this.courseLevel.id,
        totalTime: this.courseTotalTime.trim(),
        typeId:
          typeof this.courseType == "string" ? this.typeId : this.courseType.id,
        introVideoLink: this.linkVideoIntro,
        statusId:
          typeof this.courseStatus == "string"
            ? this.statusId
            : this.courseStatus.id,
        doneCount: this.doneCount,
        resigterCount: this.registerCount,
        lessonCount: this.lessonCount,
        chapterCount: this.chapterCount,
      };
    },
    async submit() {
      this.btnLoading = true;
      if (
        this.courseCode.trim().length == 0 ||
        this.courseName.trim().length == 0 ||
        this.courseSubTitle.trim().length == 0 ||
        this.linkVideoIntro.trim().length == 0 ||
        this.courseTotalTime.trim().length == 0 ||
        this.doneCount.length == 0 ||
        this.registerCount.length == 0 ||
        this.lessonCount.length == 0 ||
        this.chapterCount.length == 0
      ) {
        this.text = "Không được để trông thông tin!";
        this.snackbar = true;
        this.btnLoading = false;
        return;
      }
      if (
        !/^(0|[1-9][0-9]*)$/.test(this.doneCount) ||
        !/^(0|[1-9][0-9]*)$/.test(this.registerCount) ||
        !/^(0|[1-9][0-9]*)$/.test(this.lessonCount) ||
        !/^(0|[1-9][0-9]*)$/.test(this.chapterCount)
      ) {
        this.text = "Chưa đúng định dạng!";
        this.snackbar = true;
        this.btnLoading = false;
        return;
      }
      const token = localStorage.getItem("token");
      const formData = new FormData();
      formData.append("img", this.selectFile ? this.selectFile[0] : null);
      formData.append("data", JSON.stringify(this.getData()));
      const result = await AdminAPI.updateCourse(formData, token);
      if (result.data == 1) {
        this.text = "Cập nhật khóa học thành công!";
        this.dialog = false;
        this.snackbar = true;
        this.btnLoading = false;
        this.getCoursePage();
      }
      if (result.data == 4) {
        this.text = "Cập nhật khóa học thất bại!";
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
      this.optionStatus = result.data.status;
    },
  },
  mounted() {
    this.getOption();
    this.courseCode = this.item.courseCode;
    this.courseName = this.item.courseName;
    this.courseTotalTime = this.item.timeLessonTotal;
    this.courseSubTitle = this.item.courseSubTitle;
    this.courseLevel = this.item.courseLevel;
    this.courseType = this.item.courseType;
    this.chapterCount = this.item.chapterCount;
    this.courseStatus = this.item.courseStatus;
    this.registerCount = this.item.registerCount;
    this.doneCount = this.item.doneCount;
    this.lessonCount = this.item.lessonCount;
    this.linkVideoIntro = this.item.linkVideoIntro;
    this.typeId = this.item.courseTypeId;
    this.levelId = this.item.courseLevelId;
    this.statusId = this.item.courseStatusId;
    this.courseId = this.item.courseId;
    this.dataImage = this.item.courseImageData;
  },
  props: {
    item: Object,
    getCoursePage: Function,
  },
  watch: {
    item: {
      immediate: true,
      handler(newItem) {
        this.courseCode = newItem.courseCode;
        this.courseName = newItem.courseName;
        this.courseTotalTime = newItem.timeLessonTotal;
        this.courseSubTitle = newItem.courseSubTitle;
        this.courseLevel = newItem.courseLevel;
        this.courseType = newItem.courseType;
        this.chapterCount = newItem.chapterCount;
        this.courseStatus = newItem.courseStatus;
        this.registerCount = newItem.registerCount;
        this.doneCount = newItem.doneCount;
        this.lessonCount = newItem.lessonCount;
        this.linkVideoIntro = newItem.linkVideoIntro;
        this.typeId = newItem.courseTypeId;
        this.levelId = newItem.courseLevelId;
        this.statusId = newItem.courseStatusId;
        this.courseId = newItem.courseId;
        this.dataImage = newItem.courseImageData;
      },
    },
  },
};
</script>

<style lang="css" scoped></style>
