<template>
  <div>
    <v-row>
      <!-- <v-dialog v-model="dialog" persistent width="1024"> -->
      <!-- <template v-slot:activator="{ props }">
          <v-btn color="primary" v-bind="props"> Thêm bài học video</v-btn>
        </template> -->
      <v-form @submit.prevent="submit()" ref="form">
        <v-card style="height: 90vh; overflow: scroll; width: 1024px">
          <v-card-title>
            <span class="text-h5">Thêm bài học video</span>
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
                    label="Link video*"
                    hint="Link video"
                    :rules="rules"
                    v-model="linkVideo"
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
              Thêm bài học
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
  name: "AddTheory",
  data() {
    return {
      lessonName: "",
      lessonDescription: "",
      lessonTime: "",
      linkVideo: "",
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
        videoLink: this.linkVideo,
      };
    },
    async submit() {
      this.btnLoading = true;
      if (
        this.lessonName.trim().length < 1 ||
        this.lessonDescription.trim().length < 1 ||
        this.lessonTime.trim().length < 1 ||
        this.linkVideo.trim().length < 1
      ) {
        this.btnLoading = false;
        return;
      }
      const token = localStorage.getItem("token");
      const result = await AdminAPI.addTheoryLesson(this.getData(), token);
      if (result.data.status == 1) {
        this.dialog = false;
        this.lessonName = "";
        this.lessonDescription = "";
        this.lessonTime = "";
        this.linkVideo = "";
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
};
</script>

<style lang="css" scoped></style>
