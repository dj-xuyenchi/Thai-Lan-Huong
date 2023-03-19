<template>
  <div class="container">
    <div id="logo">
      <img class="logo-header" :src="require('../../assets/logo-web.png')" />
    </div>
    <div class="cf-title-07">
      <h4>DJ - CODING</h4>
    </div>
    <div style="display: none" id="menu-top-mobile">
      <v-menu>
        <template v-slot:activator="{ props }">
          <v-btn icon="mdi-dots-vertical" v-bind="props"></v-btn>
        </template>

        <v-list>
          <v-list-item class="item-nav" v-for="(item, i) in items" :key="i">
            <v-list-item-title>{{ item.title }}</v-list-item-title>
          </v-list-item>
        </v-list>
      </v-menu>
    </div>
    <div
      style="
        display: flex;
        justify-content: center;
        width: 100%;
        position: absolute;
      "
    >
      <SearchInput />
    </div>
    <UserCheckOut />
  </div>
</template>

<script>
import SearchInput from "./SearchInput.vue";
import UserCheckOut from "./UserCheckOut.vue";
export default {
  name: "TopHeader",
  components: {
    SearchInput,
    UserCheckOut,
  },
  data() {
    return {
      items: [
        { title: "Home" },
        { title: "Khóa Học" },
        { title: "Bài Viết" },
        { title: "Block" },
        { title: "Sự Kiện" },
      ],
    };
  },
};
</script>

<style lang="css" scoped>
.container {
  height: 76px;
  border-bottom: 1px solid rgba(0, 0, 0, 0.05);
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  align-items: center;
  display: flex;
  z-index: 2;
  background-color: #fff;
}
#logo {
  width: 116px;
  display: flex;
  justify-content: center;
  align-items: center;
}
.logo-header {
  height: 52px;
  width: 52px;
}
.cf-title-07 {
}
.cf-title-07 h5 {
  text-align: center;
  font-size: 30px;
  font-weight: 300;
  color: #222;
  letter-spacing: 1px;
  text-transform: uppercase;

  display: grid;
  grid-template-columns: 1fr max-content 1fr;
  grid-template-rows: 27px 0;
  grid-gap: 20px;
  align-items: center;
}
.cf-title-07 h5:after,
.cf-title-07 h5:before {
  content: " ";
  display: block;
  border-bottom: 1px solid #c50000;
  border-top: 1px solid #c50000;
  height: 5px;
  background-color: #f8f8f8;
}
.item-nav:hover {
  cursor: pointer;
  background-color: #e8ebed;
}
</style>
