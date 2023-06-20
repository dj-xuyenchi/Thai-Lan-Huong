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
        title: {
          text: this.analysticData.title,
        },
        tooltip: {
          trigger: "axis",
          axisPointer: {
            // Use axis to trigger tooltip
            type: "shadow", // 'shadow' as default; can also be 'line' or 'shadow'
          },
        },
        legend: {},
        grid: {
          left: "3%",
          right: "4%",
          bottom: "3%",
          containLabel: true,
        },
        xAxis: {
          type: "value",
        },
        yAxis: {
          type: "category",
          data: this.analysticData.timeLine,
        },
        series: [
          {
            name: "Người dùng mới",
            type: "bar",
            stack: "total",
            label: {
              show: true,
            },
            emphasis: {
              focus: "series",
            },
            data: this.analysticData.data[0],
          },
          {
            name: "Người dùng bị khóa",
            type: "bar",
            stack: "total",
            label: {
              show: true,
            },
            emphasis: {
              focus: "series",
            },
            data: this.analysticData.data[1],
          },
          {
            name: "Người dùng bị khóa vĩnh viễn",
            type: "bar",
            stack: "total",
            label: {
              show: true,
            },
            emphasis: {
              focus: "series",
            },
            data: this.analysticData.data[2],
          },
        ],
      });
    },
  },
};
</script>
