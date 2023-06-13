<template>
  <div>
    <v-row>
      <v-dialog v-model="dialog" persistent width="1024">
        <template v-slot:activator="{ props }">
          <v-btn
            color="green"
            v-bind="props"
            density="compact"
            icon="mdi-pencil"
          >
          </v-btn>
        </template>
        <v-form @submit.prevent="submit()" ref="form" style="overflow: scroll">
          <v-card>
            <v-card-title>
              <span class="text-h5">Cập nhật thứ tự</span>
            </v-card-title>
            <v-card-text>
              <v-container>
                <v-row>
                  <v-col cols="12" sm="12" md="12">
                    <div
                      style="white-space: pre-line"
                      v-html="renderedHTML"
                    ></div>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-select
                      v-model="opt"
                      label="Trạng thái bài viết*"
                      :items="listOpt"
                      item-title="name"
                      persistent-hint
                      return-object
                      item-value="id"
                      variant="outlined"
                    ></v-select>
                  </v-col>
                </v-row>
              </v-container>
              <small>* là trường là bắt buộc. !</small>
            </v-card-text>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn
                color="blue-darken-1"
                variant="text"
                @click="dialog = false"
              >
                Hủy
              </v-btn>
              <v-btn
                color="blue-darken-1"
                :loading="btnLoading"
                variant="text"
                type="submit"
              >
                Cập nhật
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-form>
      </v-dialog>
    </v-row>
  </div>
  <v-snackbar v-model="snackbar">
    {{ text }}
    <template v-slot:actions>
      <v-btn color="green" variant="text" @click="snackbar = false">
        Đóng
      </v-btn>
    </template>
  </v-snackbar>
</template>

