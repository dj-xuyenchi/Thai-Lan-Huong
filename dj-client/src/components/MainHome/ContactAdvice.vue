<template>
  <div class="course-list-container">
    <span
      style="
        color: #242424;
        font-size: 24px;
        font-weight: 900;
        padding-left: 14px;
        font: system-ui, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif,
          'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol';
      "
      >Liên hệ tư vấn
    </span>
    <div style="display: flex; justify-content: center">
      <div class="course-list">
        <div style="width: 50%; float: left" class="img-left">
          <img
            src="https://res.cloudinary.com/dushydq6r/image/upload/v1688031377/how-to-contact-binance-support_boxn5s.jpg"
            alt="Hình ảnh"
            style="height: 400px; width: 100%"
          />
        </div>
        <div
          style="width: 50%; float: left"
          id="input-group"
          class="content-right"
        >
          <v-text-field
            v-model="fullName"
            label="Họ và tên"
            variant="solo"
            density="compact"
          ></v-text-field>
          <v-text-field
            v-model="sdt"
            density="compact"
            label="Số điện thoại"
            variant="solo"
          ></v-text-field>

          <v-select
            variant="solo"
            style="margin-top: 8px"
            v-model="opt"
            :items="listOpt"
            persistent-hint
            return-object
            density="compact"
            item-value="id"
            item-title="name"
          >
          </v-select>
          <v-textarea
            v-model="note"
            label="Ghi chú"
            variant="solo"
            rows="3"
          ></v-textarea>
          <v-btn
            color="blue"
            type="submit"
            class="mt-2"
            @click="sendAdvice()"
            style="width: 100%"
          >
            Gửi liên hệ
          </v-btn>
        </div>
      </div>
    </div>
  </div>
  <v-snackbar v-model="snackbar">
    {{ text }}
    <template v-slot:actions>
      <v-btn
        :color="color == 1 ? `#43A047` : `pink`"
        variant="text"
        @click="snackbar = false"
      >
        Close
      </v-btn>
    </template>
  </v-snackbar>
</template>

<script>
import HomeAPI from "../../apis/APIHome/HomeAPI";
export default {
  name: "PostList",
  data() {
    return {
      color: 0,
      fullName: "",
      listOpt: [
        { id: 0, name: "Tư vấn" },
        { id: 1, name: "Học 1:1" },
        { id: 2, name: "Định hướng nghành" },
        { id: 3, name: "Cơ hội việc làm" },
        { id: 4, name: "Phỏng vấn & CV" },
        { id: 5, name: "Khác" },
      ],
      sdt: "",
      opt: { id: 0, name: "Tư vấn" },
      note: "",
      text: "",
      snackbar: false,
    };
  },
  props: {
    postList: [],
  },
  methods: {
    async sendAdvice() {
      if (this.fullName.trim().length == 0) {
        this.text = "Cho chúng mình biết tên của bạn nhé!";
        this.color == 0;
        this.snackbar = true;
        return;
      }
      const regexPhoneNumber = /(84|0[3|5|7|8|9])+([0-9]{8})\b/g;
      if (this.sdt.trim().length == 0) {
        this.text = "Bạn không được để trống sdt!";
        this.color == 0;
        this.snackbar = true;
        return;
      }
      if (!this.sdt.trim().match(regexPhoneNumber)) {
        this.text = "SDT của bạn không đúng!";
        this.color == 0;
        this.snackbar = true;
        return;
      }
      if (this.opt.id == 0) {
        this.text = "Bạn cần tư vấn về?";
        this.color == 0;
        this.snackbar = true;
        return;
      }
      if (this.note.trim().length == 0) {
        this.text = "Bạn có ghi chú gì cho chúng mình không!";
        this.color == 0;
        this.snackbar = true;
        return;
      }
      const data = {
        Name: this.fullName,
        Sdt: this.sdt,
        Note: this.note,
        Opt: this.opt.id,
      };
      const result = await HomeAPI.sendAdvice(data);
      if (result.data == 1) {
        this.text =
          "Gửi yêu cầu tư vấn thành công bọn mình sẽ liên hệ bạn sớm!";
        this.color = 1;
        this.snackbar = true;
        this.fullName = "";
        this.note = "";
        this.sdt = "";
        this.opt = { id: 0, name: "Tư vấn" };
        return;
      }
    },
  },
};
</script>

<style lang="css" scoped>
.course-list-container {
  margin-left: 3%;
  width: 92%;
  margin-bottom: 40px;
}
.course-list-container .course-list {
  width: 1200px;
  height: 400px;
}
.showAll {
  color: red;
  font-size: 14px;
  font-weight: 900;
  padding-left: 14px;
  float: right;
  font: system-ui, "Segoe UI", Roboto, Helvetica, Arial, sans-serif,
    "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol";
}
.showAll:hover {
  cursor: pointer;
  text-decoration: underline;
  color: #eb5353;
}

@media screen and (max-width: 739px) {
  .img-left {
    display: none;
  }
  .content-right {
    margin-top: 24px;
    width: 100%;
  }
}
@media screen and (max-width: 1023px) and (min-width: 740px) {
  .img-left {
    display: none;
  }
  .content-right {
    margin-top: 24px;
    width: 100%;
  }
}
</style>
