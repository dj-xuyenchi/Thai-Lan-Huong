<template>
  <div>
    <div ref="chart" style="width: 100%; height: 400px"></div>
  </div>
</template>

<script>
import * as echarts from "echarts";

export default {
  mounted() {
    this.renderChart();
  },
  data() {
    return {};
  },
  props: {
    analysticData: Object,
  },
  created() {
    this.ana = this.analysticData;
  },
  methods: {
    renderChart() {
      const chart = echarts.init(this.$refs.chart);
      chart.setOption({
        // Cấu hình của biểu đồ
        title: {
          text: this.analysticData.title,
        },
        tooltip: {
          trigger: "axis",
        },
        legend: {
          data: this.analysticData.category,
        },
        grid: {
          left: "3%",
          right: "4%",
          bottom: "3%",
          containLabel: true,
        },
        toolbox: {
          feature: {
            saveAsImage: {},
          },
        },
        xAxis: {
          type: "category",
          boundaryGap: false,
          data: this.analysticData.timeLine,
        },
        yAxis: {
          type: "value",
        },
        series: this.analysticData.data,
      });
    },
  },
};
</script>
