<template>
  <div>
    <v-row>
      <v-dialog v-model="dialog" persistent width="1024">
        <template v-slot:activator="{ props }">
          <v-btn
            color="green"
            v-bind="props"
            density="compact"
            icon="mdi-magnify"
          >
          </v-btn>
        </template>
        <v-card>
          <v-card-title>
            <span class="text-h5">Cập nhật người dùng</span>
          </v-card-title>
          <v-card-text>
            <v-container>
              <v-row>
                <v-form
                  @submit.prevent="submit()"
                  ref="form"
                  enctype="multipart/form-data"
                >
                  <v-row
                    ><v-col cols="12" sm="12" md="12">
                      <img
                        :src="data"
                        alt="Hình ảnh"
                        style="height: 100px; width: 100px; border-radius: 50%"
                      />
                      <v-label style="width: 100%; margin: 24px 0 8px 0"
                        >Ảnh đại diện người dùng</v-label
                      >
                      <v-btn
                        color="#4d96ff"
                        style="
                          height: 35px;
                          width: 104px;
                          font-size: 14px;
                          font-weight: 400;
                        "
                        @click="$refs.fileInput.click()"
                      >
                        Chọn ảnh</v-btn
                      >
                      <v-file-input
                        ref="fileInput"
                        v-model="selectFile"
                        accept="image/*"
                        @change="onFileSelect"
                        outlined
                        dense
                        hide-details
                        class="my-file-input"
                      ></v-file-input>
                    </v-col>
                    <v-col cols="4" sm="4" md="4">
                      <v-text-field
                        v-model="firstName"
                        density="compact"
                        label="Họ*"
                        hint="Họ người dùng"
                        variant="outlined"
                      ></v-text-field>
                    </v-col>
                  </v-row>
                </v-form>
              </v-row>
            </v-container>
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn color="blue-darken-1" variant="text" @click="dialog = false">
              Tuyệt cú mèo
            </v-btn>
          </v-card-actions>
        </v-card>
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
export default {
  name: "BtnShowDoneData",
  data() {
    return {
      dialog: false,
      data: {},
    };
  },
  methods: {
    async getData() {
      const token = localStorage.getItem("token");
      const result = await AdminAPI.getDoneData(
        this.userId,
        this.lessonId,
        token
      );
      this.data = result;
    },
  },
  created() {
    this.getData();
  },
  props: {
    userId: Number,
    lessonId: Number,
  },
};
</script>
