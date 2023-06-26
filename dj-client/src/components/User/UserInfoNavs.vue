<template>
  <div
    style="
      width: 20%;
      display: inline-block;
      height: 400px;
      border: 1px solid rgba(var(--v-border-color), var(--v-border-opacity));
      float: left;
      border-radius: 10px;
    "
  >
    <div style="margin-left: 28px; margin-top: 20px">
      <ul>
        <router-link to="/home/user/inforcontact" style="text-decoration: none">
          <li
            :class="getActiveUserNav == 1 ? `active` : `unactive`"
            @click="
              changBread(`Thông tin & liên hệ`);
              setActiveUserNav(1);
            "
          >
            Thông tin & liên hệ
          </li>
        </router-link>
        <router-link
          to="/home/user/courseresisted"
          style="text-decoration: none"
        >
          <li
            :class="getActiveUserNav == 2 ? `active` : `unactive`"
            @click="
              changBread(`Chứng chỉ`);
              setActiveUserNav(2);
            "
          >
            Chứng chỉ
          </li>
        </router-link>
        <router-link to="/home/user/changpass" style="text-decoration: none">
          <li
            :class="getActiveUserNav == 3 ? `active` : `unactive`"
            @click="
              changBread(`Đổi mật khẩu`);
              setActiveUserNav(3);
            "
          >
            Đổi mật khẩu
          </li>
        </router-link>
      </ul>
    </div>
  </div>
</template>

<script>
import { mapGetters } from "vuex";
import { mapMutations } from "vuex";
export default {
  name: "UserInfoNavs",
  props: {
    changBread: Function,
  },
  computed: {
    ...mapGetters(["getActiveUserNav"]),
  },
  methods: {
    ...mapMutations(["setActiveUserNav"]),
  },
};
</script>

<style lang="css" scoped>
ul .unactive {
  margin-bottom: 14px;
  font-family: "Muli", sans-serif;
  font-weight: 400;
  font-size: 14px;
  line-height: 16px;
  color: #333;
}
ul .active {
  margin-bottom: 14px;
  font-family: "Muli", sans-serif;
  font-size: 14px;
  line-height: 16px;
  font-weight: bold;
  color: #4d96ff;
}
ul .unactive:hover {
  cursor: pointer;
  font-size: 15px;
  color: #4d96ff;
  font-weight: bold;
}
</style>
