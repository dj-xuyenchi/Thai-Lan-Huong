<template>
  <v-card class="mx-auto" width="100%">
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
          v-for="([title, icon], i) in listLesson"
          :key="i"
          :value="title"
          :title="Number(i + 1) + title"
          :prepend-icon="icon"
        ></v-list-item>
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
      listLesson: [
        [". Cài đặt môi trường", "mdi-play"],
        [". Cài đặt IDE", "mdi-file-outline"],
        [". Hello World", "mdi-pencil"],
        [". Fix bugs", "mdi-play"],
      ],
    };
  },
  props: {
    titleLesson: String,
  },
};
</script>

<style lang="css" scoped></style>
