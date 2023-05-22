<template>
  <v-table>
    <thead>
      <tr>
        <th class="text-left">#</th>
        <th class="text-left">Ngôn ngữ</th>
        <th class="text-left">Code khởi đầu</th>
        <th class="text-left">Code gọi hàm</th>
        <th class="text-center">Action</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="(item, index) in listSupport" :key="index">
        <td>{{ index + 1 }}</td>
        <td>{{ item.langueCode }}</td>
        <td>{{ item.beginCode }}</td>
        <td>{{ item.callTestCode }}</td>
        <td
          style="
            display: flex;
            justify-content: space-evenly;
            align-items: center;
          "
        >
          <BtnUpdateLangueSupport
            :getLangueSupport="getLangueSupport"
            :item="item"
          />
        </td>
      </tr>
    </tbody>
  </v-table>
</template>
<script>
import BtnUpdateLangueSupport from "./BtnUpdateLangueSupport";
export default {
  components: { BtnUpdateLangueSupport },
  name: "LangueTable",
  data() {
    return {};
  },
  props: {
    listSupport: [],
    getLangueSupport: Function,
  },
};
</script>