<script>
import MarkdownIt from "markdown-it";
import AdminAPI from "../../../apis/APIAdmin/AdminAPI.ts";
import { mapMutations } from "vuex";
export default {
  name: "BtnPreviewPost",
  created() {
    const md = new MarkdownIt();
    var htmlContent = md.render(this.renderedHTMLData);
    htmlContent = htmlContent.replaceAll("<img ", "<img style=max-width:100% ");
    this.renderedHTML = htmlContent;
  },
  data() {
    return {
      text: "",
      opt: { name: "Cho phép", id: 1 },
      listOpt: [
        {
          name: "Cho phép",
          id: 1,
        },
        {
          name: "Không cho phép",
          id: 2,
        },
        {
          name: "Vi phạm nguyên tắc",
          id: 3,
        },
      ],
      renderedHTML: "",
      renderedHTMLData: `#### Dù ChatGPT chưa hỗ trợ tại Việt Nam, nhưng bằng một vài thủ thuật bạn vẫn có thể tự tạo tài khoản ChatGPT, đăng ký ChatGPT với email chính chủ và chi phí chỉ bằng một cốc trà đá.

Sử dụng mạng xã hội gần đây, có lẽ không ai là không nghe thấy khái niệm ChatGPT là gì. Đây là phần mềm chat sử dụng trí tuệ nhân tạo AI có thể trả lời hầu như mọi câu hỏi (tất nhiên không thể hoàn toàn chính xác). Nếu bạn tò mò muốn đăng ký sử dụng ChatGPT để tận dụng sự thông minh của AI hay đơn thuần chỉ là “nghịch cho biết” thì bài viết sau đây sẽ hướng dẫn chi tiết.

![Description](https://images.fpt.shop/unsafe/filters:quality(90)/fptshop.com.vn/uploads/images/tin-tuc/154372/Originals/chatgpt.jpg)

Hiện tại ChatGPT đang chưa hỗ trợ đăng ký tại Việt Nam, đồng thời cũng chặn mạng Việt Nam. Vì vậy cách để tạo tài khoản và sử dụng ChatGPT tương đối khó khăn với nhiều người. Đừng lo, chỉ cần làm đúng các bước sau đây, bạn sẽ nhanh chóng được trải nghiệm ChatGPT.
### Cách đăng ký tài khoản ChatGPT chính chủ tại Việt Nam
Khó khăn của việc tạo tài khoản ChatGPT đó là bạn phải sử dụng số điện thoại của một trong các nước hỗ trợ. Ở đây chúng ta sẽ đi thuê số điện thoại ảo khu vực nước Mỹ tại trang web SMSPool.
### Cách thuê số điện thoại USA trên SMSpool
**Bước 1:** Truy cập trang web [https://www.smspool.net/](http://), chọn mục Register để đăng ký tài khoản.

![Description](https://images.fpt.shop/unsafe/filters:quality(90)/fptshop.com.vn/uploads/images/tin-tuc/154372/Originals/chatgpt-1.JPG)

**Bước 2:** Bạn nhập các thông tin vào để đăng ký:

**Username:** Tên đăng nhập, ví dụ fptshop.

**Password:** Nhập mật khẩu của bạn.

**Repeat Password:** Nhập lại mật khẩu.

2 ô ở dưới không cần điền, sau đó bạn tick vào **Accept Terms of Service and Privacy Policy** và nhấn Register để đăng ký.

![Description](https://images.fpt.shop/unsafe/filters:quality(90)/fptshop.com.vn/uploads/images/tin-tuc/154372/Originals/chatgpt-2.JPG)

**Bước 3:** Sau khi đăng ký thành công, bạn đã có thể đăng nhập vào SMSPool, nhập tên và mật khẩu vừa tạo của bạn ở trên rồi chọn **Sign In**.

![Description](https://images.fpt.shop/unsafe/filters:quality(90)/fptshop.com.vn/uploads/images/tin-tuc/154372/Originals/chatgpt-3.JPG)

**Bước 4:** Sau khi đăng nhập, bạn cần phải sử dụng thẻ Tín dụng Visa để thuê số điện thoại ảo. Bạn nhấn vào **Deposit** > chọn **Credit Card** ở **Payment Method** > ô **Ammount** bạn chọn 1 (nạp vào 1 USD) rồi nhấn **Deposit**. Tiếp đó màn hình thanh toán sẽ hiện ra, bạn chỉ cần nhập thông tin để tiến hành thanh toán.

![Description](https://images.fpt.shop/unsafe/filters:quality(90)/fptshop.com.vn/uploads/images/tin-tuc/154372/Originals/chatgpt-5.JPG)

![Description](https://images.fpt.shop/unsafe/filters:quality(90)/fptshop.com.vn/uploads/images/tin-tuc/154372/Originals/chatgpt-6.JPG)

**Bước 5:** Sau khi thanh toán thành công (**Balance**của bạn đã có 1 USD). Bạn chọn mục **Quick Order** > Ô **Service** chọn **OpenAI/ChatGPT** > mục **Pricing Option** để mặc định **Select highest success rate** > nhấn **Purchase** ở phần quốc gia **United Kingdom** hoặc **United States**. Ở đây người viết đã mua một số điện thoại từ **United Kingdom** với giá chỉ 0.14 USD (khoảng 3000 đồng), chỉ tương đương một cốc trà đá.

Nếu mua không thành công bạn có thể thử lại vài lần sẽ thấy số điện thoại và **SMS OTP** ở trạng thái đang chờ (lưu ý trạng thái này chỉ 5 phút, vì thế bạn nên xong Bước 2 ở phần đăng ký tài khoản **ChatGPT** dưới đây mới bắt đầu **Purchase** số điện thoại).

![Description](https://images.fpt.shop/unsafe/filters:quality(90)/fptshop.com.vn/uploads/images/tin-tuc/154372/Originals/chatgpt-7.JPG)

![Description](https://images.fpt.shop/unsafe/filters:quality(90)/fptshop.com.vn/uploads/images/tin-tuc/154372/Originals/chatgpt-8.JPG)
Sau khi đã thuê số điện thoại thành công từ SMSPool, bạn đăng ký tài khoản ChatGPT như sau:

### Cách đăng ký tài khoản ChatGPT tại Việt Nam
**Bước 1:** Do **ChatGPT** đang chặn IP mạng từ **Việt Nam**, nên bạn cần dùng một phần mềm **VPN** để fake IP máy. Bạn có thể sử dụng bất cứ phần mềm **VPN** nào mà bạn quen dùng, ở đây chúng tôi dùng **Touch VPN** trên trình duyệt Chrome. Tải về **Touch VPN** trên **Chrome** tại đây [https://chrome.google.com/webstore/detail/touch-vpn-secure-and-unli/bihmplhobchoageeokmgbdihknkjbknd](http://).

![Description](https://images.fpt.shop/unsafe/filters:quality(90)/fptshop.com.vn/uploads/images/tin-tuc/154372/Originals/chatgpt-9.JPG)

**Bước 2:** Lưu ý trước khi đăng ký tài khoản ChatGPT bạn phải kích hoạt VPN trước, nếu không sẽ bị lỗi đăng ký. Bạn bật Touch VPN lên và chọn khu vực USA hoặc United Kingdom. Sau khi kích hoạt VPN, bạn truy cập trang web của ChatGPT tại đây https://chat.openai.com/. Chọn mục Sign up để đăng ký > điền tài khoản Gmail của bạn > tạo mật khẩu. Tiếp theo bạn sẽ được yêu cầu xác nhận bằng cách đăng nhập vào Gmail và nhấn vào đường link được gửi từ Open AI.

![Description](https://images.fpt.shop/unsafe/filters:quality(90)/fptshop.com.vn/uploads/images/tin-tuc/154372/Originals/chatgpt-11.JPG)

![Description](https://images.fpt.shop/unsafe/filters:quality(90)/fptshop.com.vn/uploads/images/tin-tuc/154372/Originals/chatgpt-12.JPG)

![Description](https://images.fpt.shop/unsafe/filters:quality(90)/fptshop.com.vn/uploads/images/tin-tuc/154372/Originals/chatgpt-13(1).jpg)

**Bước 3:** Sau khi xác nhận, bạn đến bước điền tên và số điện thoại. Bạn có thể nhập tên bạn, số điện thoại và OTP lấy từ SMS Pool như bước ở trên. Nếu bị quá thời gian 5 phút OTP bạn có thể chọn Refund trong SMS Pool để hoàn tiền và mua lại số điện thoại khác.

![Description](https://images.fpt.shop/unsafe/filters:quality(90)/fptshop.com.vn/uploads/images/tin-tuc/154372/Originals/chatgpt-14.jpg)

![Description](https://images.fpt.shop/unsafe/filters:quality(90)/fptshop.com.vn/uploads/images/tin-tuc/154372/Originals/chatgpt-15.jpg)

**Bước 4:** Sau khi đăng ký thành công, bạn đã có thể đăng nhập vào ChatGPT và hỏi AI đủ mọi thứ “trên trời dưới biển” rồi.

![Description](https://images.fpt.shop/unsafe/filters:quality(90)/fptshop.com.vn/uploads/images/tin-tuc/154372/Originals/chatgpt-16.JPG)`,
      snackbar: false,
      dialog: false,
      btnLoading: false,
    };
  },
  methods: {
    ...mapMutations(["setIsLoadedData"]),
    async submit() {
      this.btnLoading = true;
      if (this.sortNumber <= 0) {
        this.text = "Sort Number phải lớn hơn 0";
        this.snackbar = true;
        this.dialog = false;
        this.btnLoading = false;
        return;
      }
      const token = localStorage.getItem("token");
      const result = await AdminAPI.updateSortNumberCourseChapter(
        this.courseChapterId,
        this.sortNumber,
        token
      );
      if (result.data == 1) {
        this.text = "Cập nhật thành công";
        this.dialog = false;
        this.snackbar = true;
        this.getChapterOfCourse();
      }
      if (result.data == 4) {
        this.text = "Không tồn tại";
        this.snackbar = true;
      }
      this.btnLoading = false;
    },
  },
  props: {
    getChapterOfCourse: Function,
    courseChapterId: Number,
  },
};
</script>

<style lang="css" scoped></style>
