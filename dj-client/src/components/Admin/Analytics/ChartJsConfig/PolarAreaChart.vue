<template>
  <div>
    <canvas ref="chartCanvas"></canvas>
  </div>
</template>

<script>
import { defineComponent } from "vue";
import { Chart, registerables, Utils } from "chart.js";

Chart.register(...registerables);

export default defineComponent({
  name: "PolarAreaChart",
  data() {
    return {
      chart: null,
    };
  },
  props: {
    chartData: {},
  },
  mounted() {
    this.renderChart();
  },
  methods: {
    renderChart() {
      const labels = ["Tổng số học viên", "Đang học", "Đã học xong"];
      const data = {
        labels: labels,
        datasets: [
          {
            label: "Dataset 1",
            data: [
              this.chartData.data.total,
              this.chartData.data.learning,
              this.chartData.data.done,
            ],
            backgroundColor: [
              "rgba(255, 99, 132,0.5)",
              "rgba(75, 192, 192,0.5)",
              "rgba(255, 205, 86,0.5)",
            ],
          },
        ],
      };
      const chartConfig = {
        type: "polarArea",
        data: data,
        options: {
          responsive: true,
          scales: {
            r: {
              pointLabels: {
                display: true,
                centerPointLabels: true,
                font: {
                  size: 18,
                },
              },
            },
          },
          plugins: {
            legend: {
              position: "top",
            },
            title: {
              display: true,
              text: this.chartData.title,
            },
          },
        },
      };

      const canvas = this.$refs.chartCanvas;
      this.chart = new Chart(canvas, chartConfig);
    },
  },
});
</script>
