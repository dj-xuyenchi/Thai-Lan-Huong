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
        series: [
          {
            name: "Người dùng mới",
            type: "line",
            stack: "Total",
            data: this.analysticData.data[0],
          },
          {
            name: "Người dùng bị khóa",
            type: "line",
            stack: "Total",
            data: this.analysticData.data[1],
          },
          {
            name: "Người dùng bị khóa vĩnh viễn",
            type: "line",
            stack: "Total",
            data: this.analysticData.data[2],
          },
        ],
      });
    },
  },
};
</script>
