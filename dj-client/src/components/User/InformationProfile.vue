<template>
  <div class="infor-profile">
    <div class="infor">
      <div class="left">
        <div class="information">
          <h4
            style="
              font-family: system-ui, 'Segoe UI', Roboto, Helvetica, Arial,
                sans-serif, 'Apple Color Emoji', 'Segoe UI Emoji',
                'Segoe UI Symbol';
              font-size: 16px;
              font-weight: 600;
              line-height: 40px;
              margin-left: 12px;
            "
          >
            Giới thiệu
          </h4>
          <span
            style="
              font-size: 14px;
              font-family: system-ui, 'Segoe UI', Roboto, Helvetica, Arial,
                sans-serif, 'Apple Color Emoji', 'Segoe UI Emoji',
                'Segoe UI Symbol';
              display: block;
              width: 90%;
              margin-left: 5%;
            "
          >
            <font-awesome-icon
              icon="fa-solid fa-users"
              style="margin-right: 4px"
            />Là thành viên của
            <span style="font-weight: 600">DJ - CodeMaster</span> từ
            {{ " " + item.joinTime }}
          </span>
        </div>
        <div class="activity">
          <h4
            style="
              font-family: system-ui, 'Segoe UI', Roboto, Helvetica, Arial,
                sans-serif, 'Apple Color Emoji', 'Segoe UI Emoji',
                'Segoe UI Symbol';
              font-size: 16px;
              font-weight: 600;
              line-height: 40px;
              margin-left: 12px;
            "
          >
            Hoạt động gần đây
          </h4>
          <span
            style="
              font-size: 14px;
              font-family: system-ui, 'Segoe UI', Roboto, Helvetica, Arial,
                sans-serif, 'Apple Color Emoji', 'Segoe UI Emoji',
                'Segoe UI Symbol';
              margin-left: 12px;
            "
          >
            Chưa có hoạt đồng nào
          </span>
        </div>
      </div>
      <div class="right">
        <div class="course">
          <h4
            style="
              font-family: system-ui, 'Segoe UI', Roboto, Helvetica, Arial,
                sans-serif, 'Apple Color Emoji', 'Segoe UI Emoji',
                'Segoe UI Symbol';
              font-size: 16px;
              font-weight: 600;
              line-height: 40px;
              margin-left: 12px;
            "
          >
            Các khóa học đã đăng ký
          </h4>
          <CourseResigterItem
            v-for="(item, index) in item.resigtedCourse"
            :key="index"
            :item="item"
          >
          </CourseResigterItem>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import CourseResigterItem from "./CourseResigtedItem";
export default {
  components: { CourseResigterItem },
  data() {
    return {
      course: [{}],
    };
  },
  props: {
    item: Object,
  },
};
</script>

<style lang="css" scoped>
.infor-profile {
  position: absolute;
  width: 70%;
  left: 15%;
  top: 440px;
}
.infor-profile .infor {
  width: 96%;
  margin-left: 2%;
}

.infor-profile .infor .left {
  width: 30%;
  float: left;
}

.infor-profile .infor .left .information {
  box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
  height: 120px;
  width: 100%;
  border-radius: 10px;
}

.infor-profile .infor .left .activity {
  box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
  height: 100px;
  margin-top: 12px;
  width: 100%;
  border-radius: 10px;
}
.infor-profile .infor .right {
  width: 69%;
  float: left;
  margin-left: 1%;
}
.infor-profile .infor .right .course {
  box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
  width: 100%;
  display: inline-block;
  border-radius: 10px;
}
</style>
