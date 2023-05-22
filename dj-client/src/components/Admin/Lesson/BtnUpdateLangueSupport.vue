<template>
  <div>
    <v-row>
      <v-dialog v-model="dialog" persistent width="1024">
        <template v-slot:activator="{ props }">
          <v-btn
            color="green"
            v-bind="props"
            density="compact"
            icon="mdi-pencil"
          >
          </v-btn>
        </template>
        <v-form @submit.prevent="submit()" ref="form">
          <v-card style="overflow: scroll">
            <v-card-title>
              <span class="text-h5">Cập nhật ngôn ngữ hỗ trợ</span>
            </v-card-title>
            <v-card-text>
              <v-container>
                <v-row>
                  <v-col cols="12" sm="12" md="12">
                    <v-textarea
                      counter
                      label="Code mặc định"
                      hint="Đoạn code mặc định hiển thị lên code field"
                      v-model="beginCode"
                      :rules="rules"
                    ></v-textarea>
                  </v-col>
                  <v-col cols="12">
                    <v-text-field
                      counter
                      label="Call Test Code"
                      hint="Mặc định hàm gọi nếu có tham số thì sẽ là tên hàm và (variable)"
                      v-model="callTestCode"
                      :rules="rules"
                    ></v-text-field>
                  </v-col>
                </v-row>
              </v-container>
              <small>* là trường là bắt buộc!</small>
            </v-card-text>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn
                color="blue-darken-1"
                variant="text"
                @click="dialog = false"
              >
                Hủy
              </v-btn>
              <v-btn
                color="blue-darken-1"
                :loading="btnLoading"
                variant="text"
                type="submit"
              >
                Cập nhật
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-form>
      </v-dialog>
    </v-row>
  </div>
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
import AdminAPI from "../../../apis/APIAdmin/AdminAPI.ts";
import { mapMutations } from "vuex";
export default {
  name: "BtnUpdateLangueSupport",
  data() {
    return {
      text: "",
      snackbar: false,
      isLock: false,
      beginCode: null,
      callTestCode: null,
      btnLoading: false,
      dialog: false,
      rules: [
        (value) => {
          if (value) return true;
          return "Không được để trống!";
        },
      ],
    };
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    async submit() {
      this.btnLoading = true;
      if (
        this.beginCode.trim().length < 1 ||
        this.callTestCode.trim().length < 1
      ) {
        this.btnLoading = false;
        return;
      }
      const token = localStorage.getItem("token");
      const result = await AdminAPI.updateMultiLangue(
        {
          id: this.item.id,
          beginCode: this.beginCode,
          callTestCode: this.callTestCode,
        },
        token
      );
      if (result.data == 1) {
        this.text = "Cập nhật thành công";
        this.dialog = false;
        this.snackbar = true;
        this.beginCode = "";
        this.callTestCode = "";
        this.getLangueSupport();
      }
      if (result.status == 2) {
        this.text = "Cập nhật thất bại";
        this.snackbar = true;
      }
      this.btnLoading = false;
    },
  },
  props: {
    getLangueSupport: Function,
    practiceId: Number,
    item: Object,
  },
  created() {
    this.beginCode = this.item.beginCode;
    this.callTestCode = this.item.callTestCode;
  },
};
</script>

<style lang="css" scoped></style>
