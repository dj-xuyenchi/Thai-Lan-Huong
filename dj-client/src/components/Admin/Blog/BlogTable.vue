<template>
  <div>
    <!-- <v-data-table
      v-model:items-per-page="itemsPerPage"
      :headers="headers"
      :items="desserts"
      item-value="name"
      class="elevation-1"
    >
      <template v-slot:item.actions="{ item }">
        <v-icon size="small" class="me-2" @click="editItem(item.raw)">
          mdi-pencil
        </v-icon>
        <v-icon size="small" @click="deleteItem(item.raw)"> mdi-delete </v-icon>
      </template>
      <template v-slot:no-data>
        <v-btn color="primary" @click="initialize"> Reset </v-btn>
      </template>
    </v-data-table> -->
    <v-table>
      <thead>
        <tr>
          <th class="text-left">#</th>
          <th class="text-left">Tiêu đề Vlog</th>
          <th class="text-left">Ngày tạo</th>
          <th class="text-left">Cập nhật</th>
          <th class="text-left">View</th>
          <th class="text-left">Comment</th>
          <th class="text-center">Action</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(item, index) in data" :key="index">
          <td>{{ item.stt }}</td>
          <td>{{ item.lessonName }}</td>
          <td>{{ item.createDateTime }}</td>
          <td>{{ item.updateDateTime }}</td>
          <td>{{ item.lessonType }}</td>
          <td>{{ item.videoTime }}</td>
          <td></td>
        </tr>
      </tbody>
    </v-table>
  </div>
</template>

<script>
export default {
  name: "LessonTable",
  data() {
    return {
      itemsPerPage: 15,
      headers: [
        { title: "#", align: "start", key: "stt", sortable: false },
        { title: "Tiêu đề Vlog", align: "start", key: "title" },
        { title: "Ngày tạo", align: "start", key: "create" },
        { title: "Cập nhật", align: "start", key: "update" },
        { title: "Comment", align: "start", key: "comment" },
        { title: "View", align: "start", key: "view" },
        { title: "Action", align: "start", key: "actions" },
      ],
      desserts: [],
    };
  },
  props: {
    data: [],
    getLessonDetail: Function,
  },
};
</script>

<style lang="scss" scoped></style>
