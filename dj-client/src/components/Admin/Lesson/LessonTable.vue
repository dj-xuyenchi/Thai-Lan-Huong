<template>
  <div>
    <v-table>
      <thead>
        <tr>
          <th class="text-left">STT</th>
          <th class="text-left">Tên bài học</th>
          <th class="text-left">Mô tả</th>
          <th class="text-left">Ngày tạo</th>
          <th class="text-left">Cập nhật</th>
          <th class="text-left">Loại bài học</th>
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
          <td>{{ item.lessonType }}</td>
          <td>{{ item.videoTime }}</td>
          <td
            style="display: flex; justify-content: center; align-items: center"
          >
            <BtnUpdateTheory v-if="item.lessonTypeId == 1" />
            <BtnUpdatePractice v-if="item.lessonTypeId == 2" />
            <BtnUpdateQuestion v-if="item.lessonTypeId == 3" />
          </td>
        </tr>
      </tbody>
    </v-table>
  </div>
</template>

<script>
import BtnUpdatePractice from "./BtnUpdatePractice";
import BtnUpdateTheory from "./BtnUpdateTheory";
import BtnUpdateQuestion from "./BtnUpdateQuestion";
export default {
  name: "LessonTable",
  components: { BtnUpdatePractice, BtnUpdateTheory, BtnUpdateQuestion },
  props: {
    data: [],
  },
};
</script>

<style lang="scss" scoped></style>
