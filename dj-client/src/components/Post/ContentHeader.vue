<template>
  <div class="content-container">
    <h1>
      Cách tán crush bằng HTML CSS Cách tán crush bằng HTML CSS Cách tán crush
      bằng HTML CSS.
    </h1>
    <v-list-item
      lines="one"
      prepend-avatar="https://randomuser.me/api/portraits/women/81.jpg"
      title="Jane Smith"
      style="padding: unset; position: relative; margin-bottom: 20px"
    >
      <template v-slot:append>
        <v-btn
          variant="text"
          :class="fav ? 'text-red' : ''"
          icon="mdi-heart"
          @click="fav = !fav"
        ></v-btn>
        <span>Bạn và 2.123 người khác</span>
      </template>
    </v-list-item>
  </div>
</template>

<script>
export default {
  name: "ContentHeader",
  data: () => ({
    fav: true,
    menu: false,
    message: false,
    hints: true,
  }),
};
</script>

<style lang="css" scoped>
.content-container {
}
.content-container h1 {
  font-size: 32px;
  line-height: 150%;
  font-family: serif;
  font-weight: bold;
  margin-bottom: 15px;
  font-family: Arial;
}
</style>
