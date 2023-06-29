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
          <td>{{ (index + 1) * page }}</td>
          <td>{{ item.name }}</td>
          <td>
            {{
              item.typeAdvice == 1
                ? "Học 1:1"
                : item.typeAdvice == 2
                ? "Định hướng nghề"
                : item.typeAdvice == 3
                ? "Cơ hội việc làm"
                : item.typeAdvice == 4
                ? "Phỏng vấn & CV"
                : "Khác"
            }}
          </td>
          <td>{{ item.note }}</td>
          <td>{{ fixDate(item.sendRequest) }}</td>
          <td><AdviceDetail :idAdvice="item.id" /></td>
        </tr>
      </tbody>
    </v-table>
  </div>
</template>

<script>
import AdviceDetail from "./AdviceDetail.vue";
export default {
  name: "AdviceTable",
  components: { AdviceDetail },
  data() {
    return {
      itemsPerPage: 15,
      desserts: [],
    };
  },
  methods: {
    fixDate(vari) {
      return (
        vari.substring(8, 10) + vari.substring(4, 8) + vari.substring(0, 4)
      );
    },
  },
  props: {
    tableData: [],
    page: Number,
  },
};
</script>

<style lang="scss" scoped></style>
