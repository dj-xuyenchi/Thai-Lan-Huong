<template>
  <div>
    <v-row>
      <!-- <v-dialog v-model="dialog" persistent width="1024"> -->
      <!-- <template v-slot:activator="{ props }">
          <v-btn color="primary" v-bind="props"> Thêm bài học thực hành</v-btn>
        </template> -->
      <v-form @submit.prevent="submit()" ref="form">
        <v-card style="height: 90vh; overflow: scroll; width: 1024px">
          <v-card-title>
            <span class="text-h5">Thêm bài học thực hành</span>
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
                    hint="Sẽ hiển thị trong bài Title lớn"
                    :rules="rules"
                    v-model="problem"
                  ></v-text-field>
                </v-col>
                <v-col cols="12">
                  <v-text-field
                    label="Mô tả vấn đề*"
                    hint="Sub title hiển thị phía dưới"
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
                <v-col cols="12">
                  <v-textarea
                    counter
                    label="Giải thích*"
                    hint="Giải thích ví dụ"
                    v-model="explainCode"
                  ></v-textarea>
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
            <small>* là trường là bắt buộc!</small>
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn
              color="blue-darken-1"
              variant="text"
              @click="setDialogOff(3)"
            >
              Hủy
            </v-btn>
            <v-btn
              color="blue-darken-1"
              :loading="btnLoading"
              variant="text"
              type="submit"
            >
              Thêm bài tập
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-form>
      <!-- </v-dialog> -->
    </v-row>
  </div>
</template>

<script>
import AdminAPI from "../../../apis/APIAdmin/AdminAPI.ts";
import { mapMutations } from "vuex";
export default {
  name: "AddPractice",
  data() {
    return {
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
      dialog: false,
      btnLoading: false,
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
        this.suggest.trim().length < 1 ||
        !this.defaultLangue
      ) {
        this.btnLoading = false;
        return;
      }
      const token = localStorage.getItem("token");
      const result = await AdminAPI.addPracticeLesson(this.getData(), token);
      if (result.data.status == 1) {
        this.dialog = false;
        this.lessonName = "";
        this.isSupportMutilLangue = false;
        this.defaultLangue = null;
        this.lessonDescription = "";
        this.lessonTime = "";
        this.problem = "";
        this.problemDetail = "";
        this.beginCode = "";
        this.caseDefaultDetail = "";
        this.callTestCode = "";
        this.inputExemple = "";
        this.outputExemple = "";
        this.explainCode = "";
        this.suggest = "";
        this.getLessonDetail();
        this.setDialogOff(1);
      }
      if (result.data.status == 2) {
        this.setDialogOff(2);
      }
      this.btnLoading = false;
    },
  },
  props: {
    getLessonDetail: Function,
    setDialogOff: Function,
  },
  created() {
    this.getLangueOption();
  },
};
</script>

<style lang="css" scoped></style>
