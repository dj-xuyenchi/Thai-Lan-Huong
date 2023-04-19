<template>
  <div>
    <v-table>
      <thead>
        <tr>
          <th class="text-left">STT</th>
          <th class="text-left">Tên học phần</th>
          <th class="text-left">Ngày tạo</th>
          <th class="text-left">Cập nhật</th>
          <th class="text-left">Thời lượng</th>
          <th class="text-center">Action</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(item, index) in data" :key="index">
          <td>{{ index + 1 }}</td>
          <td>{{ item.lessonName }}</td>
          <td>{{ item.lessonDescription }}</td>
          <td>{{ item.createDateTime }}</td>
          <td>{{ item.updateDateTime }}</td>
          <td
            style="
              display: flex;
              justify-content: space-evenly;
              align-items: center;
            "
          >
            <BtnUpdateChapter />
            <AddLessonToChapter />
          </td>
        </tr>
      </tbody>
    </v-table>
  </div>
</template>

<script>
import BtnUpdateChapter from "./BtnUpdateChapter";
import AddLessonToChapter from "./AddLessonToChapter";
export default {
  name: "ChapterTable",
  components: { BtnUpdateChapter, AddLessonToChapter },
  props: {
    data: [],
  },
};
</script>

<style lang="scss" scoped></style>
