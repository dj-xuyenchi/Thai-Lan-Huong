<template>
  <div>
    <v-row justify="center">
      <v-btn
        color="green"
        density="compact"
        @click="dialog = true"
        icon="mdi-plus"
      >
      </v-btn>
      <v-dialog v-model="dialog" persistent width="auto">
        <v-card style="height: 90vh; :scroll ; width: 80vw">
          <v-card-title> {{ chapterName }} </v-card-title>
          <v-card-text>
            <AddLesson
              :CourseChapterId="chapterId"
              :getLessonOfChapter="getLessonOfChapter"
            />
            <LessonTable
              :getLessonOfChapter="getLessonOfChapter"
              :listLesson="listLesson"
              style="margin-top: 12px"
            />
          </v-card-text>
          <v-card-actions>
            <v-btn color="primary" variant="text" @click="dialog = false">
              Đóng
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
    </v-row>
  </div>
</template>
<script>
import AdminAPI from "../../../apis/APIAdmin/AdminAPI.ts";
import LessonTable from "./LessonTable";
import AddLesson from "./AddLesson";
export default {
  name: "LessonList",
  components: { LessonTable, AddLesson },
  props: {
    chapterId: Number,
    chapterName: String,
  },
  data() {
    return {
      dialog: false,
      notifications: false,
      sound: true,
      widgets: false,
      listLesson: [],
    };
  },
  methods: {
    async getLessonOfChapter() {
      const token = localStorage.getItem("token");

      const data = await AdminAPI.getLessonOfChapter(this.chapterId, token);
      this.listLesson = data.data;
    },
  },
  created() {
    this.getLessonOfChapter();
  },
  watch: {
    listLesson: {
      immediate: true,
      handler(newData) {
        this.listLesson = newData;
      },
    },
  },
};
</script>
