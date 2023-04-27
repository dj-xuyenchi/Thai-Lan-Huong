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
      <div class="text-subtitle-1 text-medium-emphasis">
        Mã xác nhận được gửi tới {{ email }}
      </div>
      <v-text-field
        v-model="code"
        density="compact"
        placeholder="Mã xác nhận."
        prepend-inner-icon="mdi-text"
        variant="outlined"
        :rules="[rules.code]"
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
        Xác nhận
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
  name: "ConfirmForgetPass",
  data: () => ({
    dialog: false,
    rules: {
      code: (value) => value.length > 10 || "Mã xác nhận lớn hơn 10 ký tự!",
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
