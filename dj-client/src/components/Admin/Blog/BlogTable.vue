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
          <th class="text-left">Ảnh đại diện</th>
          <th class="text-left">Tiêu đề Vlog</th>
          <th class="text-left">Ngày tạo</th>
          <th class="text-left">Cập nhật</th>
          <th class="text-left">View</th>
          <th class="text-left">Comment</th>
          <th class="text-center">Action</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(item, index) in tableData" :key="index">
          <td>{{ item.stt }}</td>
          <td>
            <img
              :src="`data:image/jpeg;base64,` + item.blogImg"
              alt=""
              style="height: 60px; width: 100px"
            />
          </td>
          <td>{{ item.title }}</td>
          <td>{{ item.createTime }}</td>
          <td>{{ item.updateTime }}</td>
          <td>{{ item.viewCount }}</td>
          <td>{{ item.cmtCount }}</td>
          <td>{{ item.videoTime }}</td>
          <td></td>
        </tr>
      </tbody>
    </v-table>
  </div>
</template>

<script>
export default {
  name: "BlogTable",
  data() {
    return {
      itemsPerPage: 15,
      desserts: [],
    };
  },
  props: {
    tableData: [],
    getLessonDetail: Function,
  },
};
</script>

<style lang="scss" scoped></style>
