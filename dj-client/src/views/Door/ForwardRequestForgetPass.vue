<template>
  <div class="py-4" style="margin-top: 60px">
    <v-img
      class="mx-auto mb-10"
      max-width="300"
      :src="require('../../assets/logo-namngang.png')"
    ></v-img>
    <v-card
      class="mx-auto pa-12 pb-8"
      elevation="8"
      max-width="448"
      rounded="lg"
      style="display: flex; justify-content: center; align-items: center"
    >
      <span v-if="isFailed">Xác nhận thất bại</span>
      <span v-if="isExpired">Link hết hạn</span>
      <span v-if="isOK">Xác nhận thành công!</span>
    </v-card>
  </div>
</template>

<script>
import AuthApis from "@/apis/AuthApis/AuthApis.ts";
export default {
  name: "ForwardRequestForgetPass",
  data() {
    return {
      isFailed: false,
      isExpired: false,
      isOK: false,
    };
  },
  created() {
    this.confirm(this.$route.params.code);
  },
  methods: {
    async confirm(code) {
      const result = await AuthApis.confirmCode(code);
      if (result.data == 4) {
        this.isFailed = true;
        return;
      }
      if (result.data == 4) {
        this.isFailed = true;
        return;
      }
      if (result.data == 1) {
        localStorage.setItem("codePass", this.$route.params.code);
        this.$router.push({ path: "/changepass" });
        return;
      }
    },
  },
};
</script>

<style lang="scss" scoped></style>
