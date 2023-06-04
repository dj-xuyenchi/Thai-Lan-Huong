<template>
  <div></div>
</template>

<script>
export default {
  name: "ForwardToHome",
  created() {
    this.$router.push({ path: "/home/lobby" });
  },
};
</script>

<style lang="css" scoped></style>
