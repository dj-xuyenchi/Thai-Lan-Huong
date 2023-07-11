<template>
  <div>
    <v-row>
      <v-btn
        color="green"
        density="compact"
        @click="dialog = true"
        icon="mdi-plus"
      >
      </v-btn>
      <v-dialog v-model="dialog" persistent width="auto">
        <v-card style="height: 90vh; :scroll ; width: 80vw">
          <v-card-title> {{ courseName }} </v-card-title>
          <v-card-text>
            <ChapterTable
              style="margin-top: 12px"
              :listChapter="listChapter"
              :getChapterOfCourse="getChapterOfCourse"
            />
          </v-card-text>
          <v-card-actions>
            <v-btn color="primary" variant="text" @click="dialog = false">
              Đóng
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>

      <v-dialog v-model="dialog2" width="auto">
        <v-card>
          <v-card-title> Dialog 2 </v-card-title>
          <v-card-text>
            <v-btn color="primary" @click="dialog3 = !dialog3">
              Open Dialog 3
            </v-btn>
          </v-card-text>
          <v-card-actions>
            <v-btn color="primary" variant="text" @click="dialog2 = false">
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
import ChapterTable from "./ChapterTable";
export default {
  name: "AddChapterToCourse",
  components: { ChapterTable },
  props: {
    courseName: String,
    courseId: Number,
  },
  data() {
    return {
      dialog: false,
      dialog2: false,
      dialog3: false,
      notifications: false,
      sound: true,
      widgets: false,
      listChapter: [],
    };
  },
  methods: {
    async getChapterOfCourse() {
      const token = localStorage.getItem("token");
      const data = await AdminAPI.getChapterOfCourse(this.courseId, token);
      this.listChapter = data.data;
    },
  },
  created() {
    this.getChapterOfCourse();
  },
};
</script>
