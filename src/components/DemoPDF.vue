<template>
  <div>
    <el-button @click="doViewPdf">view report</el-button>
    <pdf
      style="width: 50%"
      src="http://localhost:64591/api/report/exportpdf"
    ></pdf>
    <!-- <iframe
      src="http://localhost:64591/api/report/exportpdf"
      style="width: 600px; height: 500px"
      frameborder="0"
    ></iframe> -->
  </div>
</template>

<script>
import { mapActions, mapGetters } from "vuex";
import { VIEW_PDF } from "@/store/actionNames";
import pdf from "vue-pdf";
export default {
  name: "Country",
  components: {
    pdf,
  },
  data() {
    return {
      countrySelect: null,
    };
  },
  created() {},
  watch: {},
  computed: {
    ...mapGetters("CoronaVirus", ["countryDetail"]),
  },
  methods: {
    ...mapActions("Pdf", {
      viewPdf: VIEW_PDF,
    }),
    doViewPdf: function () {
      this.viewPdf();
    },
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
.el-badge {
  margin-right: 80px;
  margin-top: 30px;
}
</style>
