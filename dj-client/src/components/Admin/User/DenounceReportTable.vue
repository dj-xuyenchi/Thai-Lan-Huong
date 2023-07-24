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
          <td
            style="display: flex; align-items: center; height: 74px"
            class="user-detail"
          >
            <UserDetail
              :userId="69"
              :avatar="item.senderImg"
              :isKYC="item.senderKYC"
              :name="item.senderName"
            />
          </td>
          <td
            style="display: flex; align-items: center; height: 74px"
            class="user-detail"
          >
            <UserDetail
              :userId="69"
              :avatar="item.senderImg"
              :isKYC="item.senderKYC"
              :name="item.senderName"
            />
          </td>
          <td>
            <img
              :src="item.vioImg"
              alt="Hình ảnh"
              style="height: 30px; width: 30px; border-radius: 50%; float: left"
            />
            <span style="float: left; line-height: 30px; margin-left: 8px">{{
              item.vioName
            }}</span>
            <img
              v-if="item.vioKYC"
              :src="require('../../../assets/kyc.png')"
              alt="Hình ảnh"
              class="kyc"
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
</style>
