<template>
  <div class="mx-auto advice-footer">
    <v-form @submit.prevent style="width: 100%">
      <input require type="text" v-model="fullName" placeholder="Họ và tên" />
      <input
        require
        type="text"
        placeholder="Số điện thoại"
        style="margin-top: 8px"
        v-model="sdt"
      />
      <select style="margin-top: 8px" v-model="opt">
        <option value="0">Tư vấn</option>
        <option value="1">Học 1:1</option>
        <option value="2">Định hướng nghành</option>
        <option value="3">Cơ hội việc làm</option>
        <option value="4">Phỏng vấn & CV</option>
        <option value="5">Khác</option>
      </select>
      <textarea
        require
        type="text"
        placeholder="ghi chú"
        style="margin-top: 8px"
        v-model="note"
        rows="4"
      />
      <button type="submit" class="mt-2" @click="sendAdvice()">
        Gửi liên hệ
      </button>
    </v-form>
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
  </div>
</template>
<script>
import HomeAPI from "../../apis/APIHome/HomeAPI";
export default {
  name: "FormContact",
  data: () => {
    return {
      color: 0,
      fullName: "",
      sdt: "",
      opt: 0,
      note: "",
      text: "",
      snackbar: false,
    };
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
      if (this.opt == 0) {
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
        Opt: this.opt,
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
        return;
      }
    },
  },
};
</script>
<style>
.advice-footer {
  width: 100%;
  display: flex;
  justify-content: center;
}
.advice-footer input {
  border-radius: 15px;
  background-color: #b3e5fc;
  height: 36px;
  padding-left: 10px;
  width: 75%;
  margin-left: 12.5%;
}
.advice-footer textarea {
  border-radius: 15px;
  background-color: #b3e5fc;
  padding-left: 10px;
  width: 75%;
  margin-left: 12.5%;
}

.advice-footer select {
  border-radius: 15px;
  background-color: #b3e5fc;
  padding-left: 10px;
  height: 36px;
  width: 75%;
  margin-left: 12.5%;
}
.advice-footer button {
  width: 75%;
  background-color: #b3e5fc;
  border-radius: 15px;
  margin-left: 12.5%;
  height: 36px;
}
.advice-footer button:hover {
  cursor: pointer;
  background-color: #4fc3f7;
}
</style>
