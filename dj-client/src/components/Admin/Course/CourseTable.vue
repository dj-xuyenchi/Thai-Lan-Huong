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
          <th class="text-left">Trạng thái</th>
          <th class="text-center" style="min-width: 120px">Action</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(item, index) in data" :key="index">
          <td>{{ index + 1 }}</td>
          <td>
            <img
              :src="item.courseImageData"
              alt="Hình ảnh"
              style="height: 60px; width: 100px; margin-top: 6px"
            />
          </td>
          <td>{{ fixString(item.courseName) }}</td>
          <td>{{ item.chapterCount + " học phần" }}</td>
          <td>{{ item.lessonCount + " bài học" }}</td>
          <td>{{ item.courseStatus }}</td>
          <td
            style="
              display: flex;
              justify-content: space-evenly;
              align-items: center;
              height: 74px;
            "
          >
            <BtnUpdateCourse :item="item" :getCoursePage="getCoursePage" />
            <AddChapterToCourse
              :courseName="item.courseName"
              :courseId="item.courseId"
            />
            <BtnListStudentOfCourse :item="item" />
          </td>
        </tr>
      </tbody>
    </v-table>
  </div>
</template>

<script>
import BtnUpdateCourse from "./BtnUpdateCourse";
import AddChapterToCourse from "./AddChapterToCourse";
import BtnListStudentOfCourse from "./BtnListStudentOfCourse";

export default {
  name: "CourseTable",
  components: { BtnUpdateCourse, AddChapterToCourse, BtnListStudentOfCourse },
  props: {
    data: [],
    getCoursePage: Function,
  },
  methods: {
    fixString(val) {
      return val.substring(0, 25) + "...";
    },
  },
};
</script>

<style lang="scss" scoped></style>
