<template>
  <div>
    <br />
    <span
      style="
        font-weight: 600;
        font-size: 20px;
        color: black;
        margin: 12px 0 0 0px;
      "
      >{{ title[5] }}</span
    >
    <div
      ref="chart"
      id="main2"
      style="width: 100%; height: 600px; margin-top: 12px"
    ></div>
    <v-dialog v-model="dialog" persistent width="900px">
      <v-card>
        <v-card-title class="text-h5"> </v-card-title>
        <v-card-text>
          <PolarAreaChart :chartData="chartData" />
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="green-darken-1" variant="text" @click="dialog = false">
            Đồng ý
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
</template>

<script>
import * as echarts from "echarts";
import PolarAreaChart from "../ChartJsConfig/PolarAreaChart.vue";
export default {
  mounted() {
    this.renderChart();
  },
  components: { PolarAreaChart },
  data() {
    return { dialog: false, chartData: {} };
  },
  props: {
    courseAna: Object,
    title: [],
  },
  methods: {
    handleOpen(params) {
      this.dialog = true;
      this.chartData = {
        data: {},
        title: this.title[5],
      };
      console.log(params);
    },
    renderChart() {
      var app = {};
      var chartDom = document.getElementById("main2");
      var myChart = echarts.init(chartDom);
      myChart.on("click", this.handleOpen);
      var option;
      const posList = [
        "left",
        "right",
        "top",
        "bottom",
        "inside",
        "insideTop",
        "insideLeft",
        "insideRight",
        "insideBottom",
        "insideTopLeft",
        "insideTopRight",
        "insideBottomLeft",
        "insideBottomRight",
      ];
      app.configParameters = {
        rotate: {
          min: -90,
          max: 90,
        },
        align: {
          options: {
            left: "left",
            center: "center",
            right: "right",
          },
        },
        verticalAlign: {
          options: {
            top: "top",
            middle: "middle",
            bottom: "bottom",
          },
        },
        position: {
          options: posList.reduce(function (map, pos) {
            map[pos] = pos;
            return map;
          }, {}),
        },
        distance: {
          min: 0,
          max: 100,
        },
      };
      app.config = {
        rotate: 90,
        align: "left",
        verticalAlign: "middle",
        position: "insideBottom",
        distance: 15,
        onChange: function () {
          const labelOption = {
            rotate: app.config.rotate,
            align: app.config.align,
            verticalAlign: app.config.verticalAlign,
            position: app.config.position,
            distance: app.config.distance,
          };
          myChart.setOption({
            series: [
              {
                label: labelOption,
              },
              {
                label: labelOption,
              },
              {
                label: labelOption,
              },
              {
                label: labelOption,
              },
            ],
          });
        },
      };
      const labelOption = {
        show: true,
        position: app.config.position,
        distance: app.config.distance,
        align: app.config.align,
        verticalAlign: app.config.verticalAlign,
        rotate: app.config.rotate,
        formatter: "{c}  {name|{a}}",
        fontSize: 16,
        rich: {
          name: {},
        },
      };
      option = {
        tooltip: {
          trigger: "axis",
          axisPointer: {
            type: "shadow",
          },
        },
        legend: {
          data: this.title,
        },
        toolbox: {
          show: true,
          orient: "vertical",
          left: "right",
          top: "center",
          feature: {
            mark: { show: true },
            magicType: { show: true, type: ["line", "bar", "stack"] },
            saveAsImage: { show: true },
          },
        },
        xAxis: [
          {
            type: "category",
            axisTick: { show: false },
            data: this.courseAna.listCourse,
          },
        ],
        yAxis: [
          {
            type: "value",
          },
        ],
        series: [
          {
            name: this.title[0],
            type: "bar",
            barGap: 0,
            label: labelOption,
            emphasis: {
              focus: "series",
            },
            data: this.courseAna.total,
          },
          {
            name: this.title[1],
            type: "bar",
            label: labelOption,
            emphasis: {
              focus: "series",
            },
            data: this.courseAna.learning,
          },
          {
            name: this.title[2],
            type: "bar",
            label: labelOption,
            emphasis: {
              focus: "series",
            },
            data: this.courseAna.done,
          },
          {
            name: this.title[3],
            type: "bar",
            label: labelOption,
            emphasis: {
              focus: "series",
            },
            data: this.courseAna.done,
          },
          {
            name: this.title[4],
            type: "bar",
            label: labelOption,
            emphasis: {
              focus: "series",
            },
            data: this.courseAna.done,
          },
        ],
      };

      option && myChart.setOption(option);
    },
  },
};
</script>
