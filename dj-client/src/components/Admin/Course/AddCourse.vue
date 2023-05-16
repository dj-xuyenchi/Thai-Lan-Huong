<template>
  <div>
    <v-form ref="form" @submit.prevent="submit">
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
                      :src="'data:image/jpeg;base64, '"
                      alt=""
                      style="height: 100px; width: 280px"
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
                      :v-model="courseCode"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="8" md="8">
                    <v-text-field
                      label="Tên khóa học"
                      hint="Tên khóa học"
                      required
                      :v-model="courseName"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="4" md="4">
                    <v-text-field
                      label="Tiêu đề phụ khóa học"
                      hint="Tiêu đề phụ khóa học"
                      required
                      :v-model="courseSubTitle"
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
                      counter
                      label="Thời gian học"
                      hint="Thời gian cần bỏ ra để học xong"
                      required
                      :v-model="courseTotalTime"
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
                      :v-model="courseIntro"
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
                type="sendData"
                color="blue-darken-1"
                variant="text"
                @click="sendData"
              >
                Thêm bài tập
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
      </v-row>
    </v-form>
  </div>
</template>

<script>
import AdminAPI from "../../../apis/APIAdmin/AdminAPI.ts";
export default {
  name: "AddCourse",
  data: () => ({
    selectFile: null,
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
  }),
  methods: {
    getData() {
      return {
        lessonName: this.lessonName,
        lessonDescription: this.lessonDescription,
        lessonTime: this.lessonTime,
        problem: this.problem,
        problemDetail: this.problemDetail,
        beginCode: this.beginCode,
        inputExemple: this.inputExemple,
        outputExemple: this.outputExemple,
        explainCode: this.explainCode,
        suggest: this.suggest,
      };
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
};
</script>

<style lang="css" scoped></style>
