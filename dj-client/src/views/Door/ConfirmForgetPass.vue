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
        >Chúng tôi đã gửi link xác nhận đến email
        <span style="color: blue">{{ confirmEmail }}</span> vui lòng kiểm tra
        hòm thư và truy cập vào đường link đổi mật khẩu!</span
      >
      <a
        href="https://mail.google.com/mail/u/0/#inbox"
        style="text-decoration: none"
        target="_blank"
        ><p>Đến hòm thư!</p></a
      >
      <div style="margin-top: 24px">
        <v-row justify="center">
          <v-dialog v-model="dialog" persistent width="auto">
            <template v-slot:activator="{ props }">
              <v-btn v-bind="props" color="green-darken-1" variant="text">
                Tôi chưa nhận được email xác nhận!
              </v-btn>
            </template>
            <v-card>
              <v-card-title class="text-h5">
                Bạn chưa nhận được email xác nhận đăng ký?
              </v-card-title>
              <v-card-text
                >Có 2 lý do chính nếu bạn không nhận được email yêu cầu xác nhận
                tài khoản.</v-card-text
              >
              <v-list lines="" style="margin-left: 12px">
                <v-list-item
                  title="Sai địa chỉ email."
                  :subtitle="
                    `Hãy chắc chắn rằng email: ` +
                    confirmEmail +
                    ` là 1 email tồn tại và có thể sử dụng được.`
                  "
                ></v-list-item>
                <v-list-item
                  title="Email xác nhận nằm trong hòm thư spam."
                  subtitle="Có thể email xác nhận đang nằm trong hòm thư rác."
                ></v-list-item>
              </v-list>
              <v-card-actions>
                <v-spacer></v-spacer>

                <v-btn
                  color="green-darken-1"
                  variant="text"
                  @click="dialog = false"
                >
                  Ok tôi sẽ kiểm tra lại.
                </v-btn>
              </v-card-actions>
            </v-card>
          </v-dialog>
        </v-row>
      </div>
    </v-card>
  </div>
</template>
<script>
export default {
  name: "ConfirmForgetPass",
  data() {
    return {
      dialog: false,
    };
  },
  created() {
    this.confirmEmail = localStorage.getItem("confirm");
  },
};
</script>

<style lang="css" scoped></style>
