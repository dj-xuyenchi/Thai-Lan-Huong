<template>
  <div>
    <v-table>
      <thead>
        <tr>
          <th class="text-left">#</th>
          <th class="text-left">Tài khoản</th>
          <th class="text-left">Email</th>
          <th class="text-left">SĐT</th>
          <th class="text-left">Quyền</th>
          <th class="text-left">Lý do</th>
          <th>Action</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(item, index) in tableData" :key="index">
          <td>{{ index + 1 }}</td>
          <td
            style="display: flex; align-items: center; height: 74px"
            class="user-detail"
          >
            <UserDetail
              :userId="item.id"
              :avatar="item.userAvatarData40x40"
              :isKYC="item.isKYC"
              :name="item.userFisrtName + ` ` + item.userLastName"
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
