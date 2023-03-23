<template>
  <div style="margin: 2% 5% 2% 5%">
    <img
      style="width: 6%; height: 40px; float: left; border-radius: 50%"
      :src="require('../../assets/user-avatar/2.jpg')"
    />
    <div
      style="
        border-radius: 15px;
        display: inline-block;
        color: black;
        background-color: #f2f3f5;
        margin: 0px 4px 4px 8px;
      "
    >
      <span
        style="
          padding: 6px 12px 8px 12px;
          font-weight: 450;
          font-size: 16px;
          display: block;
        "
        >Thái Lan Hương.</span
      >
      <span style="padding: 0px 12px 8px 12px; font-size: 16px; display: block"
        >Tuyệt vời ông mặt trời</span
      >
    </div>
    <div></div>
  </div>
</template>

<script>
export default {
  name: "CommentItem",
};
</script>

<style lang="css" scoped></style>
