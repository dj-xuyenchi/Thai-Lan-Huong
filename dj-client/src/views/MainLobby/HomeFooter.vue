<template>
  <div class="footer-container">
    <div class="content">
      <ul id="footer-item-container">
        <li class="footer-item-detail">
          <img
            :src="require('../../assets/logo-web.png')"
            alt=""
            style="float: left; width: 60px; height: 60px"
          />
          <div style="height: 60px; display: flex; align-items: center">
            <span
              style="
                font-size: 16px;
                font-weight: 600;
                color: white;
                font: system-ui, 'Segoe UI', Roboto, Helvetica, Arial,
                  sans-serif, 'Apple Color Emoji', 'Segoe UI Emoji',
                  'Segoe UI Symbol';
                margin-left: 8px;
              "
            >
              Code Không Khó</span
            >
          </div>
          <ul id="footer-contact">
            <li>
              <font-awesome-icon icon="fa-solid fa-phone" color="white" />
              <span>+84 968491797</span>
            </li>
            <li>
              <font-awesome-icon icon="fa-solid fa-envelope" color="white" />
              <span>do.quanganh99zz@gmail.com</span>
            </li>
            <li>
              <font-awesome-icon
                icon="fa-solid fa-location-dot"
                color="white"
              />
              <span>63 Lê Đức Thọ - Mỹ Đình - Hà Nội</span>
            </li>
          </ul>
        </li>
        <li class="footer-item-detail">
          <div
            style="
              height: 60px;
              display: flex;
              align-items: center;
              justify-content: center;
            "
          >
            <span
              style="
                font-size: 16px;
                font-weight: 600;
                color: white;
                font: system-ui, 'Segoe UI', Roboto, Helvetica, Arial,
                  sans-serif, 'Apple Color Emoji', 'Segoe UI Emoji',
                  'Segoe UI Symbol';
                margin-left: 8px;
              "
            >
              Khóa Học Hot</span
            >
          </div>
          <ul id="footer-contact">
            <li>
              <font-awesome-icon icon="fa-solid fa-phone" color="white" />
              <span>+84 968491797</span>
            </li>
            <li>
              <font-awesome-icon icon="fa-solid fa-envelope" color="white" />
              <span>do.quanganh99zz@gmail.com</span>
            </li>
            <li>
              <font-awesome-icon
                icon="fa-solid fa-location-dot"
                color="white"
              />
              <span>63 Lê Đức Thọ - Mỹ Đình - Hà Nội</span>
            </li>
          </ul>
        </li>
        <li class="footer-item-detail">
          <div
            style="
              height: 60px;
              display: flex;
              align-items: center;
              justify-content: center;
            "
          >
            <span
              style="
                font-size: 16px;
                font-weight: 600;
                color: white;
                font: system-ui, 'Segoe UI', Roboto, Helvetica, Arial,
                  sans-serif, 'Apple Color Emoji', 'Segoe UI Emoji',
                  'Segoe UI Symbol';
                margin-left: 8px;
              "
            >
              Di chuyển</span
            >
          </div>
        </li>
      </ul>
    </div>
    <div style="width: 100%; margin-top: 40px; margin-left: 15%">
      <h2 style="color: white">Group Facebook</h2>
      <iframe
        src="https://www.facebook.com/plugins/group.php?href=https%3A%2F%2Fwww.facebook.com%2Fgroups%2F731193178473217%2F&width=280&show_metadata=true&appId=932156381257868&height=0"
        width="400"
        height="300"
        style="border: none; overflow: hidden"
        scrolling="no"
        frameborder="0"
        allowfullscreen="true"
        allow="autoplay; clipboard-write; encrypted-media; picture-in-picture; web-share"
      ></iframe>
    </div>
  </div>
</template>

<script>
export default {
  name: "HomeFooter",
};
</script>

<style lang="css" scoped>
.footer-container {
  background-color: black;
  width: 100%;
  display: inline-block;
}
.footer-container .content {
  margin-left: 15%;
  width: 70%;
  display: inline-block;
}
.footer-container .content #footer-item-container .footer-item-detail {
  width: 33.333%;
  float: left;
  margin-top: 60px;
}
#footer-item-container span {
  color: white;
  font-size: 14px;
  font-weight: 300;
}
#footer-item-container .footer-item-detail img {
  width: 60px;
}
.footer-item-detail #footer-contact {
  margin-top: 20px;
}
.footer-item-detail #footer-contact li svg {
  margin: 0 8px 0 8px;
}
</style>
