<template>
  <div style="margin: 24px 0 0 0">
    <v-card>
      <div style="display: block; margin-bottom: 80px">
        <v-select
          v-model="opt"
          label="Thống kê theo"
          :items="listOpt"
          variant="outlined"
          item-title="name"
          persistent-hint
          return-object
          item-value="id"
          density="compact"
          style="margin: 20px 0 0 8px; width: 20%; float: left"
          @update:modelValue="changeOpt()"
        ></v-select>
        <v-select
          v-model="optBoLoc2"
          label="Loại khóa học"
          :items="listOptBoLoc2"
          variant="outlined"
          item-title="name"
          persistent-hint
          return-object
          item-value="id"
          density="compact"
          style="margin: 20px 0 0 8px; width: 20%; float: left"
          @update:modelValue="changeBoLoc2()"
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
      </div>
      <div style="height: 40px; position: relative" v-if="opt.id == 3">
        <div style="position: absolute; left: 10px">
          <span style="color: blue">Từ : </span
          ><input type="date" name="" v-model="openTime" @input="filterTime" />
          <span style="margin: 0 20px 0 20px">--</span>
          <span style="color: blue">Đến : </span>
          <input type="date" name="" v-model="closeTime" @input="filterTime" />
        </div>
      </div>
      <BarLabelRotation
        ref="lineChart"
        :title="courseAnaTitle"
        :courseAna="courseAna"
      />
    </v-card>
  </div>
</template>

<script>
import AdminAPI from "../../../../apis/APIAdmin/AdminAPI";
import BarLabelRotation from "../ChartConfig/BarLabelRotation.vue";
export default {
  name: "CourseAna",
  data() {
    return {
      opt: {
        id: 1,
        name: "Tháng",
      },
      listOpt: [
        {
          id: 1,
          name: "Tháng",
        },
        {
          id: 2,
          name: "Quý",
        },
        {
          id: 3,
          name: "Tùy chọn",
        },
      ],
      optBoLoc: { id: 4, name: "Tất cả" },
      listOptBoLoc: [
        { id: 1, name: "Tổng số học viên" },
        { id: 2, name: "Đang học" },
        { id: 3, name: "Đã học xong" },
        { id: 4, name: "Tất cả" },
      ],
      optBoLoc2: { id: 6, name: "Tất cả" },
      listOptBoLoc2: [
        { id: 1, name: "Back End" },
        { id: 2, name: "Front End" },
        { id: 3, name: "Cơ sở dữ liệu" },
        { id: 4, name: "Full Stack" },
        { id: 5, name: "Cấu trúc dữ liệu và giải thuật" },
        { id: 6, name: "Tất cả" },
      ],
      courseAnaTitle: [
        "Tổng số học viên",
        "Đang học",
        "Đã học xong",
        "Thông kê học viên theo khóa học",
      ],

      courseAna: {},
    };
  },
  components: { BarLabelRotation },
  mounted() {
    this.getCourseAna();
  },
  methods: {
    changeOpt() {
      //
    },
    changeBoLoc() {
      //
    },
    async getCourseAna() {
      const data = await AdminAPI.getCourseAna(localStorage.getItem("token"));
      this.courseAna = data;
    },
  },
  watch: {
    courseAna: {
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
  },
};
</script>

<style lang="scss" scoped></style>
