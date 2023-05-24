<template>
  <div
    style="margin-left: 20px; float: left; height: 280px; margin-bottom: 12px"
  >
    <img
      :src="'data:image/jpeg;base64, ' + item.courseAvatar"
      alt=""
      style="width: 400px; height: 240px; border-radius: 10px"
    />
    <h4>{{ item.courseName }}</h4>
  </div>
</template>

<script>
export default {
  props: {
    item: Object,
  },
};
</script>

<style lang="scss" scoped></style>
