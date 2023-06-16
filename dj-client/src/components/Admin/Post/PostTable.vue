<template>
  <div>
    <v-table>
      <thead>
        <tr>
          <th class="text-left">#</th>
          <th class="text-left">Ảnh đại diện</th>
          <th class="text-left">Tiêu đề</th>
          <th class="text-left" style="min-width: 320px">Người viết</th>
          <th class="text-left" style="min-width: 140px">Ngày tạo</th>
          <th class="text-left" style="min-width: 150px">Trạng thái</th>
          <th class="text-left">Action</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(item, index) in tableData" :key="index">
          <td>{{ index + 1 }}</td>
          <td>
            <img
              :src="item.postAvatar"
              alt="Hình ảnh"
              style="height: 60px; width: 100px; margin-top: 6px"
            />
          </td>
          <td>{{ fixString(item.postTitle) }}</td>
          <td>
            <img
              :src="item.userCreate.userAvatarData40x40"
              alt="Hình ảnh"
              style="height: 40px; width: 40px; border-radius: 50%; float: left"
            />
            <span style="float: left; line-height: 40px; margin-left: 8px">
              {{
                item.userCreate.userFisrtName +
                " " +
                item.userCreate.userLastName
              }}
            </span>
            <img
              v-if="item.userCreate.isKYC"
              :src="require('../../../assets/kyc.png')"
              alt="Hình ảnh"
              class="kyc"
            />
          </td>
          <td>{{ fixDate(item.createPost) }}</td>
          <td>{{ item.postStatus.postStatusName }}</td>

          <td>
            <BtnPreviewPost
              :option="option"
              :item="item"
              :getPostAdmin="getPostAdmin"
            />
          </td>
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
    option: [],
    getPostAdmin: Function,
  },
  methods: {
    fixDate(vari) {
      if (!vari) {
        return "Chưa có";
      }
      return (
        vari.substring(8, 10) + vari.substring(4, 8) + vari.substring(0, 4)
      );
    },
    fixString(vari) {
      if (!vari) {
        return "Chưa có";
      }
      return vari.substring(0, 40) + "...";
    },
  },
};
</script>

<style lang="css" scoped>
.kyc {
  height: 20px;
  width: 20px;
  position: relative;
  top: 9px;
  left: 4px;
}
</style>
