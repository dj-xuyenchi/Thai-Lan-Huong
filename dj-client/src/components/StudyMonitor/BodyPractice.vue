<template>
  <div style="margin-left: 2.5%">
    <div style="margin-top: 20px; width: 97.5%">
      <table>
        <thead>
          <tr>
            <th class="text-left">Input</th>
            <th class="text-left">Output</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>{{ input }}</td>
            <td>{{ expectOutput }}</td>
          </tr>
        </tbody>
      </table>
      <div v-if="explain" style="margin-top: 20px">
        <h4 style="font-size: 24px; font-family: inherit; font-weight: 700">
          Giải thích
        </h4>
        <span
          style="font-family: inherit; font-weight: 350"
          v-html="explain"
        ></span>
      </div>
      <div v-if="suggest" style="margin-top: 20px">
        <h4 style="font-size: 24px; font-family: inherit; font-weight: 700">
          Gợi ý cách làm
        </h4>
        <span v-html="suggest"></span>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "BodyPractice",
  props: {
    explain: String,
    input: String,
    expectOutput: String,
    suggest: String,
  },
};
</script>

<style lang="css" scoped>
.infor-lesson {
  width: 95%;
  border-radius: 5px;
  background-color: #2d2d2d;
  color: white;
  margin-top: 12px;
  display: flex;
  align-items: center;
  min-height: 40px;
}
.infor-lesson .fix-middle {
  padding: 12px 12px 12px 4%;
}
table {
  border-collapse: collapse;
  border: 1px solid black;
  width: 100%;
}
th,
td {
  border: 1px solid black;
  padding: 5px;
}
</style>
