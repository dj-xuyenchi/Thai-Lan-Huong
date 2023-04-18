<template>
  <v-card style="border-radius: unset; height: 100vh">
    <v-layout style="height: 100vh">
      <v-navigation-drawer
        class="bg-deep-purple"
        theme="dark"
        permanent
        image="https://congngheviet.com/wp-content/uploads/2017/12/No17-Levels@3x-768x1366-576x1024.jpg"
      >
        <v-list color="transparent">
          <v-list-item
            prepend-icon="mdi-view-dashboard"
            title="Dashboard"
          ></v-list-item>
          <v-list-item
            prepend-icon="mdi-account-box"
            title="Account"
          ></v-list-item>
          <v-list-item prepend-icon="mdi-gavel" title="Admin"></v-list-item>
        </v-list>
      </v-navigation-drawer>
      <v-main style="height: 400px"></v-main>
    </v-layout>
  </v-card>
</template>
<script>
export default {
  name: "NavsBar",
};
</script>

<style lang="scss" scoped></style>
