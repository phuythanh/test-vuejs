<template>
  <div class="hello">
    <el-select v-model="countrySelect" placeholder="Select " filterable>
      <el-option
        v-for="country in countries"
        :key="country.ISO2"
        :label="country.Country"
        :value="country.ISO2"
      >
      </el-option>
    </el-select>
  </div>
</template>

<script>
import { mapActions, mapGetters } from "vuex";
import {
  FETCH_ALL_CORONA,
  FETCH_COUNTRIES,
  FETCH_CORONA_SUMMARY,
  SET_COUNTRY,
} from "@/store/actionNames";

export default {
  name: "Country",
  data() {
    return {
      countrySelect: null,
    };
  },
  created() {
    this.getCountries();
    this.getConrona();
  },
  watch: {
    countrySelect(newVal) {
      if (this.countrySummary) {
        var data = this.countrySummary.Countries.find(
          (x) => x.CountryCode === newVal
        );
        this.setCountry(data);
      }
    },
  },
  computed: {
    ...mapGetters("CoronaVirus", ["countries", "countrySummary"]),
  },
  methods: {
    ...mapActions("CoronaVirus", {
      getCountries: FETCH_COUNTRIES,
      getConrona: FETCH_CORONA_SUMMARY,
      setCountry: SET_COUNTRY,
    }),
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
</style>
