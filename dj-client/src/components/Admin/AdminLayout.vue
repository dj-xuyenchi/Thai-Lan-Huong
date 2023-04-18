<template>
  <NavsBar />
  <HeaderAdmin />
  <div id="admin-body">
    <router-view />
  </div>
</template>

<script>
import NavsBar from "./NavsBar.vue";
import HeaderAdmin from "./HeaderAdmin.vue";
export default {
  name: "AdminLayout",
  components: { NavsBar, HeaderAdmin },
};
</script>

<style lang="css" scoped>
#admin-body {
  margin-left: 17.5%;
  width: 80%;
  margin-top: 40px;
  min-height: 100vh;
}
</style>
