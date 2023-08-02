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
      </div>
      <div v-if="optNewUser.id == 3" style="height: 40px; position: relative">
        <div style="position: absolute; left: 10px">
          <span style="color: blue">Từ : </span
          ><input type="date" name="" v-model="openTime" @input="filterTime" />
          <span style="margin: 0 20px 0 20px">--</span>
          <span style="color: blue">Đến : </span>
          <input type="date" name="" v-model="closeTime" @input="filterTime" />
        </div>
      </div>
      <LineChart
        v-if="optTypeChart.id == 1 && optNewUser.id != 3"
        ref="lineChart"
        :analysticData="dataChartNewUser"
        :key="dataChartNewUser"
      />
      <StackedHorizontalBar
        v-if="optTypeChart.id == 2 && optNewUser.id != 3"
        ref="lineChart"
        :analysticData="dataChartNewUser"
        :key="dataChartNewUser"
      />
      <LargeAreaChart
        v-if="optNewUser.id == 3"
        ref="lineChart2"
        :optBoLoc="optBoLoc.id"
        :dataLargeArea="dataLargeArea"
      />
    </v-card>
    <CourseAna />
    <br />
    <!-- <AdviceAna style="margin-bottom: 24px" /> -->
  </div>
  <v-snackbar v-model="snackbar">
    {{ text }}
    <template v-slot:actions>
      <v-btn color="green" variant="text" @click="snackbar = false">
        Đóng
      </v-btn>
    </template>
  </v-snackbar>
</template>

<script>
import AdminAPI from "../../../apis/APIAdmin/AdminAPI";
import LineChart from "./ChartConfig/LineChart";
import CourseAna from "./ContentComponent/CourseAna.vue";
import AdviceAna from "./ContentComponent/AdviceAna.vue";
import StackedHorizontalBar from "./ChartConfig/StackedHorizontalBar";
import LargeAreaChart from "./ChartConfig/LargeAreaChart";
import { reactive } from "vue";
import { mapMutations } from "vuex";
export default {
  name: "AnalyticsApp",
  components: {
    // AdviceAna,
    CourseAna,
    LineChart,
    StackedHorizontalBar,
    LargeAreaChart,
  },
  data() {
    return {
      isFilter: false,
      snackbar: false,
      text: "",
      openTime: null,
      closeTime: null,
      dataLargeArea: null,
      optNewUser: {
        id: 1,
        name: "7 ngày trước",
      },
      listOptNewUser: [
        {
          id: 1,
          name: "7 ngày trước",
        },
        {
          id: 2,
          name: "12 Tháng",
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
      dataUser: null,
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
        timeLine: reactive(this.weekArr()),
        data: reactive([]),
      }),
    };
  },
  created() {
    this.getAnalytic();
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    async filterTime() {
      if (!this.openTime || !this.closeTime) {
        return;
      }
      if (this.openTime >= this.closeTime) {
        this.text =
          "Thời gian kết thúc không được bằng hoặc trước thời gian bắt đầu!";
        this.snackbar = true;
        return;
        //     getAnalyticFilter;
      }
      this.setIsLoadedData(true);
      this.isFilter = true;
      const data = await AdminAPI.getAnalyticFilter(
        this.openTime,
        this.closeTime,
        localStorage.getItem("token")
      );
      this.dataLargeArea = data.data;
      this.setIsLoadedData(false);
    },
    async getAnalytic() {
      this.setIsLoadedData(true);
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
      this.setIsLoadedData(false);
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
    async changeOptUser() {
      if (this.isFilter && this.optNewUser.id != 3) {
        await this.getAnalytic();
      }
      this.dataChartNewUser.timeLine =
        this.optNewUser.id == 1
          ? this.weekArr()
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
    weekArr() {
      var d = new Date();
      const arr = [];
      for (var i = 6; i >= 0; i--) {
        d.setDate(d.getDate() - i);
        arr.push(d.getDate() + "/" + Number(d.getMonth() + 1));
        d.setDate(d.getDate() + i);
      }
      return arr;
    },
  },
  watch: {
    dataChartNewUser: {
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
    dataLargeArea: {
      immediate: true,
      deep: true,
      handler() {
        // Gọi phương thức renderChart() của LineChart
        this.$nextTick(() => {
          if (!this.$refs.lineChart2) {
            return;
          }
          this.$refs.lineChart2.renderChart();
        });
      },
    },
    optBoLoc: {
      immediate: true,
      deep: true,
      handler() {
        // Gọi phương thức renderChart() của LineChart
        this.$nextTick(() => {
          if (!this.$refs.lineChart2) {
            return;
          }

          this.$refs.lineChart2.renderChart();
        });
      },
    },
  },
};
</script>

<style lang="scss" scoped></style>
