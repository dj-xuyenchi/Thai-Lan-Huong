<template>
  <div>
    <v-row>
      <!-- <v-dialog v-model="dialog" persistent width="1024"> -->
      <!-- <template v-slot:activator="{ props }">
          <v-btn color="primary" v-bind="props"> Thêm bài học video</v-btn>
        </template> -->
      <v-form @submit.prevent="submit()" ref="form">
        <v-card style="height: 90vh; overflow: scroll; width: 1024px">
          <v-card-title>
            <span class="text-h5">Dữ liệu học lý thuyết</span>
          </v-card-title>
          <v-card-text>
            <v-container>
              <v-row>
                <v-col cols="12" sm="6" md="4">
                  <v-text-field
                    label="Tên bài học*"
                    hint="Khi hiển thị sẽ là Bài học + tên bài học"
                    v-model="lessonName"
                    :rules="rules"
                  ></v-text-field>
                </v-col>
                <v-col cols="12" sm="6" md="4">
                  <v-text-field
                    label="Mô tả*"
                    hint="Mô tả bài học"
                    v-model="lessonDescription"
                  ></v-text-field>
                </v-col>
                <v-col cols="12" sm="6" md="4">
                  <v-text-field
                    label="Thời lượng*"
                    hint="Thời lượng của bài học"
                    v-model="lessonTime"
                  ></v-text-field>
                </v-col>
                <v-col cols="12">
                  <v-text-field
                    label="Link video*"
                    hint="Link video"
                    v-model="linkVideo"
                  ></v-text-field>
                </v-col>
              </v-row>
            </v-container>
            <small>* là trường là bắt buộc!</small>
          </v-card-text>
        </v-card>
      </v-form>
      <!-- </v-dialog> -->
    </v-row>
  </div>
</template>

<script>
export default {
  name: "VideoData",
  props: {
    doneData: Object,
  },
};
</script>

<style lang="scss" scoped></style>
