<template>
  <div>
    <v-row>
      <v-dialog v-model="dialog" persistent width="1024">
        <template v-slot:activator="{ props }">
          <v-btn
            color="green"
            v-bind="props"
            density="compact"
            icon="mdi-pencil"
          >
          </v-btn>
        </template>
        <v-form @submit.prevent="submit()" ref="form">
          <v-card style="height: 90vh; overflow: scroll">
            <v-card-title>
              <span class="text-h5">Cập nhật bài học thực hành</span>
            </v-card-title>
            <v-card-text>
              <v-container>
                <v-row>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Tên bài học*"
                      hint="Khi hiển thị sẽ là Bài học + tên bài học"
                      v-model="lessonName"
                      :rules="rules"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Mô tả*"
                      hint="Mô tả bài học"
                      :rules="rules"
                      v-model="lessonDescription"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Thời lượng*"
                      hint="Thời lượng của bài học"
                      :rules="rules"
                      v-model="lessonTime"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12">
                    <v-text-field
                      label="Vấn đề*"
                      hint="Vấn đề cần giải quyết"
                      :rules="rules"
                      v-model="problem"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12">
                    <v-text-field
                      label="Mô tả vấn đề*"
                      hint="Mô tả vấn đề cần giải quyết"
                      :rules="rules"
                      v-model="problemDetail"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12">
                    <v-textarea
                      counter
                      label="Code mặc định"
                      hint="Đoạn code mặc định hiển thị lên code field"
                      v-model="beginCode"
                    ></v-textarea>
                  </v-col>
                  <v-col cols="12">
                    <v-text-field
                      counter
                      label="Call Test Code"
                      hint="Mặc định hàm gọi nếu có tham số thì sẽ là tên hàm và (variable)"
                      v-model="callTestCode"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="6">
                    <v-text-field
                      label="Case mặc định giải thích tham số"
                      hint="Giải thích truyền tham số case mặc định"
                      v-model="caseDefaultDetail"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="6">
                    <v-select
                      label="Ngôn ngữ lập trình hiển thị mặc định"
                      :items="listLangue"
                      :rules="rules"
                      v-model="defaultLangue"
                      item-title="langueName"
                      persistent-hint
                      return-object
                      item-value="id"
                    ></v-select>
                  </v-col>
                  <v-col cols="6">
                    <v-text-field
                      label="Đầu vào ví dụ"
                      hint="Input test case ví dụ"
                      v-model="inputExemple"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="6">
                    <v-text-field
                      label="Đầu ra ví dụ*"
                      hint="Output test case ví dụ"
                      :rules="rules"
                      v-model="outputExemple"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12">
                    <v-text-field
                      label="Giải thích*"
                      hint="Giải thích ví dụ"
                      :rules="rules"
                      v-model="explainCode"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12">
                    <v-text-field
                      label="Gợi ý*"
                      hint="Gợi ý bài tập"
                      :rules="rules"
                      v-model="suggest"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12">
                    <v-switch
                      v-model="isSupportMutilLangue"
                      label="Hỗ trợ sử dụng nhiều ngôn ngữ"
                      color="secondary"
                      hide-details
                    ></v-switch>
                  </v-col>
                </v-row>
              </v-container>
              <small
                >* là trường là bắt buộc và chú ý khi update bài thực hành nếu
                cập nhật cách truyền tham số hoặc thay đổi các gọi, trả về cần
                update lại các test case!</small
              >
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
import AdminAPI from "../../../apis/APIAdmin/AdminAPI.ts";
import { mapMutations } from "vuex";
export default {
  name: "BtnUpdatePractice",
  data() {
    return {
      text: "",
      snackbar: false,
      lessonName: "",
      lessonDescription: "",
      lessonTime: "",
      problem: "",
      problemDetail: "",
      beginCode: "",
      caseDefaultDetail: "",
      inputExemple: "",
      callTestCode: "",
      outputExemple: "",
      explainCode: "",
      suggest: "",
      isSupportMutilLangue: false,
      listLangue: null,
      defaultLangue: null,
      btnLoading: false,
      dialog: false,
      rules: [
        (value) => {
          if (value) return true;
          return "Không được để trống!";
        },
      ],
    };
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    getData() {
      return {
        lessonName: this.lessonName,
        lessonDescription: this.lessonDescription,
        lessonTime: this.lessonTime,
        problem: this.problem,
        problemDetail: this.problemDetail,
        beginCode: this.beginCode,
        caseDefaultDetail: this.caseDefaultDetail,
        callTestCode: this.callTestCode,
        inputExemple: this.inputExemple,
        outputExemple: this.outputExemple,
        explainCode: this.explainCode,
        suggest: this.suggest,
        langueId: this.defaultLangue.id,
        isSupportMutilLangue: this.isSupportMutilLangue,
      };
    },
    async getLangueOption() {
      const data = await AdminAPI.getAllLangue(localStorage.getItem("token"));
      this.listLangue = data.data;
    },
    async submit() {
      this.btnLoading = true;
      if (
        this.lessonName.trim().length < 1 ||
        this.lessonDescription.trim().length < 1 ||
        this.lessonTime.trim().length < 1 ||
        this.problemDetail.trim().length < 1 ||
        this.problem.trim().length < 1 ||
        this.outputExemple.trim().length < 1 ||
        this.explainCode.trim().length < 1 ||
        this.suggest.trim().length < 1
      ) {
        this.btnLoading = false;
        return;
      }
      const token = localStorage.getItem("token");
      const result = await AdminAPI.updatePracticeLesson(
        this.lessonId,
        this.getData(),
        token
      );
      if (result.status == 1) {
        this.text = "Cập nhật thành công";
        this.dialog = false;
        this.snackbar = true;
        this.getLessonDetail();
      }
      if (result.status == 2) {
        this.text = "cập nhật thất bại";
        this.snackbar = true;
      }
      this.btnLoading = false;
    },
  },
  mounted() {
    this.lessonName = this.item.lessonName;
    this.lessonDescription = this.item.lessonDescription;
    this.lessonTime = this.item.videoTime;
    this.problem = this.item.problem;
    this.problemDetail = this.item.problemDetail;
    this.beginCode = this.item.beginCode;
    this.caseDefaultDetail = this.item.caseDefaultDetail;
    this.callTestCode = this.item.callTestCode;
    this.inputExemple = this.item.inputExemple;
    this.outputExemple = this.item.outputExemple;
    this.explainCode = this.item.explainCode;
    this.suggest = this.item.suggest;
    this.isSupportMutilLangue = this.item.isSupportMultiLangue;
    this.defaultLangue = this.item.langue;
  },
  props: {
    getLessonDetail: Function,
    item: Object,
    lessonId: Number,
  },
  created() {
    this.getLangueOption();
  },
  watch: {
    item: {
      immediate: true,
      handler(newItem) {
        this.lessonName = newItem.lessonName;
        this.lessonDescription = newItem.lessonDescription;
        this.lessonTime = newItem.videoTime;
        this.problem = newItem.problem;
        this.problemDetail = newItem.problemDetail;
        this.beginCode = newItem.beginCode;
        this.caseDefaultDetail = newItem.caseDefaultDetail;
        this.callTestCode = newItem.callTestCode;
        this.inputExemple = newItem.inputExemple;
        this.outputExemple = newItem.outputExemple;
        this.explainCode = newItem.explainCode;
        this.suggest = newItem.suggest;
        this.isSupportMutilLangue = newItem.isSupportMultiLangue;
        this.defaultLangue = newItem.langue;
      },
    },
  },
};
</script>

<style lang="css" scoped></style>
