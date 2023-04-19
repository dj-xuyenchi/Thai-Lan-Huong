<template>
  <div>
    <v-form ref="form" @submit.prevent="submit">
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
                      required
                      :v-model="lessonName"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Mô tả"
                      hint="Mô tả bài học"
                      required
                      :v-model="lessonDescription"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Thời lượng"
                      hint="Thời lượng của bài học"
                      required
                      :v-model="lessonTime"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12">
                    <v-text-field
                      label="Vấn đề"
                      hint="Vấn đề cần giải quyết"
                      required
                      :v-model="problem"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12">
                    <v-text-field
                      label="Mô tả vấn đề"
                      hint="Mô tả vấn đề cần giải quyết"
                      required
                      :v-model="problemDetail"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12">
                    <v-textarea
                      counter
                      label="Code mặc định"
                      hint="Đoạn code mặc định hiển thị lên code field"
                      required
                      :v-model="beginCode"
                    ></v-textarea>
                  </v-col>
                  <v-col cols="6">
                    <v-text-field
                      label="Đầu vào ví dụ"
                      hint="Input test case ví dụ"
                      required
                      :v-model="inputExemple"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="6">
                    <v-text-field
                      label="Đầu ra ví dụ"
                      hint="Output test case ví dụ"
                      required
                      :v-model="outputExemple"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12">
                    <v-text-field
                      label="Giải thích"
                      hint="Giải thích ví dụ"
                      required
                      :v-model="explain"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12">
                    <v-text-field
                      label="Gợi ý"
                      hint="Gợi ý bài tập"
                      required
                      :v-model="suggest"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12">
                    <v-switch
                      v-model="activeLesson"
                      label="Active bài học"
                    ></v-switch>
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
export default {
  name: "BtnUpdateTheory",
  data: () => ({
    lessonName: "",
    lessonDescription: "",
    lessonTime: "",
    problem: "",
    problemDetail: "",
    beginCode: "",
    inputExemple: "",
    outputExemple: "",
    explainCode: "",
    suggest: "",
    activeLesson: false,
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
    sendData() {
      console.log(this.getData());
      //   this.dialog = false;
    },
  },
};
</script>

<style lang="css" scoped></style>
