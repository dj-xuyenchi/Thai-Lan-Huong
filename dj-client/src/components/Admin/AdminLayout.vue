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
import AdminAPI from "../../apis/APIAdmin/AdminAPI.ts";
import { mapMutations } from "vuex";
import { mapGetters } from "vuex";
export default {
  name: "AdminLayout",
  components: { NavsBar, HeaderAdmin },
  created() {
    this.isAdmin();
    var sp = document.querySelector(".echbay-sms-messenger");
    sp.style.display = "none";
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    async isAdmin() {
      this.setIsLoadedData(true);
      const token = localStorage.getItem("token");
      const data = await AdminAPI.isAdmin(token);
      this.setIsLoadedData(false);
    },
  },
};
</script>

<style lang="css" scoped>
#admin-body {
  margin-left: 18.75%;
  width: 80%;
  margin-top: 104px;
  min-height: 100vh;
}
</style>
