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
    >
      <span
        >Chúng tôi đã gửi email xác nhận đến hòm thư {{ email }} của bạn vui
        lòng click vào đường link trong email nhận được để kích hoạt tài
        khoản!</span
      >
    </v-card>
  </div>
</template>
<script>
export default {
  name: "ConfirmEmail",
  props: {
    email: String,
  },
};
</script>

<style lang="scss" scoped></style>
