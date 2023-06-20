<template>
  <v-table>
    <thead>
      <tr>
        <th class="text-left" style="width: 10%">Thứ tự</th>
        <th class="text-left" style="width: 50%">Tên bài học</th>
        <th class="text-left" style="width: 25%">Loại bài học</th>
        <th class="text-center" style="width: 15%">Action</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="(item, index) in listLesson" :key="index">
        <td>{{ item.sortNumber }}</td>
        <td>{{ fixString(item.lessonName) }}</td>
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
  methods: {
    fixString(val) {
      return val.length > 55 ? val.substring(0, 55) + "..." : val;
    },
  },
};
</script>
