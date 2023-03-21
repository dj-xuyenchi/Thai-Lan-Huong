<template>
  <div class="select-container">
    <router-link to="lobby" style="text-decoration: none">
      <BtnNav
        icon="fa-solid fa-house"
        title="Home"
        :class="active ? `active` : ``"
      />
    </router-link>
    <router-link to="course" style="text-decoration: none">
      <BtnNav icon="fa-solid fa-book" title="Khóa Học" />
    </router-link>
    <router-link to="post" style="text-decoration: none">
      <BtnNav icon="fa-regular fa-calendar-plus" title="Bài viết" />
    </router-link>
    <router-link to="blog" style="text-decoration: none">
      <BtnNav icon="fa-brands fa-blogger-b" title="Blog" />
    </router-link>
    <router-link to="event" style="text-decoration: none">
      <BtnNav icon="fa-regular fa-calendar-days" title="Sự kiện" />
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
  width: 116px;
  position: fixed;
  height: 92%;
  display: flex;
  top: 92px;
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
@media screen and (max-width: 739px) {
  .select-container {
    display: none !important;
  }
}
</style>
