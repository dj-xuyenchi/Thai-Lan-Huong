<template>
  <div class="course-item">
    <v-hover v-slot="{ isHovering, props }">
      <v-card
        ref="gg"
        class="mx-auto rounded-xl item-hover"
        v-bind="props"
        variant="none"
        height="176"
      >
        <img
          src="https://cmay.vn/wp-content/uploads/2022/12/1_unnamed-file.html.jpg"
          alt=""
        />
        <v-overlay
          :model-value="isHovering"
          contained
          scrim="#036358"
          class="align-center justify-center"
        >
          <v-btn variant="flat rounded-xl">Xem khóa học</v-btn>
        </v-overlay>
      </v-card>
    </v-hover>
    <div class="course-detail">
      <span
        style="
          color: #242424;
          font-size: 16px;
          font-weight: 500;
          font: system-ui, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif,
            'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol';
        "
        >HTML - CSS Cơ bản</span
      >
      <span
        style="
          color: #242424;
          font-size: 16px;
          font-weight: 500;
          font: system-ui, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif,
            'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol';
          position: absolute;
          right: 0;
        "
        >400.000</span
      >
    </div>
  </div>
</template>

<script>
import ref from "vue";
export default {
  name: "CourseItem",
  data: () => ({
    // v-card--variant-elevated
    overlay: false,
  }),
  mounted() {
    const g = this.$refs.gg;
    console.log(g);
  },
};
</script>

<style lang="css" scoped>
.course-item {
  margin-top: 14px;
  width: 24.25%;
  margin-bottom: 36px;
}

.course-item img {
  width: 100%;
  height: 176px;
}
.course-item .course-detail {
  display: flex;
  align-items: flex-start;
  position: relative;
  width: 100%;
  margin-top: 6px;
}
.item-hover:hover {
  cursor: pointer;
}
.course-detail span:hover {
  cursor: pointer;
}
</style>
