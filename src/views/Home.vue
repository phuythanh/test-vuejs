<template>
  <div class="home">
    <el-row>
      <el-col>
        <Countries />
      </el-col>
    </el-row>
    <el-row>
      <el-col>
        <ContryDetail />
      </el-col>
    </el-row>
  </div>
</template>

<script>
export default {
  name: "Home",
  components: {
    Countries: () => import("../components/Countries.vue"),
    ContryDetail: () => import("../components/ContryDetail.vue"),
  },
};
</script>
