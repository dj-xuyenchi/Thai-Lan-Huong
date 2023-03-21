<template>
  <div class="course-detail-container">
    <div class="course-detail-left">
      <div class="detail-header">
        <h1 style="font-weight: 700; font-size: 30px">
          Khóa học Java từ cơ bản đến Spring
        </h1>
        <h5 style="font-weight: 400">
          Chúng ta sẽ cùng nhau học ngôn ngữ lập trình JAVA và xây dựng 1 ứng
          dụng Web API Spring Boot.
        </h5>
        <div class="require-profit">
          <div class="require-profit-detail">
            <h2 style="font-weight: 700; font-size: 20px">
              Sau khóa học bạn sẽ có khả năng.
            </h2>
            <ul class="list-require-profit">
              <li>
                <font-awesome-icon
                  icon="fa-solid fa-check"
                  class="react-icon"
                  style="margin-right: 12px"
                  color="#29b6f6"
                />Biết cách tạo 1 class JAVA.
              </li>
              <li>
                <font-awesome-icon
                  icon="fa-solid fa-check"
                  class="react-icon"
                  style="margin-right: 12px"
                  color="#29b6f6"
                />Hiểu cách tạo và chạy 1 project JAVA.
              </li>
              <li>
                <font-awesome-icon
                  icon="fa-solid fa-check"
                  class="react-icon"
                  style="margin-right: 12px"
                  color="#29b6f6"
                />Sử dụng được các IDE lập trình JAVA.
              </li>
            </ul>
          </div>
          <div class="require-profit-detail">
            <h2 style="font-weight: 700; font-size: 20px">Yêu cầu học tập.</h2>
            <ul class="list-require-profit">
              <li>
                <font-awesome-icon
                  icon="fa-solid fa-check"
                  class="react-icon"
                  style="margin-right: 12px"
                  color="#29b6f6"
                />Máy tính hệ điều hành Window 7, 8, 10, 11.
              </li>
              <li>
                <font-awesome-icon
                  icon="fa-solid fa-check"
                  class="react-icon"
                  style="margin-right: 12px"
                  color="#29b6f6"
                />Kết nối mạng.
              </li>
              <li>
                <font-awesome-icon
                  icon="fa-solid fa-check"
                  class="react-icon"
                  style="margin-right: 12px"
                  color="#29b6f6"
                />Tối thiểu 2h học mỗi ngày.
              </li>
            </ul>
          </div>
        </div>
      </div>
      <div class="course-lesson">
        <v-list-group value="Actions">
          <template v-slot:activator="{ props }">
            <v-list-item v-bind="props" title="Actions"></v-list-item>
          </template>
          <v-list-item
            v-for="([title, icon], i) in cruds"
            :key="i"
            :value="title"
            :title="title"
            :prepend-icon="icon"
          ></v-list-item>
        </v-list-group>
      </div>
    </div>
    <div class="course-detail-right"></div>
  </div>
</template>

<script>
export default {
  name: "CourseDetail",
  props: {
    courseTitle: String,
    courseSubTitle: String,
  },
  data() {
    return {
      cruds: [
        ["Create", "mdi-plus-outline"],
        ["Read", "mdi-file-outline"],
        ["Update", "mdi-update"],
        ["Delete", "mdi-delete"],
      ],
    };
  },
};
</script>

<style lang="css" scoped>
.course-detail-container {
  width: 95%;
  margin-left: 2.5%;
}
.course-detail-container .course-detail-left {
  width: 60%;
  float: left;
}
.course-detail-container .course-detail-right {
  width: 40%;
  float: left;
}
.course-detail-container .detail-header {
  margin-bottom: 28px;
}
.course-detail-container .detail-header .require-profit {
  margin-top: 28px;
  font: system-ui, "Segoe UI", Roboto, Helvetica, Arial, sans-serif,
    "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol";
}
.course-detail-container .detail-header .require-profit .require-profit-detail {
  width: 50%;
  float: left;
}

.course-detail-container
  .detail-header
  .require-profit
  .require-profit-detail
  .list-require-profit
  li {
  margin: 8px 0 8px 0;
  font-size: 14px;
  font: system-ui, "Segoe UI", Roboto, Helvetica, Arial, sans-serif,
    "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol";
}
</style>
