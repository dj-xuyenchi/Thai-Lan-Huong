<template>
  <div style="min-height: 80vh">
    <h4
      style="
        color: #4d96ff;
        font-size: 24px;
        font-weight: bold;
        margin-bottom: 14px;
        letter-spacing: 1px;
      "
    >
      Chứng chỉ của tôi
    </h4>
    <div class="form-changepass">Danh sách chứng chỉ</div>
    <div v-for="(item, index) in list" :key="index">
      <div @click="goCertificate(`${item.id}`)" class="certi">
        <img
          :src="item.courseImageData"
          alt="hình ảnh"
          style="height: 320px; width: 600px; border-radius: 15px"
        />
        <p>{{ item.courseName }}</p>
      </div>
    </div>
    <v-snackbar v-model="snackbarOk" multi-line>
      {{ snackBarContent }}
      <template v-slot:actions>
        <v-btn color="green" variant="text" @click="snackbarOk = false">
          Đóng
        </v-btn>
      </template>
    </v-snackbar>
  </div>
</template>

<script>
import UserAPI from "../../apis/APIUser/UserAPI.ts";
import { mapMutations } from "vuex";
export default {
  name: "CourseResisted",
  components: {},
  data() {
    return {
      list: [],
      dialog: false,
      snackbarOk: false,
      snackBarContent: "",
    };
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    async getMyCertificate() {
      this.setIsLoadedData(true);
      const token = localStorage.getItem("token");
      const userId = localStorage.getItem("id");
      const data = await UserAPI.getMyCertificate(userId, token);
      this.list = data.data.listCerti;
      this.setIsLoadedData(false);
    },
    goCertificate(courseId) {
      this.$router.push({
        path: `/home/certificate/${courseId}/${localStorage.getItem("id")}`,
      });
    },
  },
  created() {
    this.getMyCertificate();
  },
};
</script>

<style lang="css" scoped>
.form-changepass {
  width: 40%;
  margin: 0 0 12px 0;
}
.certi:hover {
  cursor: pointer;
}
</style>
