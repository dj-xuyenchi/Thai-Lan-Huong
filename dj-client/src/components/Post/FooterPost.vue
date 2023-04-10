<template>
  <div class="footerpost-container">
    <h4 style="margin-bottom: 24px">Bình luận!</h4>
    <v-text-field
      placeholder="Ý kiến của bạn."
      variant="outlined"
      style="height: 40px; width: 100%"
    ></v-text-field>
  </div>
</template>
<script>
export default {
  name: "FooterPost",
};
</script>

<style lang="css" scoped>
.footerpost-container {
  display: inline-block;
  width: 100%;
}
</style>
