<template>
  <div>
    <v-row>
      <v-dialog v-model="dialog" persistent width="80vw" height=" 70vh">
        <template v-slot:activator="{ props }">
          <v-btn
            color="green"
            density="compact"
            v-bind="{ props }"
            @click="dialog = true"
            icon="mdi-magnify"
          >
          </v-btn>
        </template>
        <v-card style="overflow: scroll">
          <v-card-title>
            <span class="text-h5"
              >Tiến độ học <span style="color: red">{{ courseName }}</span> của:
              <span style="color: red; font-size: 26px">{{ userName }}</span>
              <span style="font-size: 24px; font-weight: 550"> {{}}</span></span
            >
          </v-card-title>
          <div
            v-for="(element, index) in list"
            :key="index"
            style="margin-bottom: 20px"
          >
            <span style="margin-left: 8px">
              Tên học phần:
              <span style="font-size: 16px; font-weight: 700">
                {{ element.name }}
              </span>
            </span>
            <v-table>
              <thead>
                <tr>
                  <th class="text-left">#</th>
                  <th class="text-left">Tên bài học</th>
                  <th class="text-left">Thời lượng</th>
                  <th class="text-left">Loại bài học</th>
                  <th class="text-left">Ngày mở</th>
                  <th class="text-left">Trạng thái</th>
                  <th class="text-center">Action</th>
                </tr>
              </thead>
              <tbody>
                <tr
                  v-for="(item1, index) in element.lessonProgressDTOs"
                  :key="index"
                >
                  <td style="max-width: 40px" class="text-left">
                    {{ index + 1 }}
                  </td>
                  <td style="max-width: 220px" class="text-left">
                    {{ item1.lessonName }}
                  </td>
                  <td style="max-width: 120px" class="text-left">
                    {{ item1.time }}
                  </td>
                  <td style="max-width: 120px" class="text-left">
                    {{ item1.lessonType }}
                  </td>
                  <td
                    style="max-width: 120px"
                    class="text-left"
                    v-if="item1.openTime != null"
                  >
                    {{ item1.openTime }}
                  </td>
                  <td
                    class="text-left"
                    style="max-width: 120px"
                    v-if="item1.openTime == null"
                  >
                    <v-chip class="ma-2" color="red" text-color="white">
                      Chưa mở
                    </v-chip>
                  </td>
                  <td
                    style="max-width: 120px; color: green"
                    v-if="item1.isDone"
                    class="text-left"
                  >
                    <v-chip class="ma-2" color="green" text-color="white">
                      Đã hoàn thành
                    </v-chip>
                  </td>
                  <td
                    style="max-width: 120px; color: red"
                    v-if="item1.isDone == false"
                  >
                    <v-chip class="ma-2" color="red" text-color="white">
                      Chưa hoàn thành
                    </v-chip>
                  </td>
                  <td
                    style="
                      display: flex;
                      justify-content: space-evenly;
                      align-items: center;
                    "
                    class="text-left"
                  >
                    <BtnShowDoneData
                      :userId="userId"
                      :lessonId="item1.lessonId"
                      :lessonTypeId="item1.lessonTypeId"
                      :list="list"
                    />
                    <BtnLockOrUnlockLesson
                      :userId="userId"
                      :lessonId="item1.lessonId"
                      :getCourseProgress="getCourseProgress"
                    />
                  </td>
                </tr>
              </tbody>
            </v-table>
          </div>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn color="blue-darken-1" variant="text" @click="dialog = false">
              Thoát
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
      <v-snackbar v-model="snackbar">
        {{ text }}
        <template v-slot:actions>
          <v-btn color="green" variant="text" @click="snackbar = false">
            Đóng
          </v-btn>
        </template>
      </v-snackbar>
    </v-row>
  </div>
</template>

<script>
import AdminAPI from "../../../apis/APIAdmin/AdminAPI";
import BtnLockOrUnlockLesson from "./BtnLockOrUnlockLesson.vue";
import BtnShowDoneData from "./BtnShowDoneData.vue";
export default {
  name: "ProgressBtn",
  props: {
    item: Object,
    courseId: Number,
  },
  components: { BtnLockOrUnlockLesson, BtnShowDoneData },
  data: () => ({
    dialog: false,
    btnLoading: false,
    text: "",
    list: null,
    userId: 0,
    chapterName: [],
    snackbar: false,
    userName: "",
    courseName: "",
    opt: false,
  }),
  methods: {
    async getCourseProgress() {
      const data = await AdminAPI.getCourseProgress(
        this.courseId,
        this.item.studentId,
        localStorage.getItem("token")
      );
      this.list = data.progress;
      this.userId = data.userId;
      this.courseName = data.courseName;
      this.chapterName = data.chapterName;
      this.userName = data.userName;
    },
  },
  created() {
    this.getCourseProgress();
  },
  watch: {
    deep: true,
    item: {
      handler() {
        this.getCourseProgress();
      },
    },
  },
};
</script>

<style lang="css" scoped></style>
