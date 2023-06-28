<template>
  <div style="margin: 24px 0 0 0">
    <v-card>
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
  name: "AdviceAna",
  data() {
    return {
      courseAnaTitle: [
        "Học 1:1",
        "Định hướng nghành",
        "Cơ hội việc làm",
        "Khác",
      ],

      courseAna: {},
    };
  },
  components: { BarLabelRotation },
  mounted() {
    this.getCourseAna();
  },
  methods: {
    async getCourseAna() {
      const data = await AdminAPI.getCourseAna(localStorage.getItem("token"));
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
