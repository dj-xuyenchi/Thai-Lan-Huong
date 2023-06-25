<template>
  <div>
    <v-table>
      <thead>
        <tr>
          <th class="text-left">#</th>
          <th class="text-left">Họ tên</th>
          <th class="text-left">Tư vấn</th>
          <th class="text-left">Ghi chú</th>
          <th class="text-left">Ngày tạo yêu cầu</th>
          <th>Action</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(item, index) in tableData" :key="index">
          <td>{{ item.stt }}</td>
        </tr>
      </tbody>
    </v-table>
  </div>
</template>

<script>
export default {
  name: "AdviceTable",
  data() {
    return {
      itemsPerPage: 15,
      desserts: [],
    };
  },
  methods: {
    fixName(vari) {
      return vari.substring(0, 36) + "...";
    },
  },
  props: {
    tableData: [],
    getBlogPage: Function,
  },
};
</script>

<style lang="scss" scoped></style>
