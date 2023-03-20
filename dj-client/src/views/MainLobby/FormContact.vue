<template>
  <div class="mx-auto advice-footer">
    <form style="width: 100%">
      <input require type="text" name="" value="" placeholder="Họ và tên" />
      <input
        type="text"
        name=""
        require
        value=""
        placeholder="Số điện thoại"
        style="margin-top: 8px"
      />
      <v-btn width="100" type="submit" block class="mt-2">Gửi liên hệ</v-btn>
    </form>
  </div>
</template>
<script>
export default {
  name: "FormContact",
  data: () => {
    return {
      fullName: "",
    };
  },
};
</script>
<style>
.advice-footer {
  width: 100%;
  display: flex;
  justify-content: center;
}
.advice-footer input {
  border-radius: 15px;
  background-color: #b3e5fc;
  height: 36px;
  padding-left: 10px;
  width: 50%;
  margin-left: 25%;
}
</style>
