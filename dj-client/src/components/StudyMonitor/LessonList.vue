<template>
  <div style="display: inline">
    <v-menu
      transition="slide-y-transition"
      :close-on-content-click="false"
      v-model="menu"
    >
      <template v-slot:activator="{ props }">
        <v-btn color="#4FC3F7" v-bind="props" @click="getChapterLesson()">
          <font-awesome-icon
            icon="fa-solid fa-list"
            color="black"
            style="font-size: 20px; margin-right: 4px"
          />
          Danh sách bài học
        </v-btn>
      </template>
      <v-card height="70vh" width="30vw" style="border-radius: 15px">
        <v-list>
          <v-list-item
            :prepend-avatar="getAIProfile.avatar"
            :title="courseName"
            :subtitle="updateTime"
          >
            <!-- <template v-slot:append>
              <v-btn
                variant="text"
                :class="fav ? 'text-red' : ''"
                icon="mdi-heart"
                @click="fav = !fav"
              ></v-btn>
              <span>Bạn và 2.123 người khác</span>
            </template> -->
          </v-list-item>
        </v-list>
        <v-divider></v-divider>
        <LessonListStudy
          v-for="(item, i) in chapterList"
          :key="i"
          :listLesson="item.lessonDetail"
          :titleLesson="i + 1 + `. ` + item.chapterTitle"
          :chapterId="item.chapterId"
        />
        <div style="height: 12px"></div>
      </v-card>
    </v-menu>
  </div>
</template>

<script>
import StudyAPI from "../../apis/APIStudy/StudyAPI.ts";
import LessonListStudy from "./LessonListStudy.vue";
import { mapGetters } from "vuex";
export default {
  name: "LessonList",
  components: { LessonListStudy },
  data: () => ({
    fav: true,
    menu: false,
    message: false,
    hints: true,
    courseName: "",
    updateTime: "",
    chapterList: [],
  }),
  methods: {
    async getChapterLesson() {
      const token = localStorage.getItem("token");
      const userId = localStorage.getItem("id");
      const result = await StudyAPI.getChapterLessonOfUser(
        userId,
        this.$route.params.idCourse,
        token
      );
      this.chapterList = result.chapterLesson;
      this.courseName = result.courseName;
      this.updateTime = result.updateTime;
    },
  },
  computed: {
    ...mapGetters(["getAIProfile"]),
  },
};
</script>

<style lang="css" scoped>
::-webkit-scrollbar {
  width: 0.5em;
}
</style>
