<template>
  <div>
    <v-table>
      <thead>
        <tr>
          <th class="text-left">#</th>
          <th class="text-left">Tài khoản</th>
          <th class="text-left">Email</th>
          <th class="text-left">Quyền</th>
          <th class="text-left">Số lần vi phạm</th>
          <th class="text-left">Khóa đến</th>
          <!-- <th>Action</th> -->
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
          <td>{{ item.role.userRoleName }}</td>
          <td>{{ item.vioCount ? item.vioCount : 0 }}</td>
          <td>
            {{
              item.userStatus.id == 4
                ? "Khóa vĩnh viễn"
                : fixDate(item.unlockTime)
            }}
          </td>
          <!-- <td>
            <BtnUpdateUser
              :item="item"
              :listGender="listGender"
              :listTinh="listTinh"
              :listCatalog="listCatalog"
              :getUserPage="getUserPage"
              :listRole="listRole"
              :listStatus="listStatus"
            />
          </td> -->
        </tr>
      </tbody>
    </v-table>
  </div>
</template>

<script>
import BtnUpdateUser from "./BtnUpdateUser.vue";
import UserDetail from "../CommonComponent/UserDetail.vue";
import UserAPI from "../../../apis/APIUser/UserAPI";
export default {
  name: "UserLockTable",
  components: { UserDetail },
  data() {
    return {
      itemsPerPage: 15,
      desserts: [],
      listGender: [],
      listTinh: [],
      listRole: [],
      listStatus: [],
      listCatalog: [],
    };
  },
  methods: {
    fixDate(vari) {
      if (!vari) {
        return "Không nhận dạng";
      }
      return (
        vari.substring(8, 10) + vari.substring(4, 8) + vari.substring(0, 4)
      );
    },
    async getOption() {
      const token = localStorage.getItem("token");
      const data = await UserAPI.getOptionUpdate(token);
      this.listGender = data.data.genders;
      this.listTinh = data.data.provinces;
      this.listCatalog = data.data.catalogs;
      this.listRole = data.data.roles;
      this.listStatus = data.data.statuses;
    },
  },
  created() {
    this.getOption();
  },
  props: {
    tableData: [],
    getUserPage: Function,
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
.user-detail:hover {
  cursor: pointer;
}
</style>
