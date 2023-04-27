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
        placeholder="Email đăng ký"
        prepend-inner-icon="mdi-email-outline"
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
    <v-snackbar v-model="snackbar" multi-line>
      {{ text }}

      <template v-slot:actions>
        <v-btn color="red" variant="text" @click="snackbar = false">
          Close
        </v-btn>
      </template>
    </v-snackbar>
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
    email: "",
    snackbar: false,
    text: `Email không tồn tại!`,
    rules: {
      email: (value) => value.includes("@") || "Email chưa đúng",
    },
  }),
  methods: {
    ...mapActions(["updateUserName"]),
    async sendRequest() {
      this.dialog = true;
      const request = {
        Email: this.email,
      };
      const result = await AuthApis.forgetPass(request);
      if (result.data == 4) {
        this.snackbar = true;
        this.dialog = false;
        return;
      }
      if (result.data == 1) {
        localStorage.setItem("forgetEmail", this.email);
        // this.$router.push({ path: "/forwardrequestforgetpass/1312" });
        this.$router.push({ path: "/confirmforgetpass" });
      }
      this.dialog = false;
    },
  },
};
</script>

<style lang="scss" scoped></style>
