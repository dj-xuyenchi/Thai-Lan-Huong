<template>
  <div>
    <v-table>
      <thead>
        <tr>
          <th class="text-left">#</th>
          <th class="text-left">Ảnh đại diện</th>
          <th class="text-left">Tiêu đề</th>
          <th class="text-left">Ngày tạo</th>
          <th class="text-left">Người viết</th>
          <th class="text-center">Action</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(item, index) in tableData" :key="index">
          <td>{{ item.stt }}</td>
          <td>
            <img
              :src="item.blogImg"
              alt="Hình ảnh"
              style="height: 60px; width: 100px"
            />
          </td>
          <td>{{ item.title }}</td>
          <td>{{ item.createTime }}</td>
          <td>{{ item.updateTime }}</td>
          <td><BtnPreviewPost /></td>
        </tr>
      </tbody>
    </v-table>
  </div>
</template>

<script>
import BtnPreviewPost from "./BtnPreviewPost";
export default {
  name: "PostTable",
  components: { BtnPreviewPost },
  data() {
    return {
      itemsPerPage: 15,
      desserts: [],
    };
  },
  props: {
    tableData: [],
  },
};
</script>

<style lang="scss" scoped></style>
