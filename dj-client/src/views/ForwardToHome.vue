<template>
  <div></div>
</template>

<script>
export default {
  name: "ForwardToHome",
  mounted() {
    this.$router.push({ path: "/home/lobby" });
  },
};
</script>

<style lang="css" scoped></style>
