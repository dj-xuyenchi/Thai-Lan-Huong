<template>
  <div class="user-craete-post">
    <div style="margin-bottom: 12px">
      <span
        style="
          color: #242424;
          font-size: 24px;
          font-weight: 900;
          padding-left: 14px;
          font: system-ui, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif,
            'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol';
        "
        >Viết bài
      </span>
    </div>
    <div style="width: 40%">
      <v-card class="mx-auto" width="600" prepend-icon="mdi-alert-box">
        <template v-slot:title> Chú ý </template>
        <v-card-text>
          Bài viết phải giữ đúng thuần phong mỹ tục. Không phân biệt vùng miền,
          không liên quan đến chính trị những bài viết vi phạm sẽ bị xóa tài
          khoản đăng bài tùy mức độ vi phạm có thể bị khóa vĩnh viễn.
        </v-card-text>
      </v-card>
    </div>
    <v-form
      @submit.prevent="submit()"
      ref="form"
      style="margin-top: 12px; margin-left: 5%"
    >
      <v-row>
        <v-col cols="12" sm="8" md="8">
          <v-text-field
            label="Tiêu đề bài viết*"
            hint="Tiêu đề bài viết"
            v-model="postTitle"
            variant="outlined"
            density="comfortable"
            :rules="rules"
          ></v-text-field>
        </v-col>
        <v-col cols="12" sm="8" md="8">
          <v-text-field
            label="Tiêu đề bài viết*"
            hint="Tiêu đề bài viết"
            v-model="postTitle"
            variant="outlined"
            density="comfortable"
            :rules="rules"
          ></v-text-field>
        </v-col>
        <!-- <v-col cols="12" sm="6" md="4">
                <v-text-field
                  label="Tổng thời gian học*"
                  hint="Tổng thời gian học"
                  :rules="rules"
                  v-model="chapterTime"
                ></v-text-field>
              </v-col>
              <v-col cols="12" sm="6" md="4">
                <v-select
                  v-model="select"
                  :hint="`Học phần được thêm cho khóa học ` + select.courseName"
                  :items="courseList"
                  item-title="courseName"
                  item-value="courseId"
                  label="Dành cho khóa học"
                  persistent-hint
                  return-object
                  single-line
                ></v-select>
              </v-col> -->
      </v-row>
      <small>* là trường là bắt buộc.</small>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="blue-darken-1" variant="text" @click="dialog = false">
          Hủy
        </v-btn>
        <v-btn
          color="blue-darken-1"
          :loading="btnLoading"
          variant="text"
          type="submit"
        >
          Đăng bài
        </v-btn>
      </v-card-actions>
    </v-form>
  </div>
</template>

<script>
import { mapMutations } from "vuex";
import { mapGetters } from "vuex";
export default {
  name: "UserCreatePost",
  components: {},
  data() {
    return {
      dialog: false,
      btnLoading: false,
      postTitle: "",
      rules: [
        (value) => {
          if (value) return true;
          return "Không được để trống!";
        },
      ],
    };
  },
  computed: {},
  methods: {
    ...mapMutations(["setIsLoadedData"]),
  },
};
</script>

<style lang="css" scoped>
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
@media screen and (max-width: 1360px) and (min-width: 740px) {
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
