<template>
  <SelectionNav />
  <TopHeader />
  <div id="main-body">
    <router-view class="main-content" />
  </div>
  <HomeFooter />
</template>

<script>
import SelectionNav from "../views/MainLobby/SelectionNav";
import TopHeader from "../views/MainLobby/TopHeader.vue";
import HomeFooter from "../views/MainLobby/HomeFooter.vue";
export default {
  name: "ForwardToHome",
  components: {
    SelectionNav,
    TopHeader,
    HomeFooter,
  },
  created() {
    this.$router.push({ path: "/home/lobby" });
  },
};
</script>

<style lang="css" scoped></style>
