<template>
  <v-card>
    <v-layout>
      <v-navigation-drawer floating permanent>
        <v-list density="compact" nav>
          <v-list-item class="nav">
            <v-btn stacked prepend-icon="mdi-vuetify" variant="tonal">
              Button
            </v-btn>
          </v-list-item>
          <v-list-item
            prepend-icon="mdi-forum"
            title="About"
            value="about"
          ></v-list-item>
        </v-list>
      </v-navigation-drawer>
      <v-main style="height: 100vh"></v-main>
    </v-layout>
  </v-card>
</template>
<script>
export default {};
</script>
<style scoped>
.nav {
  width: 100%;
}
</style>
