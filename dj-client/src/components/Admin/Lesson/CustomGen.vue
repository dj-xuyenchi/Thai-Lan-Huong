<template>
  <div>
    <v-row>
      <v-dialog v-model="dialog" persistent width="1024">
        <template v-slot:activator="{ props }">
          <v-btn color="primary" v-bind="props">
            Tư vấn thêm bài học chatGPT</v-btn
          >
        </template>
        <v-form @submit.prevent="submit()" ref="form">
          <v-card style="overflow: scroll">
            <v-card-title>
              <span class="text-h5">Tư vấn thêm bài học chatGPT</span>
            </v-card-title>
            <v-card-text>
              <v-container>
                <v-row>
                  <v-col cols="12" sm="6" md="4">
                    <v-select
                      v-model="select"
                      :items="items"
                      item-title="level"
                      item-value="levelValue"
                      label="Độ khó bài tập"
                      persistent-hint
                      return-object
                      single-line
                    ></v-select>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Số lượng test case*"
                      hint="Số lượng test case"
                      type="number"
                      v-model="testCaseCount"
                    ></v-text-field>
                  </v-col>
                </v-row>
              </v-container>
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
                Tư vấn
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
import HeyGPT from "../../../apis/OpenAI.ts";
import { mapMutations } from "vuex";
export default {
  name: "CustomGen",
  data() {
    return {
      text: "",
      snackbar: false,
      items: [
        { level: "Dễ", levelValue: "dễ" },
        { level: "Trung bình", levelValue: "trung bình" },
        { level: "Khó", levelValue: "khó" },
      ],
      select: "",
      testCaseCount: 1,
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
    async submit() {
      this.btnLoading = true;
      if (this.testCaseCount < 1) {
        this.btnLoading = false;
        this.snackbar = true;
        this.text = "Số lượng test case yêu cầu phải lớn hơn 0";
        return;
      }
      if (!this.select.levelValue) {
        this.btnLoading = false;
        this.snackbar = true;
        this.text = "Chưa chọn level bài học!";
        return;
      }
      let result = await HeyGPT.genPractice(
        this.select.levelValue,
        this.testCaseCount
      );
      while (!result.choices[0].message.content.includes("ketQua")) {
        result = await HeyGPT.genPractice(
          this.select.levelValue,
          this.testCaseCount
        );
      }
      var str = result.choices[0].message.content;
      str = str.substring(str.indexOf("ketQua"));
      this.setContext(str);
      this.dialog = false;
      this.btnLoading = false;
    },
  },
  props: { setContext: Function },
};
</script>

<style lang="css" scoped></style>
