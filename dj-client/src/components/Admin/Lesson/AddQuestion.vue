<template>
  <div>
    <v-row>
      <v-dialog v-model="dialog" persistent width="1024">
        <template v-slot:activator="{ props }">
          <v-btn color="primary" v-bind="props"> Thêm bài quiz</v-btn>
        </template>
        <v-form @submit.prevent="submit()" ref="form">
          <v-card style="height: 90vh; overflow: scroll">
            <v-card-title>
              <span class="text-h5">Thêm bài quiz</span>
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
                      label="Câu hỏi*"
                      hint="Câu hỏi hiển thị"
                      :rules="rules"
                      v-model="linkVideo"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12">
                    <v-text-field
                      label="Đáp án A*"
                      hint="Đáp án A"
                      :rules="rules"
                      v-model="answera"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12">
                    <v-text-field
                      label="Đáp án B*"
                      hint="Đáp án B"
                      :rules="rules"
                      v-model="answera"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12">
                    <v-text-field
                      label="Đáp án C*"
                      hint="Đáp án C"
                      :rules="rules"
                      v-model="answerc"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12">
                    <v-text-field
                      label="Đáp án D*"
                      hint="Đáp án D"
                      :rules="rules"
                      v-model="answerd"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12">
                    <v-select
                      label="Đáp án đúng"
                      :items="['A', 'B', 'C', 'D']"
                      :rules="rules"
                    ></v-select>
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
                @click="dialog = false"
              >
                Hủy
              </v-btn>
              <v-btn color="blue-darken-1" variant="text" type="submit">
                Thêm bài học
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
export default {
  name: "AddQuestion",
  data() {
    return {
      text: "",
      snackbar: false,
      lessonName: "",
      lessonDescription: "",
      lessonTime: "",
      linkVideo: "",
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
        linkVideo: this.linkVideo,
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
      const result = await AdminAPI.addPracticeLesson(this.getData(), token);
      if (result.status == 1) {
        this.text = "Thêm thành công";
        this.dialog = false;
        this.snackbar = true;
        this.lessonName = "";
        this.lessonDescription = "";
        this.lessonTime = "";
        this.linkVideo = "";
        this.getLessonDetail();
      }
      if (result.status == 2) {
        this.text = "Thêm thất bại";
        this.snackbar = true;
      }
    },
  },
  props: {
    getLessonDetail: Function,
  },
};
</script>

<style lang="css" scoped></style>
