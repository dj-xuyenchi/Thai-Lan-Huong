<template>
  <div>
    <v-row>
      <v-dialog
        v-model="dialog"
        persistent
        :width="lessonTypeId == 2 ? `80vw` : `1024`"
      >
        <template v-slot:activator="{ props }">
          <v-btn
            color="green"
            v-bind="props"
            density="compact"
            icon="mdi-magnify"
          >
          </v-btn>
        </template>
        <v-card>
          <v-card-title class="text-h5"> Bài làm của học viên </v-card-title>
          <span style="margin-left: 12px" v-if="!data"
            >Học viên chưa hoàn thành</span
          >
          <VideoDoneData
            v-if="lessonTypeId == 1 && data"
            :item="data.videoLesson.lesson"
            :url="data.videoLesson.lessonLinkUrl"
            :doneTime="data.doneTime"
          />
          <QuestionDoneData
            v-if="lessonTypeId == 3 && data"
            :item="data.questionLesson.lesson"
            :dataItem="data"
            :doneTime="data.doneTime"
          />
          <PracDoneData
            v-if="lessonTypeId == 2 && data"
            :dataItem="data"
            :doneTime="data.doneTime"
          />
          <v-card-actions>
            <v-spacer></v-spacer>

            <v-btn
              color="green-darken-1"
              variant="text"
              @click="dialog = false"
            >
              Đồng ý
            </v-btn>
          </v-card-actions>
        </v-card>
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
import VideoDoneData from "./VideoDoneData";
import QuestionDoneData from "./QuestionDoneData";
import PracDoneData from "./PracDoneData";
export default {
  name: "BtnShowDoneData",
  components: { VideoDoneData, QuestionDoneData, PracDoneData },
  data() {
    return {
      dialog: false,
      data: {},
    };
  },
  methods: {
    async getData() {
      const token = localStorage.getItem("token");
      const result = await AdminAPI.getDoneData(
        this.userId,
        this.lessonId,
        token
      );
      this.data = result;
    },
  },
  created() {
    this.getData();
  },
  props: {
    userId: Number,
    lessonId: Number,
    lessonTypeId: Number,
    list: Array,
  },
  watch: {
    list: {
      immediate: true,
      handler() {
        this.getData();
      },
    },
  },
};
</script>
