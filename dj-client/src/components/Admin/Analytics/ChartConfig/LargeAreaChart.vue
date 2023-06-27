<template>
  <div>
    <div
      ref="chart"
      style="width: 120%; height: 400px; margin-left: -10%"
    ></div>
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
    dataLargeArea: Object,
    optBoLoc: Number,
  },
  methods: {
    renderChart() {
      if (!this.dataLargeArea) {
        return;
      }
      let date = this.dataLargeArea.date;
      let data1 = this.dataLargeArea.newUser;
      let data2 = this.dataLargeArea.lockUser;
      let data3 = this.dataLargeArea.lockForeverUser;
      let data = [];
      if (this.optBoLoc == 4) {
        data = [
          {
            name: "Người dùng mới",
            type: "line",
            stack: "Total",
            data: data1,
            itemStyle: {
              color: "blue",
            },
          },
          {
            name: "Người dùng bị khóa",
            type: "line",
            stack: "Total",
            data: data2,
            itemStyle: {
              color: "green",
            },
          },
          {
            name: "Người dùng bị khóa vĩnh viễn",
            type: "line",
            stack: "Total",
            data: data3,
            itemStyle: {
              color: "yellow",
            },
          },
        ];
      }
      if (this.optBoLoc == 1) {
        data = [
          {
            name: "Người dùng mới",
            type: "line",
            stack: "Total",
            data: data1,
            itemStyle: {
              color: "blue",
            },
          },
        ];
      }
      if (this.optBoLoc == 2) {
        data = [
          {
            name: "Người dùng bị khóa",
            type: "line",
            stack: "Total",
            data: data2,
            itemStyle: {
              color: "green",
            },
          },
        ];
      }
      if (this.optBoLoc == 3) {
        data = [
          {
            name: "Người dùng bị khóa vĩnh viễn",
            type: "line",
            stack: "Total",
            data: data3,
            itemStyle: {
              color: "yellow",
            },
          },
        ];
      }
      const chart = echarts.init(this.$refs.chart);
      chart.setOption({
        tooltip: {
          trigger: "axis",
          position: function (pt) {
            return [pt[0], "10%"];
          },
        },
        title: {
          left: "center",
          text: "Thống kê người dùng.",
        },
        toolbox: {
          feature: {
            dataZoom: {
              yAxisIndex: "none",
            },
            restore: {},
            saveAsImage: {},
          },
        },
        xAxis: {
          type: "category",
          boundaryGap: false,
          data: date,
        },
        yAxis: {
          type: "value",
          boundaryGap: [0, "100%"],
        },
        dataZoom: [
          {
            type: "inside",
            start: 0,
            end: 10,
          },
          {
            start: 0,
            end: 10,
          },
        ],
        series: data,
      });
    },
  },
};
</script>
