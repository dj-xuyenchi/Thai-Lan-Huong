<template>
  <v-table>
    <thead>
      <tr>
        <th class="text-left">Thứ tự</th>
        <th class="text-left">Tên bài học</th>
        <th class="text-left">Loại bài học</th>
        <th class="text-center">Action</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="(item, index) in listLesson" :key="index">
        <td>{{ item.sortNumber }}</td>
        <td>{{ item.lessonName }}</td>
        <td>{{ item.lessonType }}</td>
        <td
          style="
            display: flex;
            justify-content: space-evenly;
            align-items: center;
          "
        >
          <BtnUpdateLesson
            :getLessonOfChapter="getLessonOfChapter"
            :item="item"
          />
          <BtnDeleteLesson
            :chapterLessonId="item.chapterLessonId"
            :getLessonOfChapter="getLessonOfChapter"
          />
        </td>
      </tr>
    </tbody>
  </v-table>
</template>
<script>
import BtnUpdateLesson from "./BtnUpdateLesson";
import BtnDeleteLesson from "./BtnDeleteLesson";
export default {
  components: { BtnUpdateLesson, BtnDeleteLesson },
  name: "LessonTable",
  data() {
    return {};
  },
  props: {
    listLesson: [],
    getLessonOfChapter: Function,
  },
};
</script>
