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
        <h2 style="font-weight: 700; font-size: 20px">Danh sách bài học.</h2>
        <ul style="display: block; margin: 8px 0 24px 0">
          <li style="display: inline">
            <span style="font-weight: 550; margin-right: 4px">12</span
            ><span style="font-size: 14px; margin-right: 12px">Học phần.</span>
          </li>
          <li style="display: inline">
            <span style="font-weight: 550; margin-right: 4px">12</span
            ><span style="font-size: 14px; margin-right: 12px">Bài học.</span>
          </li>
          <li style="display: inline">
            <span style="font-weight: 550; margin-right: 4px"
              >15 giờ 40 phút</span
            ><span style="font-size: 14px; margin-right: 12px"
              >Thời lượng.</span
            >
          </li>
        </ul>
        <LessonList
          titleLesson="1. Java Basic (4 bài học)"
          class="list-lesson-detail"
        />
        <LessonList
          titleLesson="1. Java Basic (4 bài học)"
          class="list-lesson-detail"
        />
        <LessonList
          titleLesson="1. Java Basic (4 bài học)"
          class="list-lesson-detail"
        />
      </div>
    </div>
    <div class="course-detail-right">
      <div class="intro-content">
        <iframe
          width="100%"
          height="292"
          src="https://www.youtube.com/embed/6jZVsr7q-tE"
          title="YouTube video player"
          frameborder="0"
          allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share"
          allowfullscreen
          style="border-radius: 15px"
        ></iframe>
        <h2 style="text-align: center; margin: 12px 0 12px 0">Miễn Phí</h2>
        <v-btn width="40%" rounded="pill" color="#4FC3F7"> Đăng ký học </v-btn>
      </div>
    </div>
  </div>
</template>

<script>
import LessonList from "./LessonList.vue";
export default {
  name: "CourseDetail",
  components: { LessonList },
  props: {
    courseTitle: String,
    courseSubTitle: String,
  },
};
</script>

<style lang="css" scoped>
.course-detail-container {
  width: 95%;
  margin-left: 2.5%;
}
.course-detail-container .course-detail-left {
  display: block;
  float: left;
  width: 65%;
}
.course-detail-container .course-detail-right {
  width: 35%;
  display: flex;
  float: left;
  align-items: center;
  justify-content: center;
}
.course-detail-container .detail-header {
  margin-bottom: 28px;
}
.course-detail-container .course-detail-right .intro-content {
  width: 80%;
  text-align: center;
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
.list-lesson-detail {
  margin: 8px 0 8px 0;
}
.course-lesson {
  margin-bottom: 24px;
}
@media screen and (max-width: 739px) {
  .require-profit .require-profit-detail {
    width: 100% !important;
  }
  .course-detail-container .course-detail-right {
    display: none !important;
  }
  .course-detail-container .course-detail-left {
    width: 100% !important;
  }
}
@media screen and (max-width: 1023px) and (min-width: 740px) {
  .require-profit .require-profit-detail {
    width: 100% !important;
  }
  .course-detail-container .course-detail-left {
    width: 100% !important;
  }
  .course-detail-container .course-detail-right {
    display: none !important;
  }
}
</style>
