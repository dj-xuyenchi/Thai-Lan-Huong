<template>
  <v-dialog v-model="dialog" persistent width="1024">
    <template v-slot:activator="{ props }">
      <v-btn color="green" v-bind="props" density="compact" icon="mdi-magnify">
      </v-btn>
    </template>
    <v-card>
      <v-card-title>
        <span class="text-h5">Xác nhận báo cáo vi phạm</span>
      </v-card-title>
      <v-card-text>
        <v-container>
          <v-row>
            <v-form @submit.prevent="submit()" ref="form">
              <span
                >Người dùng {{ item.vioName }} đã vi phạm
                <span style="color: red"> {{ item.vioCount }} lần</span> trước
                đó báo cáo này được thông báo người dùng bình luận vi phạm
                nguyên tắc
                <span style="color: red">{{ item.typeDenounce }}</span></span
              >
              <p>Nội dung bình luận</p>
              <span style="color: red">{{ item.cmtDenounceContent }}</span>
              <p>Ghi chú từ người báo cáo</p>
              <span style="color: red">{{ item.note }}</span>
              <v-row>
                <v-col cols="12" sm="12" md="12">
                  <v-switch
                    v-model="isVio"
                    label="Vi phạm nguyên tắc"
                    color="secondary"
                    hide-details
                  ></v-switch>
                </v-col>
                <div v-if="isVio">
                  <v-col cols="12" sm="12" md="12">
                    <v-select
                      v-model="lockOpt"
                      label="Khóa trong"
                      :items="listOpt"
                      item-title="name"
                      persistent-hint
                      return-object
                      item-value="id"
                      variant="outlined"
                    ></v-select>
                  </v-col>
                </div>
              </v-row>
            </v-form>
          </v-row>
        </v-container>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="blue-darken-1" variant="text" @click="dialog = false">
          Hủy
        </v-btn>
        <v-btn
          color="blue-darken-1"
          :loading="btnLoading"
          variant="text"
          type="submit"
          @click="submit()"
        >
          Xác nhận
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
  <v-snackbar v-model="snackbar">
    {{ text }}
    <template v-slot:actions>
      <v-btn color="green" variant="text" @click="snackbar = false">
        Đóng
      </v-btn>
    </template>
  </v-snackbar>
</template>
<script>
import AdminAPI from "../../../apis/APIAdmin/AdminAPI";
export default {
  name: "ConfirmDenounce",
  data: () => ({
    text: "",
    snackbar: false,
    lockOpt: {
      name: "3 ngày",
      id: 1,
    },
    listOpt: [
      {
        name: "3 ngày",
        id: 1,
      },
      {
        name: "5 ngày",
        id: 2,
      },
      {
        name: "7 ngày",
        id: 3,
      },
      {
        name: "Khóa vĩnh viễn",
        id: 4,
      },
    ],
    isVio: false,
    dialog: false,
    btnLoading: false,
  }),
  methods: {
    async submit() {
      this.btnLoading = true;
      const token = localStorage.getItem("token");
      const result = await AdminAPI.confirmDenounce(
        {
          DenounceId: this.item.denounceId,
          VioId: this.item.vioId,
          UserCheckId: localStorage.getItem("id"),
          LockOpt: this.lockOpt.id,
          IsVio: this.isVio,
        },
        token
      );
      if (result.data == 1) {
        this.text = "Thành công!";
        this.dialog = false;
        this.snackbar = true;
        this.isVio = false;
        this.btnLoading = false;
        this.getDenouncePage();
      }
      if (result.data == 4) {
        this.text = "Thất bại không tìm thấy!";
        this.dialog = false;
        this.snackbar = true;
        this.btnLoading = false;
      }
      this.btnLoading = false;
    },
  },
  props: {
    item: Object,
    getDenouncePage: Function,
  },
};
</script>

<style lang="css" scoped>
.my-file-input {
  display: none;
}
</style>
