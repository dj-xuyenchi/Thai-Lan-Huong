<template>
  <div class="select-container">
    <router-link to="/home/lobby" style="text-decoration: none">
      <BtnNav
        icon="fa-solid fa-house"
        title="Home"
        :class="getActiveMenu == 1 ? `active` : ``"
        @click="setActiveMenu(1)"
      />
    </router-link>
    <router-link to="/home/courselist" style="text-decoration: none">
      <BtnNav
        icon="fa-solid fa-book"
        title="Khóa Học"
        :class="getActiveMenu == 2 ? `active` : ``"
        @click="setActiveMenu(2)"
      />
    </router-link>
    <router-link to="/home/post" style="text-decoration: none">
      <BtnNav
        icon="fa-regular fa-calendar-plus"
        title="Bài viết"
        :class="getActiveMenu == 3 ? `active` : ``"
        @click="setActiveMenu(3)"
      />
    </router-link>
    <router-link to="/home" style="text-decoration: none">
      <BtnNav
        icon="fa-brands fa-blogger-b"
        title="Blog"
        :class="getActiveMenu == 4 ? `active` : ``"
        @click="setActiveMenu(4)"
      />
    </router-link>
    <router-link to="/home" style="text-decoration: none">
      <BtnNav
        icon="fa-regular fa-calendar-days"
        title="Sự kiện"
        :class="getActiveMenu == 5 ? `active` : ``"
        @click="setActiveMenu(5)"
      />
    </router-link>
  </div>
</template>
<script>
import BtnNav from "./BtnNav";
import { mdiBookOpenVariant } from "@mdi/js";
import { mapGetters } from "vuex";
import { mapMutations } from "vuex";
export default {
  components: {
    BtnNav,
  },
  computed: {
    ...mapGetters(["getActiveMenu"]),
  },
  methods: {
    ...mapMutations(["setActiveMenu"]),
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
@media screen and (max-width: 1023px) and (min-width: 740px) {
  .select-container {
    display: none !important;
  }
}
</style>
