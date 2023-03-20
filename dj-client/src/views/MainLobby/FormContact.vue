<template>
  <v-sheet width="300" class="mx-auto">
    <v-form fast-fail @submit.prevent>
      <v-text-field
        v-model="fullname"
        label="First name"
        :rules="fullnameRules"
      ></v-text-field>

      <v-text-field
        v-model="phone"
        label="Last name"
        :rules="phoneRules"
      ></v-text-field>

      <v-btn type="submit" block class="mt-2">Submit</v-btn>
    </v-form>
  </v-sheet>
</template>
<script>
export default {
  name: "FormContact",
  data: () => ({
    fullname: "",
    fullnameRules: [
      (value) => {
        if (value?.length > 3) return true;

        return "Tên phải trên 3 ký tự.";
      },
    ],
    phone: "",
    phoneRules: [
      (value) => {
        if (/[^a-zA-Z]/.test(value)) return true;
        return "Số điện thoại không đúng.";
      },
    ],
  }),
};
</script>
