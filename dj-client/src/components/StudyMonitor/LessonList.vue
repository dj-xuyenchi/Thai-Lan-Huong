<template>
  <div style="display: inline">
    <v-menu
      transition="slide-y-transition"
      :close-on-content-click="false"
      v-model="menu"
    >
      <template v-slot:activator="{ props }">
        <v-btn color="#4FC3F7" v-bind="props">
          <font-awesome-icon
            icon="fa-solid fa-list"
            color="black"
            style="font-size: 20px; margin-right: 4px"
          />
          Danh sách bài học
        </v-btn>
      </template>
      <v-card height="70vh" width="30vw">
        <v-list>
          <v-list-item
            prepend-avatar="https://cdn.vuetifyjs.com/images/john.jpg"
            title="Khóa học JAVA cơ bản đến Spring"
            subtitle="Cập nhật 23/12/2023"
          >
            <template v-slot:append>
              <v-btn
                variant="text"
                :class="fav ? 'text-red' : ''"
                icon="mdi-heart"
                @click="fav = !fav"
              ></v-btn>
              <span>Bạn và 2.123 người khác</span>
            </template>
          </v-list-item>
        </v-list>
        <v-divider></v-divider>
        <LessonListStudy titleLesson="1. Java Basic (4 bài học)" />
        <LessonListStudy titleLesson="1. Java Basic (4 bài học)" />
        <LessonListStudy titleLesson="1. Java Basic (4 bài học)" />
        <LessonListStudy titleLesson="1. Java Basic (4 bài học)" />
        <LessonListStudy titleLesson="1. Java Basic (4 bài học)" />
        <LessonListStudy titleLesson="1. Java Basic (4 bài học)" />
        <LessonListStudy titleLesson="1. Java Basic (4 bài học)" />
        <LessonListStudy titleLesson="1. Java Basic (4 bài học)" />
        <LessonListStudy titleLesson="1. Java Basic (4 bài học)" />
        <LessonListStudy titleLesson="1. Java Basic (4 bài học)" />
        <LessonListStudy titleLesson="1. Java Basic (4 bài học)" />
        <LessonListStudy titleLesson="1. Java Basic (4 bài học)" />
        <LessonListStudy titleLesson="1. Java Basic (4 bài học)" />
        <LessonListStudy titleLesson="1. Java Basic (4 bài học)" />
        <LessonListStudy titleLesson="1. Java Basic (4 bài học)" />
        <LessonListStudy titleLesson="1. Java Basic (4 bài học)" />
        <LessonListStudy titleLesson="1. Java Basic (4 bài học)" />
        <LessonListStudy titleLesson="1. Java Basic (4 bài học)" />
        <LessonListStudy titleLesson="1. Java Basic (4 bài học)" />
        <LessonListStudy titleLesson="1. Java Basic (4 bài học)" />
        <LessonListStudy titleLesson="1. Java Basic (4 bài học)" />
      </v-card>
    </v-menu>
  </div>
</template>

<script>
import LessonListStudy from "./LessonListStudy.vue";
export default {
  name: "LessonList",
  components: { LessonListStudy },
  data: () => ({
    fav: true,
    menu: false,
    message: false,
    hints: true,
  }),
};
</script>

<style lang="scss" scoped></style>
