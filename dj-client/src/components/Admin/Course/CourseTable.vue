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
            <BtnUpdateCourse />
            <AddChapterToCourse />
          </td>
        </tr>
      </tbody>
    </v-table>
  </div>
</template>

<script>
import BtnUpdateCourse from "./BtnUpdateCourse";
import AddChapterToCourse from "./AddChapterToCourse";
export default {
  name: "CourseTable",
  components: { BtnUpdateCourse, AddChapterToCourse },
  props: {
    data: [],
  },
};
</script>

<style lang="scss" scoped></style>
