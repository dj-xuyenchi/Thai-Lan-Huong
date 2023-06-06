<template>
  <div>
    <v-table>
      <thead>
        <tr>
          <th class="text-left">#</th>
          <th class="text-left">Ảnh đại diện</th>
          <th class="text-left">Tên đầy đủ</th>
          <th class="text-left">Email</th>
          <th class="text-left">SĐT</th>
          <th class="text-left">Quyền</th>
          <th class="text-left">Ngày tạo</th>
          <th>Action</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(item, index) in tableData" :key="index">
          <td>{{ index + 1 }}</td>
          <td>
            <img
              :src="`data:image/jpeg;base64,` + item.userAvatarData40x40"
              alt="Hình ảnh"
              style="height: 60px; width: 60px; border-radius: 50%"
            />
          </td>
          <td>
            {{ item.userFisrtName + " " + item.userLastName
            }}<img
              v-if="item.isKYC"
              :src="require('../../../assets/kyc.png')"
              alt="Hình ảnh"
              class="kyc"
            />
          </td>
          <td>{{ item.userEmail }}</td>
          <td>{{ item.numberPhone }}</td>
          <td>{{ item.role.userRoleName }}</td>
          <td>{{ fixDate(item.createAccount) }}</td>
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
  name: "UserTable",
  components: { BtnUpdateBlog },
  data() {
    return {
      itemsPerPage: 15,
      desserts: [],
    };
  },
  methods: {
    fixDate(vari) {
      return (
        vari.substring(8, 10) + vari.substring(4, 8) + vari.substring(0, 4)
      );
    },
  },
  props: {
    tableData: [],
    getBlogPage: Function,
  },
};
</script>

<style lang="css" scoped>
.kyc {
  height: 20px;
  width: 20px;
  position: relative;
  top: 4px;
  left: 4px;
}
</style>
