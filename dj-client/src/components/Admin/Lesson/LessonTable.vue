<template>
  <div>
    <!-- <v-data-table
      v-model:items-per-page="itemsPerPage"
      :headers="headers"
      :items="desserts"
      item-value="name"
      class="elevation-1"
    >
      <template v-slot:item.actions="{ item }">
        <v-icon size="small" class="me-2" @click="editItem(item.raw)">
          mdi-pencil
        </v-icon>
        <v-icon size="small" @click="deleteItem(item.raw)"> mdi-delete </v-icon>
      </template>
      <template v-slot:no-data>
        <v-btn color="primary" @click="initialize"> Reset </v-btn>
      </template>
    </v-data-table> -->
    <v-table>
      <thead>
        <tr>
          <th class="text-left">#</th>
          <th class="text-left">Tên bài học</th>
          <th class="text-left">Ngày tạo</th>
          <th class="text-left">Cập nhật</th>
          <th class="text-left">Loại bài học</th>
          <th class="text-center" style="min-width: 90px">Action</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(item, index) in data" :key="index">
          <td>{{ item.stt }}</td>
          <td>{{ fixString(item.lessonName) }}</td>
          <td>{{ item.createDateTime }}</td>
          <td>{{ item.updateDateTime }}</td>
          <td>{{ item.lessonType }}</td>
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
  data() {
    return {
      itemsPerPage: 15,
      headers: [
        { title: "#", align: "start", key: "stt", sortable: false },
        { title: "Tên bài học", align: "start", key: "lessonName" },
        { title: "Ngày tạo", align: "start", key: "createDateTime" },
        { title: "Cập nhật", align: "start", key: "updateDateTime" },
        { title: "Loại bài học", align: "start", key: "lessonType" },
        { title: "Thời lượng", align: "start", key: "videoTime" },
        { title: "Action", align: "start", key: "actions" },
      ],
      desserts: [],
    };
  },
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
  created() {
    this.desserts = this.data;
  },
  methods: {
    fixString(val) {
      return val.length > 55 ? val.substring(0, 55) + "..." : val;
    },
  },
};
</script>

<style lang="scss" scoped></style>
