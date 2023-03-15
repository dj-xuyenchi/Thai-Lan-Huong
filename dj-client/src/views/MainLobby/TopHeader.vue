<template>
  <div class="container">
    <v-img
      :width="80"
      aspect-ratio="16/9"
      cover
      src="../../assets/logoweb.jpg"
    ></v-img>
    <div class="cf-title-07">
      <h4>DJ - CODING</h4>
    </div>
  </div>
</template>

<script>
export default {
  name: "TopHeader",
  data() {
    return {};
  },
};
</script>

<style lang="css" scoped>
.container {
  height: 8vh;
  border-bottom: 1px solid rgba(0, 0, 0, 0.05);
  position: fixed;
  top: 0;
  left: 0;
  width: 100vw;
  display: flex;
  align-items: center;
  z-index: 1;
}
/* ===CODFE HEADING STYLE #7 === */
.cf-title-07 {
  margin-left: 8%;
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
</style>
