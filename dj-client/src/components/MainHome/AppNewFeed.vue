<template>
  <div>
    <button type="" @click="getData()">click</button>
    <HeaderSlider />
    <CourseList />
    <PostList />
    <BlogList />
  </div>
</template>

<script>
import HeaderSlider from "./HeaderSlider.vue";
import CourseList from "./CourseList.vue";
import PostList from "./PostList.vue";
import BlogList from "./BlogList.vue";
import HomeAPI from "../../apis/APIHome/HomeAPI";
export default {
  name: "AppNewFeed",
  components: { HeaderSlider, CourseList, PostList, BlogList },
  data: () => {
    return {
      data1: "123",
    };
  },
  methods: {
    getData() {
      HomeAPI.getString().then((res) => {
        this.data1 = res;
        console.log(this.data1);
      });
    },
  },
};
</script>

<style lang="css" scoped></style>
