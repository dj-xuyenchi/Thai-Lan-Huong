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
      <div class="text-subtitle-1 text-medium-emphasis">Quên mật khẩu</div>
      <v-text-field
        v-model="email"
        density="compact"
        placeholder="Email đăng ký tài khoản."
        prepend-inner-icon="mdi-email"
        variant="outlined"
        :rules="[rules.email]"
      ></v-text-field>
      <v-btn
        block
        class="mb-4"
        color="blue"
        size="large"
        variant="tonal"
        @click="sendRequest()"
        :disabled="dialog"
        :loading="dialog"
      >
        Yêu cầu đổi mật khẩu
      </v-btn>
    </v-card>
  </div>
</template>
<script>
import AuthApis from "../../apis/AuthApis/AuthApis.ts";
import { mapGetters } from "vuex";
import { mapMutations } from "vuex";
import { mapActions } from "vuex";
export default {
  name: "ForgetPass",
  data: () => ({
    dialog: false,
    rules: {
      email: (value) => value.includes("@") || "Email chưa đúng",
    },
  }),
  methods: {
    ...mapActions(["updateUserName"]),
    async sendRequest() {
      this.dialog = true;
      console.log(123);
      this.dialog = false;
    },
  },
};
</script>

<style lang="scss" scoped></style>
