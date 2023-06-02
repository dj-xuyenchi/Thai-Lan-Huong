export const SeoTool = (
  title: string,
  des: string,
  img: string,
  url: string
) => {
  // Lấy các thẻ meta
  const metaTitle: any = document.getElementById("metaTitle");
  const metaDescription: any = document.getElementById("metaDescription");
  const metaImage: any = document.getElementById("metaImage");
  const metaURL: any = document.getElementById("metaURL");

  // Thay đổi giá trị của các thẻ meta
  metaTitle.content = title;
  metaDescription.content = des;
  metaImage.content = img;
  metaURL.content = url;
};
