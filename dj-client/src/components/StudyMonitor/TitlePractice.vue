<template>
  <div style="margin-left: 2.5%">
    <div style="margin-top: 20px">
      <h4 style="font-size: 24px; font-family: inherit; font-weight: 700">
        Bài tập
      </h4>
      <span style="font-family: inherit; font-weight: 350"
        >Bạn hãy viết chương trình hiển thị ra màn hình tổng của
        <span class="input-exemple">313</span> và
        <span class="input-exemple">222</span>.</span
      >
      <div class="infor-lesson">
        <div class="fix-middle">
          <p>2468 + 1234 = {P1}</p>
          <p>2468 + 1234 = {P1}</p>
          <p>2468 + 1234 = {P1}</p>
          <p>2468 + 1234 = {P1}</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "TitlePractice",
};
</script>

<style lang="css" scoped>
.input-exemple {
  color: red;
}
.infor-lesson {
  width: 95%;
  border-radius: 5px;
  background-color: #2d2d2d;
  color: white;
  margin-top: 12px;
  display: flex;
  align-items: center;
  min-height: 40px;
}
.infor-lesson .fix-middle {
  padding: 12px 12px 12px 4%;
}
</style>
