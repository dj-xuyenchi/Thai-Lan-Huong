<template>
  <v-table>
    <thead>
      <tr>
        <th class="text-left">Thứ tự</th>
        <th class="text-left">Tên học phần</th>
        <th class="text-left">Số bài học</th>
        <th class="text-left">Thời lượng</th>
        <th class="text-center" style="min-width: 20%">Action</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="(item, index) in listChapter" :key="index">
        <td>{{ item.sortNumber }}</td>
        <td>{{ item.name }}</td>
        <td>{{ item.lessonCount }}</td>
        <td>{{ item.totalTime }}</td>
        <td
          style="
            display: flex;
            justify-content: space-evenly;
            align-items: center;
          "
        >
          <BtnUpdateChapter
            :courseChapterId="item.id"
            :getChapterOfCourse="getChapterOfCourse"
          />
          <BtnRemoveChapter
            :courseChapterId="item.id"
            :getChapterOfCourse="getChapterOfCourse"
          />
        </td>
      </tr>
    </tbody>
  </v-table>
</template>
<script>
import BtnUpdateChapter from "./BtnUpdateChapter";
import BtnRemoveChapter from "./BtnRemoveChapter";
export default {
  components: { BtnUpdateChapter, BtnRemoveChapter },
  data() {
    return {};
  },
  props: {
    listChapter: [],
    getChapterOfCourse: Function,
  },
};
</script>
