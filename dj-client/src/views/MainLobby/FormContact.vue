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
      <button type="submit" class="mt-2">Gửi liên hệ</button>
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
  width: 75%;
  margin-left: 12.5%;
}
.advice-footer button {
  width: 75%;
  background-color: #b3e5fc;
  border-radius: 15px;
  margin-left: 12.5%;
  height: 36px;
}
.advice-footer button:hover {
  cursor: pointer;
  background-color: #4fc3f7;
}
</style>
