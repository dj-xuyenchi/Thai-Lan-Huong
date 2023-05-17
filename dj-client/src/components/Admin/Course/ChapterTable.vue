<template>
  <v-table>
    <thead>
      <tr>
        <th class="text-left">Thứ tự</th>
        <th class="text-left">Tên học phần</th>
        <th class="text-left">Số bài học</th>
        <th class="text-left">Thời lượng</th>
        <th class="text-center">Action</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="(item, index) in listTestCase" :key="index">
        <td>{{ item.sortNumber }}</td>
        <td>{{ item.testCaseDetail }}</td>
        <td>{{ item.input }}</td>
        <td>{{ item.isLock ? "Case ẩn" : "Case mở" }}</td>
        <td
          style="
            display: flex;
            justify-content: space-evenly;
            align-items: center;
          "
        >
          <BtnUpdateChapter
            :testCaseId="item.testCaseId"
            :getTestCase="getTestCase"
            :item="item"
          />
          <BtnRemoveChapter
            :testCaseId="item.testCaseId"
            :getTestCase="getTestCase"
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
    listTestCase: [],
    getTestCase: Function,
  },
};
</script>
