<template>
  <div>
    <SelectionNav />
    <TopHeader />
    <div id="main-body">
      <router-view class="main-content" />
    </div>
    <HomeFooter />
  </div>
</template>

<script>
import SelectionNav from "./SelectionNav";
import TopHeader from "./TopHeader.vue";
import HomeFooter from "./HomeFooter.vue";
export default {
  components: {
    SelectionNav,
    TopHeader,
    HomeFooter,
  },
};
</script>

<style lang="css" scoped>
.main-content {
  width: 99%;
}
#main-body {
  margin-left: 116px;
  margin-top: 92px;
}
@media screen and (max-width: 739px) {
  #main-body {
    margin-left: 1% !important;
  }
}
@media screen and (max-width: 1023px) and (min-width: 740px) {
  #main-body {
    margin-left: 1% !important;
  }
}
</style>
