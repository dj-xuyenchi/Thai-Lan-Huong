<template>
  <div class="mx-auto advice-footer">
    <v-form @submit.prevent style="width: 100%">
      <input require type="text" v-model="fullName" placeholder="Họ và tên" />
      <input
        type="text"
        placeholder="Số điện thoại"
        style="margin-top: 8px"
        v-model="sdt"
      />
      <button type="submit" class="mt-2" @click="sendAdvice()">
        Gửi liên hệ
      </button>
    </v-form>
    <v-snackbar v-model="snackbar">
      {{ text }}
      <template v-slot:actions>
        <v-btn color="pink" variant="text" @click="snackbar = false">
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
      fullName: "",
      sdt: "",
      snackbar: false,
      text: "",
    };
  },
  methods: {
    async sendAdvice() {
      if (this.fullName.trim().length == 0) {
        this.text = "Không được để trống tên!";
        this.snackbar = true;
        return;
      }
      const regexPhoneNumber = /(84|0[3|5|7|8|9])+([0-9]{8})\b/g;
      if (this.sdt.trim().length == 0) {
        this.text = "Không được để trống sdt!";
        this.snackbar = true;
        return;
      }
      if (!this.sdt.trim().match(regexPhoneNumber)) {
        this.text = "SDT không đúng!";
        this.snackbar = true;
        return;
      }
      const data = {
        Name: this.fullName,
        Sdt: this.sdt,
      };
      const result = await HomeAPI.sendAdvice(data);
      if (result.data == 1) {
        this.text = "Gửi yêu cầu tư vấn thành công!";
        this.snackbar = true;
        this.fullName = "";
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
