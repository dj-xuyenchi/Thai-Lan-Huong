<template>
  <div class="body-profile">
    <img :src="require('../../assets/iloveyou.jpeg')" alt="" />
  </div>
</template>

<script>
export default {};
</script>

<style lang="css" scoped>
.body-profile {
  position: absolute;
  width: 70%;
  left: 15%;
  top: 0;
}
.body-profile img {
  width: 100%;
  height: 400px;
}
</style>
