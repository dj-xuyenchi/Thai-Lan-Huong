<template>
  <div
    style="
      width: 50%;
      display: inline-block;
      border: 1px solid rgba(var(--v-border-color), var(--v-border-opacity));
      float: left;
      border-radius: 10px;
      float: left;
      margin-left: 1%;
    "
  >
    <div style="margin-left: 28px; margin-top: 12px">
      <router-view class="infor" />
    </div>
  </div>
</template>

<script>
export default {
  name: "UserInfoDetail",
};
</script>

<style lang="scss" scoped></style>
