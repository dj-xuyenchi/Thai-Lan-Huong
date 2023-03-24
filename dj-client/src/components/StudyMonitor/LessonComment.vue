<template>
  <div style="display: inline">
    <v-menu
      transition="slide-y-transition"
      :close-on-content-click="false"
      v-model="menu"
    >
      <template v-slot:activator="{ props }">
        <v-btn color="#4FC3F7" v-bind="props">
          <font-awesome-icon
            icon="fa-regular fa-comments"
            color="black"
            style="font-size: 20px; margin-right: 4px"
          />
          Thảo luận
        </v-btn>
      </template>
      <v-card height="70vh" width="700" style="border-radius: 15px">
        <v-list>
          <v-list-item
            prepend-avatar="https://cdn.vuetifyjs.com/images/john.jpg"
            title="4.142 bình luận"
            subtitle="Nếu phát hiện bình luận span hoặc vi phạm quy tác report giúp tớ nha."
          >
          </v-list-item>
        </v-list>
        <v-divider></v-divider>
        <div style="display: flex; justify-content: center">
          <div
            style="
              width: 90%;
              margin-top: 8px;
              display: flex;
              align-items: center;
            "
          >
            <img
              style="width: 6%; height: 40px; float: left"
              :src="require('../../assets/logo-web.png')"
            />
            <v-text-field
              style="width: 90%; float: left; margin-left: 12px"
              color="primary"
              variant="underlined"
              placeholder="Thắc mắc của bạn là gì."
            ></v-text-field>
          </div>
        </div>
        <CommentItem />
        <CommentItem />
        <CommentItem />
      </v-card>
    </v-menu>
  </div>
</template>

<script>
import CommentItem from "./CommentItem";
export default {
  name: "LessonComment",
  components: { CommentItem },
  data: () => ({
    fav: true,
    menu: false,
    message: false,
    hints: true,
  }),
};
</script>

<style lang="scss" scoped></style>
