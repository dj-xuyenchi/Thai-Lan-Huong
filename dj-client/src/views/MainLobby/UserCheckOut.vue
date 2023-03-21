<template>
  <div class="user-check">
    <router-link to="/login" style="text-decoration: none; color: black">
      <v-btn width="100%" rounded="pill" color="#4FC3F7"> Đăng nhập </v-btn>
    </router-link>
  </div>
</template>

<script>
export default {
  name: "UserCheckOut",
};
</script>

<style lang="css" scoped>
div {
  position: absolute;
  right: 2vw;
}
</style>
