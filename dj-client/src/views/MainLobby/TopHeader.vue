<template>
  <div class="container">
    <div id="logo" @click="goHome()">
      <img class="logo-header" :src="require('../../assets/logo-web.png')" />
    </div>
    <div class="cf-title-07">
      <h1 style="font-size: 24px">DJ - CodeMaster</h1>
    </div>
    <div style="display: none" id="menu-top-mobile">
      <v-menu>
        <template v-slot:activator="{ props }">
          <v-btn icon="mdi-dots-vertical" v-bind="props"></v-btn>
        </template>
        <v-list>
          <v-list-item class="item-nav" v-for="(item, i) in items" :key="i">
            <router-link
              :to="item.link"
              style="text-decoration: none; color: black"
            >
              <v-list-item-title>{{ item.title }}</v-list-item-title>
            </router-link>
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
      class="search-input-container"
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
        { title: "Home", link: "/home/lobby" },
        { title: "Khóa Học", link: "/home/courselist" },
        { title: "Bài Viết", link: "/home/post" },
        { title: "Sự Kiện", link: "/home/event-main" },
      ],
    };
  },
  methods: {
    goHome() {
      this.$router.push({ path: "/home/lobby" });
    },
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
#logo-header,
h4:hover {
  cursor: pointer;
}
#logo:hover {
  cursor: pointer;
}
.logo-header {
  height: 52px;
  z-index: 1;
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
@media screen and (max-width: 739px) {
  #menu-top-mobile {
    display: block !important;
    margin-left: 2%;
    z-index: 1;
  }
  #logo {
    display: none !important;
  }
  .cf-title-07:hover {
    cursor: pointer;
  }
  .cf-title-07 {
    display: none !important;
  }
  .search-input-container {
    justify-content: unset !important;
  }
  .user-check {
    width: 35% !important;
  }
}
@media screen and (max-width: 1023px) and (min-width: 740px) {
  #menu-top-mobile {
    display: block !important;
    margin-left: 2%;
    z-index: 1;
  }
  #logo {
    display: none !important;
  }

  .cf-title-07 {
    display: none !important;
  }
  .search-input-container {
    justify-content: unset !important;
  }
}
</style>
