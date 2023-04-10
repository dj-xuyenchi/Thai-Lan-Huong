<template>
  <div class="content-body-container">
    <SentenceItem
      sentence="Một giáo viên trung học ở bang Florida, Mỹ, bị sa thải vì cho học sinh tự viết cáo phó trước khi tham gia diễn tập phản ứng với xả súng."
    />
    <SentenceItem
      sentence="Học khu Quận Cam cho biết một giáo viên đã đưa ra
    bài tập không phù hợp về bạo lực học đường và bị chấm dứt hợp đồng, song
    không cung cấp thêm thông tin chi tiết."
    />
    <SentenceItem
      sentence="Trong khi đó, Jeffrey Keene, giáo viên lâu năm được trường trung học Dr. Phillips ở Orlando thuê hồi tháng một, nói với kênh Fox News rằng ông đã bị sa thải mà không có lời giải thích."
    />
    <SentenceItem
      sentence="Một giáo viên trung học ở bang Florida, Mỹ, bị sa thải vì cho học sinh tự viết cáo phó trước khi tham gia diễn tập phản ứng với xả súng."
    />
    <ImageItem imageTitle="Em gái ở Hoàng Công Chất siêu kute!" imageData="" />
    <SentenceItem
      sentence="Một giáo viên trung học ở bang Florida, Mỹ, bị sa thải vì cho học sinh tự viết cáo phó trước khi tham gia diễn tập phản ứng với xả súng."
    />
    <FooterPost />
  </div>
</template>

<script>
import SentenceItem from "./SentenceItem.vue";
import ImageItem from "./ImageItem.vue";
import FooterPost from "./FooterPost.vue";

export default {
  name: "PostContentBody",
  components: { SentenceItem, ImageItem, FooterPost },
};
</script>

<style lang="css" scoped></style>
