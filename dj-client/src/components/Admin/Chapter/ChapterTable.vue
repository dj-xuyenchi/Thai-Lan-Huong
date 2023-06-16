<template>
  <div>
    <v-table>
      <thead>
        <tr>
          <th class="text-left">STT</th>
          <th class="text-left">Tên học phần</th>
          <th class="text-left">Ngày tạo</th>
          <th class="text-left">Số bài học</th>
          <th class="text-left">Thời lượng</th>
          <th class="text-center" style="min-width: 100px">Action</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(item, index) in data" :key="index">
          <td>{{ index + 1 }}</td>
          <td>{{ item.chapterName }}</td>
          <td>{{ item.createDateTime }}</td>
          <td>{{ item.lessonCount }} bài học</td>
          <td>{{ item.timeTotal }}</td>
          <td
            style="
              display: flex;
              justify-content: space-evenly;
              align-items: center;
            "
          >
            <BtnUpdateChapter
              :getChapterDetail="getChapterDetail"
              :chapterId="item.chapterId"
              :item="item"
            />
            <LessonList
              :chapterName="item.chapterName"
              :chapterId="item.chapterId"
            />
          </td>
        </tr>
      </tbody>
    </v-table>
  </div>
</template>

<script>
import BtnUpdateChapter from "./BtnUpdateChapter";
import LessonList from "./LessonList";
export default {
  name: "ChapterTable",
  components: { BtnUpdateChapter, LessonList },
  props: {
    data: [],
    getChapterDetail: Function,
  },
};
</script>

<style lang="scss" scoped></style>
