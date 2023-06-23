<template>
  <div>
    <!-- <LineChart :analysticData="analysticData" /> -->
  </div>
</template>

<script>
import LineChart from "./ChartConfig/LineChart";
export default {
  // components: { LineChart },
  name: "AnalyticsMain",
  data() {
    return {
      analysticData: {
        title: "Thống kê Google Analytics",
        category: [
          "Tổng số lượt nhấp",
          "Tổng số lượt hiển thị",
          "CTR Trung bình",
          "Vị trí",
        ],
        timeLine: [
          "Thứ hai",
          "Thứ ba",
          "Thứ tư",
          "Thứ năm",
          "Thứ sáu",
          "Thứ bảy",
          "Chủ nhật",
        ],
        data: [
          {
            name: "Tổng số lượt nhấp",
            type: "line",
            stack: "Total",
            data: [120, 132, 101, 134, 90, 230, 210],
          },
          {
            name: "Tổng số lượt hiển thị",
            type: "line",
            stack: "Total",
            data: [220, 182, 191, 234, 290, 330, 310],
          },
          {
            name: "CTR Trung bình",
            type: "line",
            stack: "Total",
            data: [150, 232, 201, 154, 190, 330, 410],
          },
          {
            name: "Vị trí",
            type: "line",
            stack: "Total",
            data: [320, 332, 301, 334, 390, 330, 320],
          },
        ],
      },
    };
  },
};
</script>

<style lang="scss" scoped></style>
