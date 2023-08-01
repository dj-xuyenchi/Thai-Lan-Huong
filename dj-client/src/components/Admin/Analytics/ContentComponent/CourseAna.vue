<template>
  <div style="margin: 24px 0 0 0">
    <v-card>
      <div style="display: block; margin-bottom: 80px">
        <v-select
          v-model="optBoLoc2"
          label="Loại khóa học"
          :items="listOptBoLoc2"
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
      <BarLabelRotation
        ref="lineChart"
        :title="courseAnaTitle"
        :courseAna="courseAna"
      />
    </v-card>
  </div>
</template>

<script>
import AdminAPI from "../../../../apis/APIAdmin/AdminAPI";
import BarLabelRotation from "../ChartConfig/BarLabelRotation.vue";
export default {
  name: "CourseAna",
  data() {
    return {
      optBoLoc2: { id: 6, name: "Tất cả" },
      listOptBoLoc2: [
        { id: 1, name: "Back End" },
        { id: 2, name: "Front End" },
        { id: 3, name: "Cơ sở dữ liệu" },
        { id: 4, name: "Full Stack" },
        { id: 5, name: "Cấu trúc dữ liệu và giải thuật" },
        { id: 6, name: "Tất cả" },
      ],
      courseAnaTitle: [
        "Tổng số học viên",
        "Đang học",
        "Đã học xong",
        "Thông kê học viên theo khóa học",
      ],

      courseAna: {},
    };
  },
  components: { BarLabelRotation },
  mounted() {
    this.getCourseAna(-1);
  },
  methods: {
    changeOpt() {
      this.getCourseAna(this.optBoLoc2.id == 4 ? -1 : this.optBoLoc2.id);
      //
    },
    changeBoLoc() {
      this.getCourseAna(this.optBoLoc2.id == 4 ? -1 : this.optBoLoc2.id);
      //
    },
    async getCourseAna(type) {
      const data = await AdminAPI.getCourseAna(
        type,
        localStorage.getItem("token")
      );
      this.courseAna = data;
    },
  },
  watch: {
    courseAna: {
      immediate: true,
      deep: true,
      handler() {
        // Gọi phương thức renderChart() của LineChart
        this.$nextTick(() => {
          if (!this.$refs.lineChart) {
            return;
          }
          this.$refs.lineChart.renderChart();
        });
      },
    },
  },
};
</script>

<style lang="scss" scoped></style>
