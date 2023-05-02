<template>
  <v-table>
    <thead>
      <tr>
        <th class="text-left">Thứ tự</th>
        <th class="text-left">Giải thích đầu vào</th>
        <th class="text-left">Input</th>
        <th class="text-left">Output</th>
        <th class="text-left">Loại case</th>
        <th class="text-left">Action</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="(item, index) in list" :key="index">
        <td>{{ item.sortNumber }}</td>
        <td>{{ item.testCaseDetail }}</td>
        <td>{{ item.input }}</td>
        <td>{{ item.output }}</td>
        <td>{{ item.isLock ? "Case ẩn" : "Case mở" }}</td>
        <td>1</td>
      </tr>
    </tbody>
  </v-table>
</template>
<script>
export default {
  data() {
    return {
      list: [],
    };
  },
  props: {
    listTestCase: [],
  },
  created() {
    this.list = this.listTestCase;
  },
};
</script>
