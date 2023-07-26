<template>
  <div>
    <v-table>
      <thead>
        <tr>
          <th class="text-left">#</th>
          <th class="text-left" style="min-width: 300px">Người báo cáo</th>
          <th class="text-left" style="min-width: 300px">Người bị báo cáo</th>
          <th class="text-left">Nội dung Comment</th>
          <th class="text-left">Ngày gửi</th>
          <th class="text-left">Link bình luận</th>
          <th>Action</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(item, index) in tableData" :key="index">
          <td>{{ index + 1 }}</td>
          <td class="user-detail">
            <UserDetail
              :userId="item.senderId"
              :avatar="item.senderImg"
              :isKYC="item.senderKYC"
              :name="item.senderName"
            />
          </td>
          <td class="user-detail">
            <UserDetail
              :userId="item.vioId"
              :avatar="item.vioImg"
              :isKYC="item.vioKYC"
              :name="item.vioName"
            />
          </td>
          <td>{{ fixCmt(item.cmtDenounceContent) }}</td>
          <td>{{ item.sendTime }}</td>
          <td>
            <a :href="item.linkCmt" target="_blank">{{
              fixLink(item.linkCmt)
            }}</a>
          </td>
          <td>
            <ConfirmDenounce :item="item" :getDenouncePage="getDenouncePage" />
          </td>
        </tr>
      </tbody>
    </v-table>
  </div>
</template>

<script>
import ConfirmDenounce from "./ConfirmDenounce.vue";

import UserDetail from "../CommonComponent/UserDetail.vue";
export default {
  name: "UserTable",
  components: { ConfirmDenounce, UserDetail },
  data() {
    return {
      itemsPerPage: 15,
      desserts: [],
    };
  },
  methods: {
    fixLink(vari) {
      return vari.substring(0, 12) + "...";
    },
    fixCmt(vari) {
      return vari.substring(0, 12) + "...";
    },
  },

  props: {
    tableData: [],
    getDenouncePage: Function,
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
