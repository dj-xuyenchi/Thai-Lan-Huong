<template>
  <div class="select-container">
    <router-link to="/home" style="text-decoration: none">
      <BtnNav
        icon="mdi:mdi-minusmdiBookOpenVariant"
        title="Home"
        :class="active ? `active` : ``"
      />
    </router-link>
    <router-link to="/course" style="text-decoration: none">
      <BtnNav :path="mdiBookOpenVariant" title="Khóa Học" />
    </router-link>
    <router-link to="/post" style="text-decoration: none">
      <BtnNav :path="mdiBookOpenVariant" title="Bài viết" />
    </router-link>
    <router-link to="/blog" style="text-decoration: none">
      <BtnNav :path="mdiBookOpenVariant" title="Blog" />
    </router-link>
    <router-link to="/event" style="text-decoration: none">
      <BtnNav :path="mdiBookOpenVariant" title="Sự kiện" />
    </router-link>
  </div>
</template>
<script>
import BtnNav from "./BtnNav";
import { mdiBookOpenVariant } from "@mdi/js";
export default {
  components: {
    BtnNav,
  },
  data() {
    return {
      active: true,
    };
  },
};
</script>
<style scoped>
.select-container {
  /* border-right: 1px solid rgba(0, 0, 0, 0.05); */
  width: 6%;
  position: fixed;
  height: 92%;
  display: flex;
  top: 9%;
  align-items: center;
  flex-direction: column;
}
.active {
  background-color: rgba(0, 0, 0, 0.05);
}
.router {
  width: 74px;
  height: 74px;
}
</style>
