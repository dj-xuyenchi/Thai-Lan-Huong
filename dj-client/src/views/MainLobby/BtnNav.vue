<template>
  <div class="btn">
    <font-awesome-icon :icon="icon" color="black" />
    <h3 style="font-size: 12px; color: black; margin-top: 4px">{{ title }}</h3>
  </div>
</template>

<script>
export default {
  name: "BtnNav",
  props: {
    title: String,
    icon: String,
  },
};
</script>

<style lang="css" scoped>
.btn {
  width: 74px;
  height: 74px;
  border-radius: 15px;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  margin-bottom: 14px;
}
.btn:hover {
  background-color: #e8ebed;
  cursor: pointer;
}
p {
  color: black;
  text-transform: capitalize;
  font-size: 12px;
  font-weight: 600;
  margin-top: 4px;
}
</style>
