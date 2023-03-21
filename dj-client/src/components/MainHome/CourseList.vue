<template>
  <div class="course-list-container">
    <div>
      <span
        style="
          color: #82919b;
          font-size: 14px;
          margin-right: 1%;
          padding-left: 14px;
        "
        ><font-awesome-icon
          icon="fa-solid fa-users"
          color="black"
          style="margin-right: 5px"
        /><span style="color: #36ea7c; font-weight: 550">20.012+</span> Học viên
        đã học</span
      >
      <span style="color: #82919b; font-size: 14px"
        ><font-awesome-icon
          icon="fa-solid fa-users"
          color="black"
          style="margin-right: 5px"
        /><span style="color: #4fc3f7; font-weight: 550">20.012+</span> Học viên
        đang học</span
      >
    </div>
    <span
      style="
        color: #242424;
        font-size: 24px;
        font-weight: 900;
        padding-left: 14px;
        font: system-ui, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif,
          'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol';
      "
      >Danh sách khóa học
    </span>
    <v-badge
      color="info"
      content="Free"
      floating
      style="font-size: 24px"
    ></v-badge>
    <div class="course-list">
      <CourseItem
        coursePath="https://bizflyportal.mediacdn.vn/thumb_wm/1000,100/bizflyportal/images/htm16157917934978.jpg"
      />
      <CourseItem
        coursePath="https://dizibrand.com/wp-content/uploads/2021/02/Java-Dizibrand-1.jpg"
      />
      <CourseItem
        coursePath="https://mona.media/wp-content/uploads/2022/10/c.png"
      />
      <CourseItem
        coursePath="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT5VIqdj8xIQYxiV8_0ceQ-RkZI3mFL84GGZg&usqp=CAU"
      />
      <CourseItem
        coursePath="https://support.cloud365.vn/images/img-sql-cloud-server/sql_cloud.png"
      />
      <CourseItem
        coursePath="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT_kLAPvFOhN0XhbWuzbqBTuUbZYC93RAHO9ohRxK8u86aOVeQUl3A3kCnqkPMGtwyJsY4&usqp=CAU"
      />
      <CourseItem
        coursePath="https://www.freecodecamp.org/news/content/images/2022/11/What-is.png"
      />
    </div>
  </div>
</template>

<script>
import CourseItem from "./CourseItem.vue";
export default {
  name: "CourseList",
  components: {
    CourseItem,
  },
};
</script>

<style lang="css" scoped>
.course-list-container {
  margin-left: 3%;
  width: 92%;
}
.course-list-container .course-list {
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
}
@media screen and (max-width: 739px) {
  .course-item {
    width: 100% !important;
  }

  .course-item .item-hover {
    height: 200px !important;
  }

  .course-item img {
    height: 200px !important;
  }
}
@media screen and (max-width: 1023px) and (min-width: 740px) {
  .course-item {
    width: 50% !important;
  }
}

@media screen and (max-width: 1370px) and (min-width: 1023px) {
  .course-item {
    width: 33.33% !important;
  }
}
</style>
