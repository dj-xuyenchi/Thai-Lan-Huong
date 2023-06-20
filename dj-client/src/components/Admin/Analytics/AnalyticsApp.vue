<template>
  <div>
    <v-card>
      <div style="display: block; margin-bottom: 80px">
        <v-select
          v-model="optNewUser"
          label="Thống kê theo"
          :items="listOptNewUser"
          variant="outlined"
          item-title="name"
          persistent-hint
          return-object
          item-value="id"
          density="compact"
          style="margin: 20px 0 0 8px; width: 20%; float: left"
          @update:modelValue="changeOptUser()"
        ></v-select>
        <v-select
          v-model="optBoLoc"
          label="Bộ lọc"
          :items="listOptBoLoc"
          variant="outlined"
          item-title="name"
          persistent-hint
          return-object
          item-value="id"
          density="compact"
          style="margin: 20px 0 0 8px; width: 20%; float: left"
          @update:modelValue="changeBoLoc()"
        ></v-select>
        <v-select
          v-model="optTypeChart"
          label="Loại biểu đồ"
          :items="listOptTypeChart"
          variant="outlined"
          item-title="name"
          persistent-hint
          return-object
          item-value="id"
          density="compact"
          style="margin: 20px 0 0 8px; width: 20%; float: left"
        ></v-select>
        <div v-if="optNewUser.id != 3" style="display: inline">
          <span style="color: blue">Từ </span><v-date-picker></v-date-picker>
          <span style="color: blue">Đến </span>
          <input type="date" name="" value="" />
        </div>
      </div>
      <LineChart
        v-if="optTypeChart.id == 1"
        ref="lineChart"
        :analysticData="dataChartNewUser"
        :key="dataChartNewUser"
      />
      <StackedHorizontalBar
        v-if="optTypeChart.id == 2"
        ref="lineChart"
        :analysticData="dataChartNewUser"
        :key="dataChartNewUser"
      />
    </v-card>
  </div>
</template>

<script>
import AdminAPI from "../../../apis/APIAdmin/AdminAPI";
import LineChart from "./ChartConfig/LineChart";
import StackedHorizontalBar from "./ChartConfig/StackedHorizontalBar";
import { reactive } from "vue";
export default {
  name: "AnalyticsApp",
  components: { LineChart, StackedHorizontalBar },
  data() {
    return {
      optNewUser: {
        id: 1,
        name: "Tuần",
      },
      listOptNewUser: [
        {
          id: 1,
          name: "Tuần",
        },
        {
          id: 2,
          name: "Tháng",
        },
        {
          id: 3,
          name: "Khoảng thời gian",
        },
      ],
      optBoLoc: {
        id: 4,
        name: "Tất cả",
      },
      dataUser: [],
      listOptBoLoc: [
        {
          id: 1,
          name: "Người dùng mới",
        },
        {
          id: 2,
          name: "Người dùng bị khóa",
        },
        {
          id: 3,
          name: "Người dùng bị khóa vĩnh viễn",
        },
        {
          id: 4,
          name: "Tất cả",
        },
      ],
      optTypeChart: {
        id: 1,
        name: "Biểu đồ đường kẻ",
      },
      listOptTypeChart: [
        {
          id: 1,
          name: "Biểu đồ đường kẻ",
        },
        {
          id: 2,
          name: "Biểu đồ khối",
        },
      ],
      dataChartNewUser: reactive({
        title: "Thống kê người dùng",
        category: reactive([
          "Người dùng mới",
          "Người dùng bị khóa",
          "Người dùng bị khóa vĩnh viễn",
        ]),
        timeLine: reactive([
          "Thứ hai",
          "Thứ ba",
          "Thứ tư",
          "Thứ năm",
          "Thứ sáu",
          "Thứ bảy",
          "Chủ nhật",
        ]),
        data: reactive([]),
      }),
    };
  },
  created() {
    this.getAnalytic();
  },
  methods: {
    async getAnalytic() {
      const data = await AdminAPI.getAnalytic(localStorage.getItem("token"));
      this.dataUser = data.data.listOption;
      this.dataChartNewUser.data[0] =
        this.optNewUser.id == 1
          ? this.dataUser[0].dataWeek
          : this.dataUser[0].dataMonth;
      this.dataChartNewUser.data[1] =
        this.optNewUser.id == 1
          ? this.dataUser[1].dataWeek
          : this.dataUser[1].dataMonth;
      this.dataChartNewUser.data[2] =
        this.optNewUser.id == 1
          ? this.dataUser[2].dataWeek
          : this.dataUser[2].dataMonth;
    },
    changeBoLoc() {
      if (this.optBoLoc.id == 1) {
        this.dataChartNewUser.data = [
          this.optNewUser.id == 1
            ? this.dataUser[0].dataWeek
            : this.dataUser[0].dataMonth,
          [],
          [],
        ];
      }
      if (this.optBoLoc.id == 2) {
        this.dataChartNewUser.data = [
          [],
          this.optNewUser.id == 1
            ? this.dataUser[1].dataWeek
            : this.dataUser[1].dataMonth,
          [],
        ];
      }
      if (this.optBoLoc.id == 3) {
        this.dataChartNewUser.data = [
          [],
          [],
          this.optNewUser.id == 1
            ? this.dataUser[2].dataWeek
            : this.dataUser[2].dataMonth,
        ];
      }
      if (this.optBoLoc.id == 4) {
        this.dataChartNewUser.data = [
          this.optNewUser.id == 1
            ? this.dataUser[0].dataWeek
            : this.dataUser[0].dataMonth,
          this.optNewUser.id == 1
            ? this.dataUser[1].dataWeek
            : this.dataUser[1].dataMonth,
          this.optNewUser.id == 1
            ? this.dataUser[2].dataWeek
            : this.dataUser[2].dataMonth,
        ];
      }
    },
    changeOptUser() {
      if (this.optNewUser.id == 3) {
        return;
      }
      this.dataChartNewUser.timeLine =
        this.optNewUser.id == 1
          ? [
              "Thứ hai",
              "Thứ ba",
              "Thứ tư",
              "Thứ năm",
              "Thứ sáu",
              "Thứ bảy",
              "Chủ nhật",
            ]
          : [
              "Tháng 1",
              "Tháng 2",
              "Tháng 3",
              "Tháng 4",
              "Tháng 5",
              "Tháng 6",
              "Tháng 7",
              "Tháng 8",
              "Tháng 9",
              "Tháng 10",
              "Tháng 11",
              "Tháng 12",
            ];
      this.dataChartNewUser.data[0] =
        this.optNewUser.id == 1
          ? this.dataUser[0].dataWeek
          : this.dataUser[0].dataMonth;
      this.dataChartNewUser.data[1] =
        this.optNewUser.id == 1
          ? this.dataUser[1].dataWeek
          : this.dataUser[1].dataMonth;
      this.dataChartNewUser.data[2] =
        this.optNewUser.id == 1
          ? this.dataUser[2].dataWeek
          : this.dataUser[2].dataMonth;
      this.changeBoLoc();
    },
  },
  watch: {
    dataChartNewUser: {
      immediate: true,
      deep: true,
      handler() {
        // Gọi phương thức renderChart() của LineChart
        this.$nextTick(() => {
          this.$refs.lineChart.renderChart();
        });
      },
    },
  },
};
</script>

<style lang="scss" scoped></style>
