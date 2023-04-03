<template>
  <div class="course-detail-container">
    <div class="course-detail-left">
      <div class="detail-header">
        <h1 style="font-weight: 700; font-size: 30px">
          {{ courseTitle }}
        </h1>
        <h5 style="font-weight: 400">
          {{ courseSubTitle }}
        </h5>
        <div class="require-profit">
          <div class="require-profit-detail">
            <h2 style="font-weight: 700; font-size: 20px">
              Sau khóa học bạn sẽ có khả năng.
            </h2>
            <ul class="list-require-profit">
              <li v-for="(item, index) in courseProfit" :key="index">
                <font-awesome-icon
                  icon="fa-solid fa-check"
                  class="react-icon"
                  style="margin-right: 12px"
                  color="#29b6f6"
                />{{ item.courseProfitName }}
              </li>
            </ul>
          </div>
          <div class="require-profit-detail">
            <h2 style="font-weight: 700; font-size: 20px">Yêu cầu học tập.</h2>
            <ul class="list-require-profit">
              <li v-for="(item, index) in courseRequire" :key="index">
                <font-awesome-icon
                  icon="fa-solid fa-check"
                  class="react-icon"
                  style="margin-right: 12px"
                  color="#29b6f6"
                />{{ item.courseRequireName }}
              </li>
            </ul>
          </div>
        </div>
      </div>
      <div class="course-lesson">
        <h2 style="font-weight: 700; font-size: 20px">Danh sách bài học.</h2>
        <ul style="display: block; margin: 8px 0 24px 0">
          <li style="display: inline">
            <span style="font-weight: 550; margin-right: 4px">{{
              chapterCount
            }}</span
            ><span style="font-size: 14px; margin-right: 12px">Học phần.</span>
          </li>
          <li style="display: inline">
            <span style="font-weight: 550; margin-right: 4px">{{
              lessonCount
            }}</span
            ><span style="font-size: 14px; margin-right: 12px">Bài học.</span>
          </li>
          <li style="display: inline">
            <span style="font-weight: 550; margin-right: 4px">
              {{ timeTotal }} </span
            ><span style="font-size: 14px; margin-right: 12px"
              >Thời lượng.</span
            >
          </li>
        </ul>
        <LessonList
          :titleLesson="index + 1 + `. ` + item.chapterTitle"
          class="list-lesson-detail"
          v-for="(item, index) in chapterDetail"
          :key="index"
          :listLesson="item.lessonDetail"
        />
      </div>
    </div>
    <div class="course-detail-right">
      <div class="intro-content">
        <iframe
          width="100%"
          height="200"
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
import HomeApi from "../../apis/APIHome/HomeAPI.ts";
import { mapMutations } from "vuex";
import { mapGetters } from "vuex";
export default {
  name: "CourseDetail",
  components: { LessonList },
  data() {
    return {
      courseTitle: "",
      courseSubTitle: "",
      courseProfit: [],
      courseRequire: [],
      chapterDetail: [],
      chapterCount: 0,
      lessonCount: 0,
      timeTotal: "",
    };
  },
  computed: {
    ...mapGetters(["getUserLogIn"]),
  },
  mounted() {
    //const userId = this.getUserLogIn();
    //  console.log(userId);
    this.getCourseDetail(this.$route.params.id, 1);
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    async getCourseDetail(courseId, userId) {
      this.setIsLoadedData(true);
      const data = await HomeApi.getCourseDetail(courseId, userId);
      this.courseTitle = data.data.courseTitle;
      this.courseSubTitle = data.data.courseSubTitle;
      this.courseProfit = data.data.courseProfit;
      this.courseRequire = data.data.courseRequire;
      this.timeTotal = data.data.timeTotal;
      this.chapterCount = data.data.chapterCount;
      this.lessonCount = data.data.lessonCount;
      this.chapterDetail = data.data.chapterDetail;
      this.setIsLoadedData(false);
    },
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
