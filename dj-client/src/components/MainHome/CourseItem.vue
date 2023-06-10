<template>
  <div class="course-item">
    <v-hover v-slot="{ isHovering, props }">
      <v-card
        ref="gg"
        class="mx-auto rounded-xl item-hover course-item-fix"
        v-bind="props"
        variant="none"
        width="380px"
        height="220px"
      >
        <img :src="courseData" alt="" />
        <v-overlay
          :model-value="isHovering"
          contained
          scrim="#036358"
          class="align-center justify-center"
        >
          <router-link
            :to="`/home/course/` + courseId"
            style="text-decoration: none"
            v-if="isActive"
          >
            <v-btn variant="flat rounded-xl">Xem khóa học</v-btn>
          </router-link>
          <v-btn variant="flat rounded-xl" v-if="!isActive">Coming soon</v-btn>
        </v-overlay>
      </v-card>
    </v-hover>
    <div class="course-detail">
      <h5
        style="
          color: #242424;
          font-size: 16px;
          font-weight: 500;
          font: system-ui, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif,
            'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol';
        "
      >
        {{ courseName }}
      </h5>
      <h6
        v-if="isActive"
        style="
          color: #242424;
          font-size: 16px;
          font-weight: 500;
          font: system-ui, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif,
            'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol';
          position: absolute;
          right: 0;
        "
      >
        <font-awesome-icon
          icon="fa-solid fa-users"
          color="black"
          style="margin-right: 5px"
        />{{ studentCount }}
      </h6>
    </div>
  </div>
</template>

<script>
export default {
  name: "CourseItem",
  data: () => ({
    // v-card--variant-elevated
    overlay: false,
  }),
  props: {
    courseData: String,
    courseName: String,
    studentCount: Number,
    courseId: Number,
    isActive: Boolean,
  },
};
</script>

<style lang="css" scoped>
.course-item {
  margin-top: 14px;
  width: 380px;
  height: 220px;
  margin-bottom: 36px;
  padding: 0 14px 0 14px;
  margin-left: 1%;
  margin-bottom: 60px;
}

.course-item img {
  width: 380px;
  height: 220px;
}
.course-item .course-detail {
  display: flex;
  align-items: flex-start;
  position: relative;
  width: 100%;
  margin-top: 14px;
}
.item-hover:hover {
  cursor: pointer;
}
.course-detail span:hover {
  cursor: pointer;
}
@media screen and (min-height: 739px) {
  .course-item img {
    width: 100%;
    height: 240px;
  }
  .course-item-fix {
    height: 240px !important;
  }
}
</style>
