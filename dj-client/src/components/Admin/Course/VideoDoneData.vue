<template>
  <div>
    <v-row>
      <v-card>
        <v-card-text>
          <v-container>
            <v-row>
              <v-col cols="12" sm="12" md="12">
                <span
                  >Tên bài học:
                  <span style="color: green; font-weight: 600">{{
                    item.lessonName
                  }}</span></span
                >
                <br />
                <span
                  >Mô tả:
                  <span style="color: green; font-weight: 600">{{
                    item.lessonDescription
                  }}</span></span
                >
                <br />
                <span
                  >Thời lượng:
                  <span style="color: green; font-weight: 600">{{
                    item.videoTime
                  }}</span></span
                >
                <br />
                <span
                  >Link bài học:
                  <a :href="url" target="_blank">{{ url }}</a></span
                >
                <br />
                <span
                  >Ngày hoàn thành:
                  <span style="color: green; font-weight: 600">{{
                    doneTime ? fixDate(doneTime) : "Chưa hoàn thành"
                  }}</span></span
                >
              </v-col>
            </v-row>
          </v-container>
        </v-card-text>
      </v-card>
    </v-row>
  </div>
</template>

<script>
export default {
  name: "VideoDoneData",
  data() {
    return {};
  },

  props: {
    item: Object,
    url: String,
    doneTime: String,
  },
  methods: {
    fixDate(vari) {
      return (
        vari.substring(8, 10) + vari.substring(4, 8) + vari.substring(0, 4)
      );
    },
  },
};
</script>

<style lang="css" scoped>
span {
  font-size: 18px;
  margin-bottom: 12px;
}
</style>
