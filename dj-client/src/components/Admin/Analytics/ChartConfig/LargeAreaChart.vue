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
      let base = +new Date(1968, 9, 3);
      let oneDay = 24 * 3600 * 1000;
      let date = ["1999/2/2", "1999/2/3", "1999/2/4"];
      let data1 = [1, 2, 3];
      let data2 = [3, 54, 3];
      let data3 = [2, 2, 33];
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
          text: "Large Area Chart",
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
        series: [
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
        ],
      });
    },
  },
};
</script>
