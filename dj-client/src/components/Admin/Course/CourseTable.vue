<template>
  <div>
    <v-table>
      <thead>
        <tr>
          <th class="text-left">STT</th>
          <th class="text-left">Hình đại diện</th>
          <th class="text-left">Tên khóa học</th>
          <th class="text-left">Học phần</th>
          <th class="text-left">Bài học</th>
          <th class="text-left">Thời lượng</th>
          <th class="text-left">Trạng thái</th>
          <th class="text-center">Action</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(item, index) in data" :key="index">
          <td>{{ index + 1 }}</td>
          <td>
            <img
              :src="`data:image/jpeg;base64,` + item.courseImageData"
              alt=""
              style="height: 40px; width: 80px"
            />
          </td>
          <td>{{ item.courseName }}</td>
          <td>{{ item.chapterCount }}</td>
          <td>{{ item.lessonCount }}</td>
          <td>{{ item.timeLessonTotal }}</td>
          <td>{{ item.courseStatus }}</td>
          <td
            style="
              display: flex;
              justify-content: space-evenly;
              align-items: center;
            "
          >
            <BtnUpdateCourse :item="item" />
            <AddChapterToCourse
              :courseName="item.courseName"
              :courseId="item.courseName"
            />
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
