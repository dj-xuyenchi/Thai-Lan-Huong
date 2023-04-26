<template>
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
          :value="item.lessonName"
          :title="i + 1 + `. ` + item.lessonName"
          :prepend-icon="
            item.lessonType == 1
              ? `mdi-play`
              : item.lessonType == 2
              ? `mdi-pencil`
              : `mdi-file-outline`
          "
          :disabled="!item.isDone"
          style="position: relative"
          :to="`/study/` + item.lessonId + `/` + idCourse + `/` + chapterId"
        >
          <span
            style="
              position: absolute;
              right: 14px;
              top: 30%;
              font-size: 12px;
              font-weight: 500;
            "
            >{{ item.lessonTime }}</span
          >
        </v-list-item>
      </v-list-group>
    </v-list>
  </v-card>
</template>

<script>
export default {
  name: "LessonList",
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
  props: {
    titleLesson: String,
    listLesson: Array,
    idCourse: Number,
    chapterId: Number,
  },
};
</script>

<style lang="css" scoped>
.v-list {
  padding: unset;
}
</style>
