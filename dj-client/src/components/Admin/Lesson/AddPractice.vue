<template>
  <div>
    <v-row>
      <v-dialog v-model="dialog" persistent width="1024">
        <template v-slot:activator="{ props }">
          <v-btn color="primary" v-bind="props"> Thêm bài học thực hành</v-btn>
        </template>
        <v-form @submit.prevent="submit()" ref="form">
          <v-card>
            <v-card-title>
              <span class="text-h5">Thêm bài học thực hành</span>
            </v-card-title>
            <v-card-text>
              <v-container>
                <v-row>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Tên bài học"
                      hint="Khi hiển thị sẽ là Bài học + tên bài học"
                      v-model="lessonName"
                      :rules="rules"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Mô tả"
                      hint="Mô tả bài học"
                      :rules="rules"
                      v-model="lessonDescription"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Thời lượng"
                      hint="Thời lượng của bài học"
                      :rules="rules"
                      v-model="lessonTime"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12">
                    <v-text-field
                      label="Vấn đề"
                      hint="Vấn đề cần giải quyết"
                      :rules="rules"
                      v-model="problem"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12">
                    <v-text-field
                      label="Mô tả vấn đề"
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
                      :rules="rules"
                      v-model="beginCode"
                    ></v-textarea>
                  </v-col>
                  <v-col cols="12">
                    <v-text-field
                      counter
                      label="Call Test Code"
                      hint="Call Test Code"
                      :rules="rules"
                      v-model="callTestCode"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="6">
                    <v-text-field
                      label="Đầu vào ví dụ"
                      hint="Input test case ví dụ"
                      :rules="rules"
                      v-model="inputExemple"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="6">
                    <v-text-field
                      label="Đầu ra ví dụ"
                      hint="Output test case ví dụ"
                      :rules="rules"
                      v-model="outputExemple"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12">
                    <v-text-field
                      label="Giải thích"
                      hint="Giải thích ví dụ"
                      :rules="rules"
                      v-model="explainCode"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12">
                    <v-text-field
                      label="Gợi ý"
                      hint="Gợi ý bài tập"
                      :rules="rules"
                      v-model="suggest"
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
              <v-btn color="blue-darken-1" variant="text" type="submit">
                Thêm bài tập
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-form>
      </v-dialog>
    </v-row>
  </div>
</template>

<script>
import AdminAPI from "../../../apis/APIAdmin/AdminAPI.ts";
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
      inputExemple: "",
      callTestCode: "",
      outputExemple: "",
      explainCode: "",
      suggest: "",
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
    getData() {
      return {
        lessonName: this.lessonName,
        lessonDescription: this.lessonDescription,
        lessonTime: this.lessonTime,
        problem: this.problem,
        problemDetail: this.problemDetail,
        beginCode: this.beginCode,
        callTestCode: this.callTestCode,
        inputExemple: this.inputExemple,
        outputExemple: this.outputExemple,
        explainCode: this.explainCode,
        suggest: this.suggest,
      };
    },
    async submit() {
      const form = Object.assign({}, this.$refs.form);
      for (const item of form.items) {
        if (!item.isValid) {
          return;
        }
      }
      const token = localStorage.getItem("token");
      await AdminAPI.addPracticeLesson(this.getData(), token);
    },
  },
};
</script>

<style lang="css" scoped></style>
