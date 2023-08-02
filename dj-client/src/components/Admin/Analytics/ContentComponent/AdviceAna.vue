<template>
  <div style="margin: 24px 0 0 0">
    <v-card>
      <div style="display: block; margin-bottom: 80px">
        <v-select
          v-model="opt"
          label="Thống kê theo"
          :items="listOpt"
          variant="outlined"
          item-title="name"
          persistent-hint
          return-object
          item-value="id"
          density="compact"
          style="margin: 20px 0 0 8px; width: 20%; float: left"
          @update:modelValue="changeOpt()"
        ></v-select>
      </div>
      <div style="height: 40px; position: relative" v-if="opt.id == 3">
        <div style="position: absolute; left: 10px">
          <span style="color: blue">Từ : </span
          ><input type="date" name="" v-model="openTime" @input="filterTime" />
          <span style="margin: 0 20px 0 20px">--</span>
          <span style="color: blue">Đến : </span>
          <input type="date" name="" v-model="closeTime" @input="filterTime" />
        </div>
      </div>
      <BarLabelRotationAdvice
        ref="lineChart2"
        :title="adviceTitle"
        :courseAna="courseAna"
      />
    </v-card>
  </div>
</template>

<script>
import AdminAPI from "../../../../apis/APIAdmin/AdminAPI";
import BarLabelRotationAdvice from "../ChartConfig/BarLabelRotationAdvice.vue";
export default {
  name: "AdviceAna",
  data() {
    return {
      opt: {
        id: 1,
        name: "Tháng",
      },
      listOpt: [
        {
          id: 1,
          name: "Tháng",
        },
        {
          id: 2,
          name: "Quý",
        },
        {
          id: 3,
          name: "Tùy chọn",
        },
      ],
      optTuVan: { id: 6, name: "Tất cả" },
      listOptTuVan: [
        { id: 1, name: "Học 1:1" },
        { id: 2, name: "Định hướng nghành" },
        { id: 3, name: "Cơ hội việc làm" },
        { id: 4, name: "Phỏng vấn & CV" },
        { id: 5, name: "Khác" },
        { id: 6, name: "Tất cả" },
      ],
      optTrangThai: { id: 3, name: "Tất cả" },
      listOptTrangThai: [
        { id: 1, name: "Chưa liên hệ" },
        { id: 2, name: "Đã liên hệ" },
        { id: 3, name: "Tất cả" },
      ],
      adviceTitle: [
        "Học 1:1",
        "Định hướng nghành",
        "Cơ hội việc làm",
        "Phỏng vấn & CV",
        "Khác",
        "Thống kê tư vấn",
      ],
      courseAna: {},
    };
  },
  components: { BarLabelRotationAdvice },
  mounted() {
    this.getCourseAna(-1);
  },
  methods: {
    async getCourseAna(type) {
      const data = await AdminAPI.getCourseAna(
        type,
        localStorage.getItem("token")
      );
      this.courseAna = data;
    },
    changeOpt() {
      console.log();
    },
  },
  watch: {
    courseAna: {
      immediate: true,
      deep: true,
      handler() {
        // Gọi phương thức renderChart() của LineChart
        this.$nextTick(() => {
          if (!this.$refs.lineChart2) {
            return;
          }
          this.$refs.lineChart2.renderChart();
        });
      },
    },
  },
};
</script>

<style lang="scss" scoped></style>
