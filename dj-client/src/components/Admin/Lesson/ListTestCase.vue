<template>
  <div>
    <v-row justify="center">
      <v-btn
        color="green"
        density="compact"
        @click="dialog = true"
        icon="mdi-test-tube"
      >
      </v-btn>
      <v-dialog v-model="dialog" persistent width="auto">
        <v-card style="height: 90vh; :scroll ; width: 80vw">
          <v-card-title> {{ item.lessonName }} </v-card-title>
          <v-card-text>
            <AddTestCase
              :getTestCase="getTestCase"
              :practiceId="item.practiceId"
            />
            <TestCaseTable
              :listTestCase="listTest"
              :getTestCase="getTestCase"
              style="margin-top: 12px"
            />
          </v-card-text>
          <v-card-actions>
            <v-btn color="primary" variant="text" @click="dialog = false">
              Đóng
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>

      <v-dialog v-model="dialog2" width="auto">
        <v-card>
          <v-card-title> Dialog 2 </v-card-title>
          <v-card-text>
            <v-btn color="primary" @click="dialog3 = !dialog3">
              Open Dialog 3
            </v-btn>
          </v-card-text>
          <v-card-actions>
            <v-btn color="primary" variant="text" @click="dialog2 = false">
              Đóng
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
    </v-row>
  </div>
</template>
<script>
import AdminAPI from "../../../apis/APIAdmin/AdminAPI.ts";
import TestCaseTable from "./TestCaseTable";
import AddTestCase from "./AddTestCase";
export default {
  name: "ListTestCase",
  components: { TestCaseTable, AddTestCase },
  props: {
    item: Object,
  },
  data() {
    return {
      dialog: false,
      dialog2: false,
      dialog3: false,
      notifications: false,
      sound: true,
      widgets: false,
      listTest: [],
    };
  },
  methods: {
    async getTestCase() {
      const token = localStorage.getItem("token");
      const data = await AdminAPI.getAllTestCase(this.item.practiceId, token);
      this.listTest = data.data;
    },
  },
  created() {
    this.getTestCase();
  },
};
</script>
