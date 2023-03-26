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
            v-for="([title, icon, time], i) in listLesson"
            :key="i"
            :value="title"
            :title="Number(i + 1) + title"
            :prepend-icon="icon"
            style="position: relative"
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
      listLesson: [
        [". Cài đặt môi trường", "mdi-play", "12:03"],
        [". Cài đặt IDE", "mdi-file-outline", "12:03"],
        [". Hello World", "mdi-pencil", "12:03"],
        [". Fix bugs", "mdi-play", "12:03"],
      ],
    };
  },
  props: {
    titleLesson: String,
  },
};
</script>

<style lang="css" scoped>
.v-list {
  padding: unset;
}
</style>
