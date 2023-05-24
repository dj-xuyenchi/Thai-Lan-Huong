<template>
  <div style="margin: 4px 8px 4px 8px">
    <v-card class="mx-auto" width="100%" style="border-radius: 15px">
      <v-list v-model:opened="open">
        <v-list-group :value="titleLesson">
          <template v-slot:activator="{ props }">
            <v-list-item
              v-bind="props"
              prepend-icon="mdi-plus"
              :title="titleLesson"
            ></v-list-item>
          </template>
          <v-list-item
            v-for="(item, i) in listLesson"
            :key="i"
            :value="item.id"
            :title="Number(i + 1) + `. ` + item.lessonName"
            :prepend-icon="
              item.lessonType == 1
                ? `mdi-play`
                : item.lessonType == 2
                ? `mdi-pencil`
                : `mdi-file-outline`
            "
            :disabled="!item.isDone"
            style="position: relative"
            @click="changeLesson(item.lessonId)"
          >
            <span
              style="
                position: absolute;
                right: 14px;
                top: 30%;
                font-size: 12px;
                font-weight: 500;
              "
              >{{ time }}</span
            >
          </v-list-item>
        </v-list-group>
      </v-list>
    </v-card>
  </div>
</template>

<script>
export default {
  name: "LessonListStudy",
  data() {
    return {
      open: ["Lesson"],
      listLesson1: [
        [". Cài đặt môi trường", "mdi-play", "12:03"],
        [". Cài đặt IDE", "mdi-file-outline", "12:03"],
        [". Hello World", "mdi-pencil", "12:03"],
        [". Fix bugs", "mdi-play", "12:03"],
      ],
    };
  },

  methods: {
    changeLesson(lessonId) {
      localStorage.setItem("lessonIdFW", lessonId);
      localStorage.setItem("idCourseFW", this.$route.params.idCourse);
      localStorage.setItem("chapterIdFW", this.chapterId);
      this.$router.push({
        path: "/forwardlesson",
      });
    },
  },
  props: {
    titleLesson: String,
    listLesson: [],
    chapterId: Number,
  },
};
</script>

<style lang="css" scoped>
.v-list {
  padding: unset;
}
::-webkit-scrollbar {
  width: 0.5em;
}
</style>
