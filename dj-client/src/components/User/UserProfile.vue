<template>
  <div>
    <HeaderProfile />
    <BodyProfile :item="data" />
    <InformationProfile :item="data" />
  </div>
</template>

<script>
import UserAPI from "../../apis/APIUser/UserAPI.ts";
import HeaderProfile from "./HeaderProfile.vue";
import BodyProfile from "./BodyProfile.vue";
import InformationProfile from "./InformationProfile.vue";

import { mapMutations } from "vuex";
export default {
  components: { HeaderProfile, BodyProfile, InformationProfile },
  data() {
    return {
      data: null,
    };
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    async getProfile() {
      this.setIsLoadedData(true);
      const data = await UserAPI.getProfile(
        this.$route.params.id,
        localStorage.getItem("token")
      );
      this.data = data.data;
      this.setIsLoadedData(false);
    },
  },
  created() {
    this.getProfile();
  },
};
</script>

<style lang="css" scoped></style>
