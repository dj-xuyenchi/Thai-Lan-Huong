<template>
  <v-dialog v-model="dialog" persistent width="1024">
    <template v-slot:activator="{ props }">
      <v-btn color="primary" v-bind="props"> Thêm bài học</v-btn>
    </template>
    <v-card>
      <v-tabs v-model="tab" color="deep-purple-accent-4" align-tabs="start">
        <v-tab :value="1">Thực hành</v-tab>
        <v-tab :value="2">Lý thuyết</v-tab>
        <v-tab :value="3">Câu hỏi</v-tab>
      </v-tabs>
      <v-window v-model="tab">
        <v-window-item :value="1">
          <v-container fluid>
            <v-row>
              <AddPractice
                :setDialogOff="setDialogOff"
                :getLessonDetail="getLessonDetail"
              />
            </v-row>
          </v-container>
        </v-window-item>
        <v-window-item :value="2">
          <v-container fluid>
            <v-row>
              <AddTheory
                :setDialogOff="setDialogOff"
                :getLessonDetail="getLessonDetail"
              />
            </v-row>
          </v-container>
        </v-window-item>
        <v-window-item :value="3">
          <v-container fluid>
            <v-row>
              <AddQuestion
                :setDialogOff="setDialogOff"
                :getLessonDetail="getLessonDetail"
              />
            </v-row>
          </v-container>
        </v-window-item>
      </v-window>
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
import AddPractice from "./AddPractice";
import AddTheory from "./AddTheory";
import AddQuestion from "./AddQuestion";
export default {
  name: "AddModel",
  components: { AddPractice, AddTheory, AddQuestion },
  data: () => ({
    tab: null,
    dialog: false,
    text: "",
    snackbar: false,
  }),
  methods: {
    setDialogOff(opt) {
      switch (opt) {
        case 1:
          this.text = "Thêm thành công!";
          this.snackbar = true;
          this.dialog = false;
          break;
        case 2:
          this.text = "Thêm thất bại!";
          this.snackbar = true;
          this.dialog = false;
          break;
        case 3:
          this.dialog = false;
          break;
      }
    },
  },
  props: {
    getLessonDetail: Function,
  },
};
</script>
