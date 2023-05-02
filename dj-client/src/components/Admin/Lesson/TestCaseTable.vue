<template>
  <v-table>
    <thead>
      <tr>
        <th class="text-left">Thứ tự</th>
        <th class="text-left">Giải thích đầu vào</th>
        <th class="text-left">Input</th>
        <th class="text-left">Output</th>
        <th class="text-left">Loại case</th>
        <th class="text-center">Action</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="(item, index) in listTestCase" :key="index">
        <td>{{ item.sortNumber }}</td>
        <td>{{ item.testCaseDetail }}</td>
        <td>{{ item.input }}</td>
        <td>{{ item.output }}</td>
        <td>{{ item.isLock ? "Case ẩn" : "Case mở" }}</td>
        <td
          style="
            display: flex;
            justify-content: space-evenly;
            align-items: center;
          "
        >
          <BtnUpdateTestCase
            :testCaseId="item.testCaseId"
            :getTestCase="getTestCase"
            :item="item"
          />
          <BtnDeleteTestCase
            :testCaseId="item.testCaseId"
            :getTestCase="getTestCase"
          />
        </td>
      </tr>
    </tbody>
  </v-table>
</template>
<script>
import BtnUpdateTestCase from "./BtnUpdateTestCase";
import BtnDeleteTestCase from "./BtnDeleteTestCase";
export default {
  components: { BtnUpdateTestCase, BtnDeleteTestCase },
  data() {
    return {};
  },
  props: {
    listTestCase: [],
    getTestCase: Function,
  },
};
</script>
