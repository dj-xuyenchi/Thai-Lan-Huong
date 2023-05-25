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
          <v-card style="overflow: scroll">
            <v-card-title>
              <span class="text-h5">Cập nhật bài học video</span>
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
  name: "BtnUpdateTheory",
  data() {
    return {
      text: "",
      snackbar: false,
      lessonName: "",
      lessonDescription: "",
      lessonTime: "",
      btnLoading: false,
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
      const result = await AdminAPI.updateTheoryLesson(
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
        this.text = "Cập nhật thất bại";
        this.snackbar = true;
      }
      this.btnLoading = false;
    },
  },
  mounted() {
    this.lessonName = this.item.lessonName;
    this.lessonDescription = this.item.lessonDescription;
    this.lessonTime = this.item.videoTime;
    this.linkVideo = this.item.linkVideo;
  },
  props: {
    getLessonDetail: Function,
    item: Object,
    lessonId: Number,
  },
  watch: {
    item: {
      immediate: true,
      handler(newItem) {
        this.lessonName = newItem.lessonName;
        this.lessonDescription = newItem.lessonDescription;
        this.lessonTime = newItem.videoTime;
        this.linkVideo = newItem.linkVideo;
      },
    },
  },
};
</script>

<style lang="css" scoped></style>
