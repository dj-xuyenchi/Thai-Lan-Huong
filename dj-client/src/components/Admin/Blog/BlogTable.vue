<template>
  <div>
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
          <th>Action</th>
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
          <td>{{ fixName(item.title) }}</td>
          <td>{{ item.createTime }}</td>
          <td>{{ item.updateTime }}</td>
          <td>{{ item.viewCount }}</td>
          <td>{{ item.cmtCount }}</td>
          <td>
            <BtnUpdateBlog :item="item" :getBlogPage="getBlogPage" />
          </td>
        </tr>
      </tbody>
    </v-table>
  </div>
</template>

<script>
import BtnUpdateBlog from "./BtnUpdateBlog.vue";
export default {
  name: "BlogTable",
  components: { BtnUpdateBlog },
  data() {
    return {
      itemsPerPage: 15,
      desserts: [],
    };
  },
  methods: {
    fixName(vari) {
      return vari.substring(0, 36) + "...";
    },
  },
  props: {
    tableData: [],
    getBlogPage: Function,
  },
};
</script>

<style lang="scss" scoped></style>
