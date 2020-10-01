<template>
  <div>
    <el-row>
      <el-col :span="24">
        <el-badge :value="countryDetail.NewConfirmed" class="item">
          <el-button size="small">New Confirmed</el-button>
        </el-badge>
        <el-badge :value="countryDetail.TotalConfirmed" class="item">
          <el-button size="small">Total Confirmed</el-button>
        </el-badge>
        <el-badge :value="countryDetail.NewDeaths" class="item">
          <el-button size="small">New Deaths</el-button>
        </el-badge>
        <el-badge :value="countryDetail.TotalDeaths" class="item">
          <el-button size="small">Total Deaths</el-button>
        </el-badge>
        <el-badge :value="countryDetail.NewRecovered" class="item">
          <el-button size="small">New Recovered</el-button>
        </el-badge>
        <el-badge :value="countryDetail.TotalRecovered" class="item">
          <el-button size="small">Total Recovered</el-button>
        </el-badge>
      </el-col>
    </el-row>
  </div>
</template>

<script>
import { mapActions, mapGetters } from "vuex";
import {
  FETCH_ALL_CORONA,
  FETCH_COUNTRIES,
  FETCH_CORONA_SUMMARY,
} from "@/store/actionNames";

export default {
  name: "Country",
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
  methods: {},
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
.el-badge {
  margin-right: 80px;
  margin-top: 30px;
}
</style>
