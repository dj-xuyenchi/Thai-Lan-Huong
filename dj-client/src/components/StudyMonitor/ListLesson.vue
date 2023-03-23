<template>
  <div>
    <v-menu transition="slide-y-transition">
      <template v-slot:activator="{ props }">
        <v-btn color="primary" v-bind="props"> Slide Y Transition </v-btn>
      </template>
      <v-list>
        <v-list-item v-for="(item, i) in items" :key="i">
          <v-list-item-title>{{ item.title }}</v-list-item-title>
        </v-list-item>
      </v-list>
    </v-menu>
  </div>
</template>

<script>
export default {
  data: () => ({
    items: [
      { title: "Click Me" },
      { title: "Click Me" },
      { title: "Click Me" },
      { title: "Click Me 2" },
    ],
  }),
};
</script>

<style lang="scss" scoped></style>
