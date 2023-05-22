<template>
  <div>
    <v-table>
      <thead>
        <tr>
          <th class="text-left">STT</th>
          <th class="text-left">Tên bài học</th>
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
          <td>{{ item.createDateTime }}</td>
          <td>{{ item.updateDateTime }}</td>
          <td>{{ item.lessonType }}</td>
          <td>{{ item.videoTime }}</td>
          <td
            style="
              display: flex;
              justify-content: space-between;
              align-items: center;
            "
            v-if="item.lessonTypeId == 2 && item.isSupportMultiLangue"
          >
            <BtnUpdatePractice
              :lessonId="item.lessonId"
              :item="item"
              :getLessonDetail="getLessonDetail"
            />

            <ListTestCase v-if="item.lessonTypeId == 2" :item="item" />
            <MultiLangueTable
              :practiceId="item.practiceId"
              :item="item"
              :getLessonDetail="getLessonDetail"
            />
          </td>
          <td
            style="
              display: flex;
              justify-content: space-around;
              align-items: center;
            "
            v-if="item.lessonTypeId == 2 && !item.isSupportMultiLangue"
          >
            <BtnUpdatePractice
              :lessonId="item.lessonId"
              v-if="item.lessonTypeId == 2"
              :item="item"
              :getLessonDetail="getLessonDetail"
            />

            <ListTestCase v-if="item.lessonTypeId == 2" :item="item" />
          </td>
          <td
            style="display: flex; justify-content: center; align-items: center"
            v-if="item.lessonTypeId == 1"
          >
            <BtnUpdateTheory
              :lessonId="item.lessonId"
              :item="item"
              :getLessonDetail="getLessonDetail"
            />
          </td>
          <td
            style="display: flex; justify-content: center; align-items: center"
            v-if="item.lessonTypeId == 3"
          >
            <BtnUpdateQuestion
              :lessonId="item.lessonId"
              :item="item"
              :getLessonDetail="getLessonDetail"
            />
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
import ListTestCase from "./ListTestCase";
import MultiLangueTable from "./MultiLangueTable";
export default {
  name: "LessonTable",
  components: {
    BtnUpdatePractice,
    BtnUpdateTheory,
    BtnUpdateQuestion,
    ListTestCase,
    MultiLangueTable,
  },
  props: {
    data: [],
    getLessonDetail: Function,
  },
};
</script>

<style lang="scss" scoped></style>
