<template>
  <div>
    <v-row>
      <v-dialog v-model="dialog" persistent width="1024">
        <v-form @submit.prevent="submit()" ref="form">
          <v-card style="height: 90vh; overflow: scroll">
            <v-card-title>
              <span class="text-h5">Review tư vấn</span>
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
                </v-row>
              </v-container>
              <small>* là trường là bắt buộc!</small>
            </v-card-text>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn
                color="blue-darken-1"
                variant="text"
                @click="
                  dialog = false;
                  setShow(false);
                "
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
  name: "GenPracticeGPT",
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
      dialog: true,
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
      };
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
      const result = await AdminAPI.addPracticeLesson(this.getData(), token);
      if (result.status == 1) {
        this.text = "Thêm thành công";
        this.dialog = false;
        this.snackbar = true;
        this.lessonName = "";
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
      }
      if (result.status == 2) {
        this.text = "Thêm thất bại";
        this.snackbar = true;
      }
      this.btnLoading = false;
    },
    fixString(str) {
      str = str.replace("tenBai", `"tenBai"`);
      str = str.replace("practiceLesson", `"practiceLesson"`);
      str = str.replace("problem", `"problem"`);
      str = str.replace("problemDetail", `"problemDetail"`);
      str = str.replace("codeBegin", `"codeBegin"`);
      str = str.replace("explain", `"explain"`);
      str = str.replace("suggest", `"suggest"`);

      str = str.replace("testCases", `"testCases"`);

      while (str.includes("\n") || str.includes("\t") || str.includes("`")) {
        str = str.replace("\n", "");
        str = str.replace("\t", "");
        str = str.replace("'", `"`);
      }
      str = str.substring(0, str.indexOf(`"testCases`));
      for (var i = str.length; i >= 0; i--) {
        if (str[i] == ",") {
          str = str.substring(0, i) + "}}";
          break;
        }
      }
      return str;
    },
    fixTestCase(str) {
      str = str.replace("testCases", `"testCases"`);
      while (str.includes("\n") || str.includes("\t")) {
        str = str.replace("\n", "");
        str = str.replace("\t", "");
      }
      while (str.includes("input:") || str.includes("output:")) {
        str = str.replace("input:", `"input":"`);
        str = str.replace("output:", `"output":"`);
      }
      str = str.replaceAll("}", `"}`);
      str = str.replaceAll(",", `",`);
      str = str.replaceAll(`}",`, `},`);
      str = str.replaceAll(`""`, `"`);
      str = str.replaceAll(`"",`, `",`);
      str = str.replaceAll(`,"output"`, `","output"`);
      while (str.includes("'")) {
        str = str.replace("'", `"`);
      }
      str = str.substring(str.indexOf(`"testCases`));
      str = str.substring(0, str.length - 2);
      // console.log("{" + str + "}");
      // return JSON.parse("{" + str + "}");
    },
  },

  created() {
    try {
      var result = this.context
        .split("};")[0]
        .substring(8)
        .replaceAll("`", `"`);
      result = result.replaceAll("};", "}") + "}";
      const inforLesson = this.fixString(result);
      const obj = JSON.parse(inforLesson);
      const testCases = this.fixTestCase(result);
      this.lessonName = obj.tenBai;
      this.lessonDescription = "Thực hành!";
      this.lessonTime = "10 phút!";
      this.problem = obj.practiceLesson.problem;
      this.problemDetail = obj.practiceLesson.problemDetail;
      this.beginCode = obj.practiceLesson.codeBegin;
      this.callTestCode = "";
      //   this.inputExemple = testCases.testCases[0].input;
      //   this.outputExemple = testCases.testCases[0].output;
      this.explainCode = obj.practiceLesson.explain;
      this.suggest = obj.practiceLesson.suggest;
    } catch (error) {
      this.lessonName = "Lỗi!";
      this.lessonDescription = "Lỗi!";
      this.lessonTime = "Lỗi!";
      this.problem = "Lỗi!";
      this.problemDetail = "Lỗi!";
      this.beginCode = "Lỗi!";
      this.caseDefaultDetail = "Lỗi!";
      this.callTestCode = "Lỗi!";
      this.inputExemple = "Lỗi!";
      this.outputExemple = "Lỗi!";
      this.explainCode = "Lỗi!";
      this.suggest = "Lỗi!";
      return;
    }
  },
  props: {
    getLessonDetail: Function,
    context: String,
    show: Boolean,
    setShow: Function,
  },
};
</script>

<style lang="css" scoped></style>
